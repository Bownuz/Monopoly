using ChatClientApplicatie.GuiScreens;
using SendableObjects;
using System;
using System.Net.Http;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace ChatClientApplicatie.State {
    public class Handler {
        public event Action<string> NewMessage;
        protected string clientName;
        private string clientPassword;
        public Socket clientSocket;
        private Boolean createAcount;
        public DataProtocol protocol;
        private ScreenManager screenManager;

        public Handler(Socket clientSocket, string clientName, string clientPassword, ScreenManager screenManager) {
            this.clientSocket = clientSocket;
            this.clientName = clientName;
            this.clientPassword = clientPassword;
            this.protocol = new DataProtocol(this);
            this.screenManager = screenManager;
        }

        internal string GetClientInfo() {
            return $"Clientname: {clientName} Clientpassword: {clientPassword}";
        }

        public void ChangeScreen(UserControl nextScreen) {
            screenManager.ChangeScreen(nextScreen);
        }

        public async Task HandleAsync() {
            while (clientSocket.Connected) {
                string receivedMessage = await MessageCommunication.Receivemessage(clientSocket);
                if (receivedMessage != null) {
                    NewMessage?.Invoke(receivedMessage);
                    string response = protocol.processInput(receivedMessage);
                    if (!string.IsNullOrEmpty(response)) {
                        await MessageCommunication.SendMessage(clientSocket, response);
                    }
                    if (response == "Disconnected") {
                        Disconnect();
                        break;
                    }
                }
            }
        }


        public void UpdateLobbyInfo(string lobbyName) {
            MessageCommunication.SendMessage(clientSocket, $"Lobby:{lobbyName}");
        }

        public void SendChatMessage(string message) {
            var chatMessage = new SendMessage(message);
            MessageCommunication.SendMessage(clientSocket, "Message:" + JsonSerializer.Serialize(chatMessage));
        }

        public void UpdateClientInfo(string clientName, string clientPassword, bool createAccount) {
            this.clientName = clientName;
            this.clientPassword = clientPassword;
            this.createAcount = createAccount;
            var accountInfo = new AccountLogIn(clientName, SHA512.HashData(Encoding.UTF8.GetBytes(clientPassword)), createAcount);
            MessageCommunication.SendMessage(clientSocket, JsonSerializer.Serialize(accountInfo));
        }

        internal string GetClientInfoAsJson() {
            AccountLogIn accountLogIn = new AccountLogIn(clientName, SHA512.HashData(Encoding.UTF8.GetBytes(clientPassword)), createAcount);
            return JsonSerializer.Serialize<AccountLogIn>(accountLogIn);
        }

        public void ReceiveMessage(string message) {
            NewMessage?.Invoke(message);  
        }

        public void Disconnect() {
            if (clientSocket.Connected) {
                clientSocket.Shutdown(SocketShutdown.Both);
                clientSocket.Close();
                NewMessage?.Invoke("You have been disconnected.");
            }
        }
    }
}
