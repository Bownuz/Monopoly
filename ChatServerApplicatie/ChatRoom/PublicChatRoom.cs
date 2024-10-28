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
        public List<ChatMessage> ChatMessages { get; } = new List<ChatMessage>();
        public List<string> members = new List<string>();

        public PublicChatRoom(string chatRoomId) {
            ChatRoomID = chatRoomId;
        }

        public void AddMember(string memberName) {
            if (!members.Contains(memberName)) {
                members.Add(memberName);
            }
        }

        public void RemoveMember(string memberName) {
            if (members.Contains(memberName)) {
                members.Remove(memberName);
            }
        }

        private void NotifyUsers() {
            foreach (string userName in members) {
                MessageCommunication
            }
        }

        public void AddMessage(ChatMessage message) {
            ChatMessages.Add(message);
            NotifyUsers();
        }
    }
}
