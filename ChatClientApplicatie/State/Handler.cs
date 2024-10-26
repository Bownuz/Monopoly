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
        protected bool isRunning;
        protected bool isInitialized;
        protected string clientName;
        protected string clientPassword;
        protected string clientMessage;
        protected Socket clientSocket;

        internal Handler(Socket clientSocket, string clientName, string clientPassword) {
            this.clientSocket = clientSocket;
            this.isRunning = true;
            this.isInitialized = false;
            this.clientName = clientName;
            this.clientPassword = clientPassword;
        }

        internal void AddClientInfo(string clientName, string clientPassword, bool createAccount) {
            this.clientName = clientName;
            this.clientPassword = clientPassword;
            string message = $"ClientName:{clientName} ClientPassword:{clientPassword} NewAccount:{createAccount}";
            SendMessageAsync(message).Wait();
        }

        internal string GetClientInfo() {
            return $"Clientname: {clientName} Clientpassword: {clientPassword}";
        }

        public async Task HandleAsync() {
            DataProtocol protocol = new DataProtocol(this);

            using (clientSocket) {
                while (true) {
                    string receivedMessage = await MessageCommunication.RecieveMessage(clientSocket);
                    if (receivedMessage != null) {
                        NewMessage?.Invoke(receivedMessage);
                        string response = protocol.processInput(receivedMessage);
                        if (!string.IsNullOrEmpty(response)) {
                            await SendMessageAsync(response);
                            if (response.Equals("Goodbye")) {
                                break;
                            }
                        }
                    }
                }
            }
        }

        internal void UpdateClientInfo(string clientName, string clientPassword, Boolean createAcount) {
            this.clientName = clientName;
            this.clientPassword = clientPassword;
            MessageCommunication.SendMessage(clientSocket, GetClientInfoAsJson());
        }

        internal string GetClientInfoAsJson() {
            AccountLogIn accountLogIn = new AccountLogIn(clientName, SHA512.HashData(Encoding.UTF8.GetBytes(clientPassword)));
            return JsonSerializer.Serialize<AccountLogIn>(accountLogIn);
        }

        [Obsolete]
        private async Task ListenForMessagesAsync() {
            while (clientSocket.Connected) {
                string receivedMessage = await MessageCommunication.RecieveMessage(clientSocket);
                if (receivedMessage != null) {
                    NewMessage?.Invoke(receivedMessage);
                }
            }
        }

        private async Task SendMessageAsync(string message) {
            byte[] buffer = Encoding.UTF8.GetBytes(message);
            await clientSocket.SendAsync(new ArraySegment<byte>(buffer), SocketFlags.None);
        }
    }
}
