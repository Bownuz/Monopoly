using ChatServerApplicatie.Chatroom;
using ChatServerApplicatie.ChatRoom;
using SendableObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ChatServerApplicatie.ProtocolState {
    class Login : ProtocolState {
        public Login(DataProtocol dataProtocol) : base(dataProtocol) { }

        public override string CheckUserInput(string input, Socket socket) {
            if (string.IsNullOrWhiteSpace(input)) {
                return "Send userName";
            }

            AccountLogIn loginData;
            try {
                loginData = JsonSerializer.Deserialize<AccountLogIn>(input);
            }
            catch (JsonException) {
                return JsonSerializer.Serialize(new { message = "Invalid login data format. Please provide correct JSON." });
            }

            if (loginData == null || string.IsNullOrEmpty(loginData.name) || loginData.passwdHash == null) {
                return "Incomplete login data.";
            }

            string userName = loginData.name;
            LobbyManager.userSocket.Add(userName, socket);
            byte[] passwordHash = loginData.passwdHash;
            Boolean createAcount = loginData.createAcount;
            if (!createAcount) {
                if (AccountManager.Accounts.TryGetValue(userName, out var storedHash)) {
                    if (storedHash.SequenceEqual(passwordHash)) {
                        protocol.ChangeState(new SearchLobby(protocol, userName));
                        return JsonSerializer.Serialize(LobbyManager.GetLobbyNames());
                    } else {
                        return "Username or password incorrect";
                    }
                } else {
                    return "Account does not exist.";
                }
            }
            if (AccountManager.Accounts.ContainsKey(userName)) {
                return "This name already exists";
            }

            AccountManager.Accounts[userName] = passwordHash;
            protocol.ChangeState(new SearchLobby(protocol, userName));
            return JsonSerializer.Serialize(LobbyManager.GetLobbyNames());
        }
    }

    class SearchLobby : ProtocolState {
        private string userName;
        public SearchLobby(DataProtocol dataProtocol, string userName) : base(dataProtocol) {
            this.userName = userName;
        }

        public override string CheckUserInput(string input, Socket socket) {
            if (input.StartsWith("Lobby:")) {
                string lobbyName = input.Substring("Lobby:".Length).Trim();

                var lobby = LobbyManager.GetOrCreateLobby(lobbyName);
                LobbyManager.AddUserToLobby(lobbyName, userName);
                protocol.ChangeState(new Chat(protocol, lobby, userName));
                return "Lobby joined";
            }
            return "Lobby not found";
        }
    }
    class Chat : ProtocolState {
        private IChatroom chatRoom;
        private string userName;
        public Chat(DataProtocol dataProtocol, IChatroom chatRoom, string userName) : base(dataProtocol) {
            this.chatRoom = chatRoom;
            this.userName = userName;
        }

        public override string CheckUserInput(string input, Socket socket) {
            if (input.StartsWith("Message:")) {
                string messageText = input.Substring("Message:".Length).Trim();
                var chatMessage = ChatMessage.Create("Client", Encoding.UTF8.GetBytes(userName + ": " + messageText));
                chatRoom.AddMessage(chatMessage);

            } else if (input.Equals("Go back")) {
                LobbyManager.RemoveUserFromLobby(chatRoom.ChatRoomID, userName);
                protocol.ChangeState(new SearchLobby(protocol, userName));
                return JsonSerializer.Serialize(LobbyManager.GetLobbyNames());
            }
            return null;
        }
    }
    class Exit : ProtocolState {
        public Exit(DataProtocol dataProtocol) : base(dataProtocol) {
        }

        public override string CheckUserInput(string input, Socket socket) {
            return "Goodbye";
        }
    }
}

