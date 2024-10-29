using ChatClientApplicatie.GuiScreens;
using ChatClientApplicatie.State;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Sockets;

[TestClass]
public class DataProtocolTests {
    private Handler handler;
    private DataProtocol dataProtocol;

    [TestInitialize]
    public void Setup() {
        handler = new Handler(new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp), "TestUser", "TestPassword", new ScreenManager(new Form()));
        dataProtocol = new DataProtocol(handler);
    }

    [TestMethod]
    public void ProcessInput_ShouldReturnExpectedResponse_OnLoginState() {
        // Arrange
        string input = "Send userName";

        // Act
        string result = dataProtocol.processInput(input);

        // Assert
        Assert.AreEqual(handler.GetClientInfoAsJson(), result);
    }

    [TestMethod]
    public void ChangeState_ShouldSwitchToNewState() {
        // Arrange
        var newState = new SearchLobby(dataProtocol, handler);

        // Act
        dataProtocol.ChangeState(newState);

        // Assert
        Assert.IsInstanceOfType(dataProtocol.CurrentState, typeof(SearchLobby));
    }
}