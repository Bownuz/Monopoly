using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ChatClientApplicatie {
    public class MessageCommunication {
        public static string RecieveMessage(TcpClient client) {
            try {
                var stream = new StreamReader(client.GetStream(), Encoding.ASCII);
                Console.WriteLine("Wachten op bericht...");
                string message = stream.ReadLine();
                Console.WriteLine("Bericht ontvangen: " + message);
                return message;
            }
            catch (IOException ex) {
                Console.WriteLine("Fout bij ontvangen bericht: " + ex.Message);
                return null;
            }
        }

        public static void SendMessage(TcpClient client, string message) {
            var stream = new StreamWriter(client.GetStream(), Encoding.ASCII, 128, true);
            {
                stream.WriteLine(message);
                stream.Flush();
            }
        }

    }
}
