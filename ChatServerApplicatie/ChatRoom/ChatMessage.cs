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
        public DateTime DateTimeMessage { get; }
        public BigInteger MessageID { get; }



        public ChatMessage(string sender, Byte[] message,DateTime DateTimeMessage, BigInteger MessageID) {
            this.Sender = sender;
            this.Message = message;
            this.DateTimeMessage = DateTimeMessage;
            this.MessageID = MessageID;
        }

        public static ChatMessage Create(string sender, Byte[] message) {
            return new ChatMessage(sender, message, DateTime.UtcNow,  new BigInteger(
                SHA256.HashData(
                    Encoding.UTF8.GetBytes(sender)
                    .Concat(message)
                    .Concat(BitConverter.GetBytes(DateTime.UtcNow.ToBinary()))
                    .ToArray()), true));
        }
    }
}
