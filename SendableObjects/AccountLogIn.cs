using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json.Serialization;

namespace SendableObjects {
    public class AccountLogIn {
        public string name { get; }
        public byte[] passwdHash { get; }

        public AccountLogIn(string name, byte[] passwdHash) {
            this.name = name;
            this.passwdHash = passwdHash;
        }

        public static AccountLogIn CreateAccountLogIn(string name, string passwd) {
            return new AccountLogIn(name, SHA512.HashData(Encoding.UTF8.GetBytes(passwd)));
        }
    }

    public class SendMessage {
        public string message { get; }

        public SendMessage(string message) {
            this.message = message;
        }
    }
}
