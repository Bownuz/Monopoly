using ChatServerApplicatie.ChatRoom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatServerApplicatie.Chatroom {
    internal class PublicChatRoom : IChatroom {
        public string ChatRoomID => throw new NotImplementedException();

        public List<ChatMessage> ChatMessages => throw new NotImplementedException();

        public void NewMessage() {
            throw new NotImplementedException();
        }
    }
}
