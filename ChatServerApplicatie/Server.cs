using ChatServerApplicatie.Chatroom;
using ChatServerApplicatie.ChatRoom;
using ChatServerApplicatie.ProtocolState;
using SendableObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace ChatServerApplicatie {
    internal class Server {
        List<Task> ActiveConnections { get; }
        IPAddress IPAddr { get; }
        public static readonly string ServerPath = $"{Directory.GetCurrentDirectory()}/../../..";

        public Server(IPAddress ipAddr) { 
            ActiveConnections = new List<Task>();
            IPAddr = ipAddr;
            GetSavedServerData();
        }

        public void Shutdown() {
            File.WriteAllBytes($"{ServerPath}/ServerData/account.json", Encoding.UTF8.GetBytes(JsonSerializer.Serialize(AccountManager.Accounts)));
            File.WriteAllBytes($"{ServerPath}/ServerData/lobbies.json", Encoding.UTF8.GetBytes(JsonSerializer.Serialize(LobbyManager.GetLobbies())));
            ActiveConnections.ForEach(x => x.Dispose());
        }

        private void GetSavedServerData() {
            string accountPath = $"{ServerPath}/ServerData/account.json";
            string lobbiesPath = $"{ServerPath}/ServerData/lobbies.json";

            if (File.Exists(accountPath)) {
                AccountManager.Accounts = JsonSerializer.Deserialize<Dictionary<string, byte[]>>(Encoding.UTF8.GetString(File.ReadAllBytes(accountPath)));
            }
            if (File.Exists(lobbiesPath)) {
                LobbyManager.SetLobbies(JsonSerializer.Deserialize<Dictionary<string, PublicChatRoom>>(Encoding.UTF8.GetString(File.ReadAllBytes(lobbiesPath))));
            }
        }

        public async Task UserConnectionManager() {
            Console.WriteLine("Running server");
            IPEndPoint localEndPoint = new IPEndPoint(IPAddr, 7272);

            Socket serverSocket = new Socket(IPAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            try {
                serverSocket.Bind(localEndPoint);
                serverSocket.Listen(10);

                for (; ; ) {
                    Console.WriteLine("Waiting for clients");
                    Socket NewUserConnection = await serverSocket.AcceptAsync();

                    if (NewUserConnection == null)
                        continue;

                    var userTask = HandleUser(NewUserConnection);
                    ActiveConnections.Add(userTask);
                    userTask.ContinueWith(t => { 
                        ActiveConnections.Remove(userTask);
                        if (t.IsFaulted) {
                            Console.WriteLine(t.Exception.InnerException.Message);
                            Console.WriteLine(t.Exception.InnerException.StackTrace);
                        }
                    });
                }
            }
            catch (Exception ex) {
                Console.WriteLine(ex.ToString());
            }
        }

        public async Task HandleUser(Socket userSocket) {
            using (userSocket) {
                Console.WriteLine("Client connected");
                DataProtocol  dataProtocol = new DataProtocol();
                MessageCommunication.SendMessage(userSocket, dataProtocol.processInput("", userSocket));

                while (true) {
                    string receivedMessage = await MessageCommunication.Receivemessage(userSocket);
                    if (receivedMessage != null) {
                        string response = dataProtocol.processInput(receivedMessage, userSocket);
                        if (!string.IsNullOrEmpty(response)) {
                            await MessageCommunication.SendMessage(userSocket, response);
                            if (response.Equals("Goodbye")) {
                                break;
                            }
                        }
                    }
                }
            }
        }
    }
}