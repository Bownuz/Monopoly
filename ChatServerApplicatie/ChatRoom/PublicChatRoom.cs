using ChatServerApplicatie.ChatRoom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace ChatServerApplicatie.Chatroom {
    internal class PublicChatRoom : IChatroom {
        public string ChatRoomID { get; }
        public ChatMessage[] RecentChatMessagesBuffer { get; set; } = new ChatMessage[50];

        public PublicChatRoom(string chatRoomId) {
            ChatRoomID = chatRoomId;
        }

        public void AddMessage(ChatMessage message) {
            ChatMessage[] newRecentChatMessagesBuffer = new ChatMessage[RecentChatMessagesBuffer.Length];

            newRecentChatMessagesBuffer[0] = message;

            Array.Copy(RecentChatMessagesBuffer, 0, newRecentChatMessagesBuffer, 1, RecentChatMessagesBuffer.Length - 1);
            RecentChatMessagesBuffer = newRecentChatMessagesBuffer;
        }
    }
}
