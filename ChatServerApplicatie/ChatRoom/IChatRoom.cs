using ChatServerApplicatie.ChatRoom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatServerApplicatie.Chatroom {
    internal interface IChatroom {
        string ChatRoomID { get; }
        ChatMessage[] RecentChatMessagesBuffer { get; set; }
        void AddMessage(ChatMessage message);

    }
}
