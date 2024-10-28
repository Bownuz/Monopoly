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



        public ChatMessage(string Sender, Byte[] Message, DateTime DateTimeMessage) {
            this.Sender = Sender;
            this.Message = Message;
            this.DateTimeMessage = DateTimeMessage;
        }

        public static ChatMessage Create(string sender, Byte[] message) {
            return new ChatMessage(sender, message, DateTime.UtcNow);
        }
    }
}
