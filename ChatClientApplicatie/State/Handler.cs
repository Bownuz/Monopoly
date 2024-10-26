using SendableObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ChatClientApplicatie.State {
    public class Handler {
        public event Action<string> NewMessage;
        protected bool isRunning;
        protected bool isInitialized;
        protected string clientName;
        protected string clientPassword;
        protected string clientMessage;
        protected TcpClient tcpClient;

        internal Handler(TcpClient tcpClient, string clientName, string clientPassword) {
            //NetworkStream stream = tcpClient.GetStream();
            this.tcpClient = tcpClient;
            this.isRunning = true;
            this.isInitialized = false;
            this.clientName = clientName;
            this.clientPassword = clientPassword;
        }

        internal void UpdateClientInfo(string clientName, string clientPassword, Boolean createAcount) {
            this.clientName = clientName;
            this.clientPassword = clientPassword;
            MessageCommunication.SendMessage(tcpClient, GetClientInfoAsJson());
        }

        internal string GetClientInfoAsJson() {
            AccountLogIn accountLogIn = new AccountLogIn(clientName, SHA512.HashData(Encoding.UTF8.GetBytes(clientPassword)));
            return JsonSerializer.Serialize<AccountLogIn>(accountLogIn);
        }

        public void HandleThread() {
            DataProtocol protocol = new DataProtocol(this);
            new Thread(() => MessageCommunication.RecieveMessage(tcpClient)).Start();

            while (tcpClient.Connected) {
                string recievedMessage;
                string response;
                if ((recievedMessage = MessageCommunication.RecieveMessage(tcpClient)) != null) {
                    NewMessage?.Invoke(recievedMessage);
                    response = protocol.processInput(recievedMessage);
                    if (response != "") {
                        MessageCommunication.SendMessage(tcpClient, response);
                        if (response.Equals("Goodbye")) {
                            tcpClient.Close();
                        }
                    }
                }
            }
        }
    }
}