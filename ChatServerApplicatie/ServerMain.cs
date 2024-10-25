using System.Net.Sockets;
using System.Net;

namespace ChatServerApplicatie {
    internal partial class ServerMain {
        private static List<Thread>? ClientConnectionThreads;
        public static void Main(string[] args) {
            ClientConnectionThreads = new List<Thread>();
            IPAddress ipAddr = IPAddress.Parse("127.0.0.1");
            IPEndPoint localEndPoint = new IPEndPoint(ipAddr, 7272);

            Socket listener = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            try {
                listener.Bind(localEndPoint);
                listener.Listen(10);

                for (; ; ) {
                    ClientConnectionThreads.Add(new Thread(() => ServerMain.ClientConnetion(listener.Accept())));
                }
            } catch (Exception ex) {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}