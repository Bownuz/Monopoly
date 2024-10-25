using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatServerApplicatie.ChatRoom {
    [Serializable]
    internal class ChatMessage {
        string sender { get; }
        Byte[] message { get; }
        DateTime DateTime { get; }
        int MessageID { get; }
        


        public ChatMessage(string sender, Byte[] message) {
            this.sender = sender;
            this.message = message;
            this.DateTime = DateTime.Now;
            this.MessageID = this.sender.GetHashCode()+this.message.GetHashCode()+DateTime.GetHashCode();
        }
    }
}
