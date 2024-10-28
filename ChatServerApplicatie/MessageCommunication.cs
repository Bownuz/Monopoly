using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ChatServerApplicatie {
    public class MessageCommunication {
        public static async Task<string> RecieveMessage(Socket client) {
            byte[] sizeBuffer = new byte[4];
            await client.ReceiveAsync(sizeBuffer, SocketFlags.None);
            int messageSize = BitConverter.ToInt32(sizeBuffer, 0);

            byte[] messageBuffer = new byte[messageSize];
            int receivedBytes = await client.ReceiveAsync(messageBuffer, SocketFlags.None);
            return Encoding.UTF8.GetString(messageBuffer, 0, receivedBytes);
        }

        public static async Task SendMessage(Socket client, string message) {
            byte[] messageBuffer = Encoding.UTF8.GetBytes(message);
            byte[] sizeBuffer = BitConverter.GetBytes(messageBuffer.Length);

            await client.SendAsync(sizeBuffer, SocketFlags.None);
            await client.SendAsync(messageBuffer, SocketFlags.None);
        }
    }
}
