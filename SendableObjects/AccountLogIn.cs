using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;

namespace SendableObjects {
    [Serializable]
    public class AccountLogIn {
        public string name { get; }
        public byte[] passwdHash { get; }

        public AccountLogIn(string name, string passwd) {
            this.name = name;
            this.passwdHash = SHA512.HashData(Encoding.UTF8.GetBytes(passwd));
        }
    }
}
