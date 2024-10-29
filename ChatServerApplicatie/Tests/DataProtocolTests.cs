using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChatServerApplicatie.ProtocolState;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using ChatServerApplicatie.ChatRoom;
using System.Security.Cryptography;

[TestClass]
public class DataProtocolTests {
    private DataProtocol dataProtocol;
    private Socket testSocket;

    [TestInitialize]
    public void Setup() {
        dataProtocol = new DataProtocol();
        testSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        LobbyManager.ClearLobbies();
        LobbyManager.GetOrCreateLobby("Lobby1");
        LobbyManager.GetOrCreateLobby("Lobby2");

    }

    [TestMethod]
    public void ProcessInput_ShouldReturnLobbyList_OnSuccessfulLogin() {
        // Arrange
        var loginData = JsonSerializer.Serialize(new {
            name = "TestUser",
            passwdHash = SHA512.HashData(Encoding.UTF8.GetBytes("password")),
            createAcount = true
        });
        //act
        var response = dataProtocol.processInput(loginData, testSocket);

        // Assert
        // Verifieer dat de response niet null is
        Assert.IsNotNull(response, "Response should not be null.");

        // Verwachte lobby lijst in JSON-formaat
        var expectedLobbies = JsonSerializer.Serialize(new List<string> { "Lobby1", "Lobby2" });

        // Controleer of de response overeenkomt met de verwachte JSON-string
        Assert.AreEqual(expectedLobbies, response, "Expected a JSON list of available lobbies.");
    }

    [TestMethod]
    public void ChangeState_ShouldSwitchToSearchLobby() {
        // Arrange
        var newState = new SearchLobby(dataProtocol, "TestUser");

        // Act
        dataProtocol.ChangeState(newState);

        // Assert
        Assert.IsInstanceOfType(dataProtocol.CurrentState, typeof(SearchLobby));
    }

    [TestMethod]
    public void ChangeState_ShouldSwitchToChatState() {
        // Arrange
        var lobby = LobbyManager.GetOrCreateLobby("TestLobby");
        var newState = new Chat(dataProtocol, lobby, "TestUser");

        // Act
        dataProtocol.ChangeState(newState);

        // Assert
        Assert.IsInstanceOfType(dataProtocol.CurrentState, typeof(Chat));
    }
}
