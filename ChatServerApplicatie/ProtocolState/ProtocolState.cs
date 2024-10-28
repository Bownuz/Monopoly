using ChatServerApplicatie.Chatroom;
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
        private static Dictionary<string, byte[]> accounts = new Dictionary<string, byte[]>(); // Simuleer accountopslag met wachtwoordhashes

        public Login(DataProtocol dataProtocol) : base(dataProtocol) { }

        public override string CheckUserInput(string input) {
            // Stuur prompt voor gebruikersnaam indien nog geen gegevens ontvangen
            if (string.IsNullOrWhiteSpace(input)) {
                return "Send userName";
            }

            // Deserialiseer JSON naar AccountLogIn-object om logingegevens te controleren
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
            // Verwerk Login of Register commando's
            if (!createAcount) {
                if (accounts.TryGetValue(userName, out var storedHash)) {
                    if (storedHash.SequenceEqual(passwordHash)) {
                        protocol.ChangeState(new SearchLobby(protocol));
                        return "Welcome"; // Succesvolle login
                    } else {
                        return "Username or password incorrect"; // Wachtwoord fout
                    }
                } else {
                    return "Account does not exist."; // Geen bestaand account
                }
            } 
                // Controleer of gebruikersnaam al bestaat
                if (accounts.ContainsKey(userName)) {
                    return "This name already exists"; // Naam bestaat al
                }

                // Maak nieuw account aan
                accounts[userName] = passwordHash;
                protocol.ChangeState(new SearchLobby(protocol));
                return "Welcome"; // Nieuwe account succesvol gemaakt
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

