using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ChatServerApplicatie.ChatRoom {
    internal class ChatMessage {
        public string Sender { get; }
        public Byte[] Message { get; }
        public DateTime DateTime { get; }
        public BigInteger MessageID { get; }



        public ChatMessage(string sender, Byte[] message) {
            this.Sender = sender;
            this.Message = message;
            this.DateTime = DateTime.UtcNow;

            this.MessageID = new BigInteger(
                SHA256.HashData(
                    Encoding.UTF8.GetBytes(sender)
                    .Concat(message)
                    .Concat(BitConverter.GetBytes(this.DateTime.ToBinary()))
                    .ToArray()), true);
        }
    }
}
