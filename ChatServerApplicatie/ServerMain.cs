using System.Net.Sockets;
using System.Net;

namespace ChatServerApplicatie {
    internal class ServerMain {
        private static Server? server;
        public static async Task Main(string[] args) {
            AppDomain.CurrentDomain.ProcessExit += OnProcessExit;
            server = new Server(IPAddress.Parse("127.0.0.1"));
            await server.UserConnectionManager();
        }

        private static void OnProcessExit(object? sender, EventArgs e) {
            server?.Shutdown();
        }
    }
}