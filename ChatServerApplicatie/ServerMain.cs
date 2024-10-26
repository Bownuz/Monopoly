using System.Net.Sockets;
using System.Net;

namespace ChatServerApplicatie {
    internal class ServerMain {
        public static async Task Main(string[] args) {
            Server server = new Server(IPAddress.Parse("127.0.0.1"));
            await server.UserConnectionManager();
        }
    }
}