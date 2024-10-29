using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChatServerApplicatie.ChatRoom;
using System.Text;
using System.Security.Cryptography;

[TestClass]
public class AccountManagerTests {
    [TestMethod]
    public void AddAccount_ShouldAddNewAccount() {
        // Arrange
        string username = "TestUser";
        byte[] passwordHash = SHA512.HashData(Encoding.UTF8.GetBytes("TestPassword"));

        // Act
        AccountManager.Accounts[username] = passwordHash;

        // Assert
        Assert.IsTrue(AccountManager.Accounts.ContainsKey(username));
        CollectionAssert.AreEqual(passwordHash, AccountManager.Accounts[username]);
    }

    [TestMethod]
    public void GetAccount_ShouldReturnCorrectPasswordHash() {
        // Arrange
        string username = "ExistingUser";
        byte[] passwordHash = SHA512.HashData(Encoding.UTF8.GetBytes("ExistingPassword"));
        AccountManager.Accounts[username] = passwordHash;

        // Act
        var result = AccountManager.Accounts[username];

        // Assert
        CollectionAssert.AreEqual(passwordHash, result);
    }
}
