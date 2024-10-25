using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ChatServerApplicatie {
    partial class ServerMain {
        public static void ClientConnetion(Socket client) {
            byte[] sizeIncomingPacket = new byte[4];

            while (true) {
                int byteSizeIncomingPacket = client.Receive(sizeIncomingPacket);
                int sizeMessage = BitConverter.ToInt32(sizeIncomingPacket);

                byte[] packet = new byte[sizeMessage];
                int bytePacket = client.Receive(packet);
            }
        }
    }
}
