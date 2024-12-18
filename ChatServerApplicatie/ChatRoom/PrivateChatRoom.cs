﻿using ChatServerApplicatie.ChatRoom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatServerApplicatie.Chatroom {
    internal class PrivateChatRoom : IChatroom {
        public string ChatRoomID { get; }
        public List<ChatMessage> ChatMessages { get; } = new List<ChatMessage>();

        public PrivateChatRoom(string chatRoomId) {
            ChatRoomID = chatRoomId;
        }

        public void AddMessage(ChatMessage message) {
            ChatMessages.Add(message);
        }
    }
}
