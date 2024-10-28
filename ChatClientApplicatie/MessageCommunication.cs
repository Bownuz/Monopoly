using System;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ChatClientApplicatie {
    public class MessageCommunication {
        // Methode om berichten te ontvangen
        public static async Task<string> Receivemessage(Socket client) {
            try {
                // Buffer om het bericht te ontvangen (kan groter zijn indien nodig)

                byte[] buffer = new byte[1024];  // Voorbeeldbuffer van 1024 bytes
                int receivedBytes = await client.ReceiveAsync(buffer, SocketFlags.None);

                if (receivedBytes == 0) {
                    // De verbinding is waarschijnlijk gesloten door de server
                    return null;
                }

                // Converteer de ontvangen bytes naar een string
                string message = Encoding.UTF8.GetString(buffer, 0, receivedBytes);
                Console.WriteLine($"Bericht ontvangen: {message}");
                //MessageBox.Show(message);
                return message;
            }
            catch (Exception ex) {
                Console.WriteLine($"Error receiving message: {ex.Message}");
                return null;
            }
        }

        // Methode om berichten te versturen
        public static async Task SendMessage(Socket client, string message) {
            try {
                // Verzend het bericht als UTF-8 bytes
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
