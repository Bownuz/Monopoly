using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatServerApplicatie.ChatRoom {
    [Serializable]
    internal class ChatMessage {
        string Sender { get; }
        Byte[] Message { get; }
        DateTime DateTime { get; }
        int MessageID { get; }
        


        public ChatMessage(string sender, Byte[] message) {
            this.Sender = sender;
            this.Message = message;
            this.DateTime = DateTime.Now;
            this.MessageID = this.Sender.GetHashCode()+this.Message.GetHashCode()+DateTime.GetHashCode();
        }
    }
}
