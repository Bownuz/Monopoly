using ChatServerApplicatie.Chatroom;
using ChatServerApplicatie.ChatRoom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatServerApplicatie.ProtocolState {
    class Login : ProtocolState {
        public Login(DataProtocol dataProtocol) : base(dataProtocol) {
        }

        public override string CheckUserInput(string input) {
            if (input.StartsWith("Login:")) {
                string userName = input.Substring("Login:".Length).Trim();

                protocol.ChangeState(new SearchLobby(protocol));
                return "Welcome, please select a lobby.";
            }
            return "Invalid login input.";
        }
    }
    class SearchLobby : ProtocolState {
        public SearchLobby(DataProtocol dataProtocol) : base(dataProtocol) {
        }

        public override string CheckUserInput(string input) {
            if (input.StartsWith("Lobby:")) {
                string lobbyName = input.Substring("Lobby:".Length).Trim();

                var lobby = LobbyManager.GetOrCreateLobby(lobbyName);
                protocol.ChangeState(new Chat(protocol, lobby));  
                return $"Joined lobby: {lobbyName}";
            }
            return "Lobby not found.";
        }
    }
    class Chat : ProtocolState {
        private IChatroom chatRoom;
        public Chat(DataProtocol dataProtocol, IChatroom chatRoom) : base(dataProtocol) {
            this.chatRoom = chatRoom;
        }

        public override string CheckUserInput(string input) {
            if (input.StartsWith("Message:")) {
                string messageText = input.Substring("Message:".Length).Trim();
                var chatMessage = new ChatMessage("Client", Encoding.UTF8.GetBytes(messageText));
                chatRoom.AddMessage(chatMessage);  

                return $"New message in {chatRoom.ChatRoomID} from {chatMessage.Sender}: {messageText}";
            }
            return null;
        }
    }
    class Exit : ProtocolState {
        public Exit(DataProtocol dataProtocol) : base(dataProtocol) {
        }

        public override string CheckUserInput(string input) {
            return "Goodbye";
        }
    }
}
