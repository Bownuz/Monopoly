using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChatServerApplicatie.ChatRoom;
using System.Collections.Generic;

[TestClass]
public class LobbyManagerTests {
    [TestMethod]
    public void AddUserToLobby_ShouldAddUserToNewLobby() {
        // Arrange
        string lobbyName = "TestLobby";
        string username = "TestUser";

        // Act
        LobbyManager.AddUserToLobby(lobbyName, username);

        // Assert
        var lobby = LobbyManager.GetLobbies()[lobbyName];
        Assert.IsTrue(lobby.members.Contains(username));
    }

    [TestMethod]
    public void RemoveUserFromLobby_ShouldRemoveUser() {
        // Arrange
        string lobbyName = "TestLobby";
        string username = "TestUser";
        LobbyManager.AddUserToLobby(lobbyName, username);

        // Act
        LobbyManager.RemoveUserFromLobby(lobbyName, username);

        // Assert
        var lobby = LobbyManager.GetLobbies()[lobbyName];
        Assert.IsFalse(lobby.members.Contains(username));
    }

    [TestMethod]
    public void GetLobbyNames_ShouldReturnCorrectLobbyNames() {
        // Arrange
        LobbyManager.GetOrCreateLobby("Lobby1");

        // Act
        var lobbyNames = LobbyManager.GetLobbyNames();

        // Assert
        Assert.IsTrue(lobbyNames.Contains("Lobby1"));
    }
}
