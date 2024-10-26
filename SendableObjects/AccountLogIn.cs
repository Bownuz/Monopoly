using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json.Serialization;

namespace SendableObjects {
    public class AccountLogIn {
        public AccountLogIn(string Name, byte[] PasswdHash) {
            this.Name = Name;
            this.PasswdHash = PasswdHash;
        }

        public string Name { get; set; }
        public byte[] PasswdHash { get; set; }
    }
}
