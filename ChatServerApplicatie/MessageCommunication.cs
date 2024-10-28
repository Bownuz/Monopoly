using System;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ChatServerApplicatie {

    public class MessageCommunication {
        public static async Task<string> Receivemessage(Socket client) {
            try {
                byte[] buffer = new byte[1024]; 
                int receivedBytes = await client.ReceiveAsync(buffer, SocketFlags.None);

                if (receivedBytes == 0) {
                    return null;
                }

                string message = Encoding.UTF8.GetString(buffer, 0, receivedBytes);
                Console.WriteLine($"Bericht ontvangen: {message}");
                return message;
            }
            catch (Exception ex) {
                Console.WriteLine($"Error receiving message: {ex.Message}");
                return null;
            }
        }

        public static async Task SendMessage(Socket client, string message) {
            try {
                byte[] messageBuffer = Encoding.UTF8.GetBytes(message);
                await client.SendAsync(messageBuffer, SocketFlags.None);

                Console.WriteLine($"Bericht verstuurd: {message}");
            }
            catch (Exception ex) {
                Console.WriteLine($"Error sending message: {ex.Message}");
            }
        }
    }
}
