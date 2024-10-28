﻿using ChatServerApplicatie.Chatroom;
using ChatServerApplicatie.ChatRoom;
using SendableObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ChatServerApplicatie.ProtocolState {
    class Login : ProtocolState {
        private static Dictionary<string, byte[]> accounts = new Dictionary<string, byte[]>();

        public Login(DataProtocol dataProtocol) : base(dataProtocol) { }

        public override string CheckUserInput(string input) {
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
            byte[] passwordHash = loginData.passwdHash;
            Boolean createAcount = loginData.createAcount;
            if (!createAcount) {
                if (accounts.TryGetValue(userName, out var storedHash)) {
                    if (storedHash.SequenceEqual(passwordHash)) {
                        protocol.ChangeState(new SearchLobby(protocol));
                        return "Welcome"; 
                    } else {
                        return "Username or password incorrect";
                    }
                } else {
                    return "Account does not exist.";
                }
            } 
                if (accounts.ContainsKey(userName)) {
                    return "This name already exists"; 
                }

                accounts[userName] = passwordHash;
                protocol.ChangeState(new SearchLobby(protocol));
                return "Welcome"; 
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
                    return "Lobby joined";
                }
                return "Lobby not found";
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

