using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;

namespace SendableObjects {
    public class AccountLogIn {
        public string name { get; }
        public byte[] passwdHash { get; }

        public AccountLogIn(string name, byte[] passwdHash) {
            this.name = name;
            this.passwdHash = passwdHash;
        }
    }
    public class SendMessage {
        public string message { get; }

        public SendMessage(string message) {
            this.message = message;
        }
    }
}
