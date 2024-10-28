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

        private void GetSavedServerData() {
            string accountPath = $"{ServerPath}/ServerData/account.json";
            string lobbiesPath = $"{ServerPath}/ServerData/lobbies.json";

            if (File.Exists(accountPath)) {
                AccountManager.Accounts = JsonSerializer.Deserialize<Dictionary<string, Account>>(Encoding.UTF8.GetString(File.ReadAllBytes(accountPath)));
            }
            if (File.Exists(lobbiesPath)) {
                LobbyManager.SetLobbies(JsonSerializer.Deserialize<Dictionary<string, IChatroom>>(Encoding.UTF8.GetString(File.ReadAllBytes(lobbiesPath)));)
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
                    await userTask.ContinueWith(t => { 
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
                MessageCommunication.SendMessage(userSocket, dataProtocol.processInput(""));

                while (true) {
                    string receivedMessage = await MessageCommunication.Receivemessage(userSocket);
                    if (receivedMessage != null) {
                        string response = dataProtocol.processInput(receivedMessage);
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