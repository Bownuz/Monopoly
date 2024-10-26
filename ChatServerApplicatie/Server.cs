using SendableObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        public Server(IPAddress ipAddr) { 
            ActiveConnections = new List<Task>();
            IPAddr = ipAddr;
        }

        public async Task UserConnectionManager() {
            IPEndPoint localEndPoint = new IPEndPoint(IPAddr, 7272);

            Socket serverSocket = new Socket(IPAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            try {
                serverSocket.Bind(localEndPoint);
                serverSocket.Listen(10);

                for (; ; ) {
                    Socket NewUserConnection = await serverSocket.AcceptAsync();

                    if (NewUserConnection == null)
                        continue;

                    var userTask = HandleUser(NewUserConnection);
                    ActiveConnections.Add(userTask);
                    await userTask.ContinueWith(t => { ActiveConnections.Remove(userTask); });
                }
            }
            catch (Exception ex) {
                Console.WriteLine(ex.ToString());
            }
        }

        public async Task HandleUser(Socket userSocket) {
            using (userSocket) {
                byte[] sizeIncomingPacket = new byte[4];

                while (true) {
                    int byteSizeIncomingPacket = await userSocket.ReceiveAsync(sizeIncomingPacket);
                    int sizeMessage = BitConverter.ToInt32(sizeIncomingPacket);

                    byte[] packet = new byte[sizeMessage];
                    int bytePacket = await userSocket.ReceiveAsync(packet);
                    Console.WriteLine(packet.Length);
                    var accountLogInTest = await JsonSerializer.DeserializeAsync<AccountLogIn>(new MemoryStream(packet));
                    Console.WriteLine($"name: {accountLogInTest.name}, passwd: {accountLogInTest}");
                }
            }
        }
    }
}