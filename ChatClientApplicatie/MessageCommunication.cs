    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading.Tasks;

    namespace ChatClientApplicatie {
        public class MessageCommunication {
            public static async Task<string> RecieveMessage(Socket client) {
                try {
                    byte[] sizeIncomingPacket = new byte[4];
                    int byteSizeIncomingPacket = await client.ReceiveAsync(sizeIncomingPacket);
                    int sizeMessage = BitConverter.ToInt32(sizeIncomingPacket);

                    byte[] packet = new byte[sizeMessage];
                    int bytePacket = await client.ReceiveAsync(packet);
                    if (bytePacket > 0) {
                        string message = Encoding.UTF8.GetString(sizeIncomingPacket, 0, bytePacket);
                        Console.WriteLine("Bericht ontvangen: " + message);
                        return message;
                    }
                    return null;
                }
                catch (IOException ex) {
                    Console.WriteLine("Fout bij ontvangen bericht: " + ex.Message);
                    return null;
                }
            }

            public static void SendMessage(Socket client, string message) {
                try {
                    byte[] buffer = Encoding.UTF8.GetBytes(message);
                    client.Send(BitConverter.GetBytes(buffer.Length));
                    client.Send(buffer); 
                    Console.WriteLine("Bericht verzonden: " + message);
                }
                catch (SocketException ex) {
                    Console.WriteLine("Fout bij verzenden bericht: " + ex.Message);
                }
            }
        }
    }
