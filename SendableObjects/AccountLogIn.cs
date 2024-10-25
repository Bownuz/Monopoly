using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;

namespace SendableObjects {
    [Serializable]
    public class AccountLogIn {
        string name { get; }
        byte[] passwdHash { get; }

        public AccountLogIn(string name, string passwd) {
            this.name = name;
            this.passwdHash = SHA512.HashData(Encoding.UTF8.GetBytes(passwd));
        }
    }
}
