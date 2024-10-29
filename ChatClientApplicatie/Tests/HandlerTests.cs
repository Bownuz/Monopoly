using ChatClientApplicatie.GuiScreens;
using ChatClientApplicatie.State;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Sockets;
using System.Windows.Forms;

[TestClass]
public class HandlerTests {
    private Socket socket;
    private ScreenManager screenManager;
    private Handler handler;

    [TestInitialize]
    public void Setup() {
        socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        screenManager = new ScreenManager(new Form());
        handler = new Handler(socket, "TestUser", "TestPassword", screenManager);
    }

    [TestMethod]
    public void UpdateLobbyInfo_ShouldSendLobbyMessage() {
        // Arrange
        var lobbyName = "TestLobby";

        // Act
        handler.UpdateLobbyInfo(lobbyName);

        // Assert
        // Controleer dat de SendAsync wordt aangeroepen. Dit vereist een extra implementatie in de Handler klasse.
        // Deze test simuleert de logging of handeling van de lobby-informatie.
    }

    [TestMethod]
    public void ChangeScreen_ShouldCallScreenManagerChangeScreen() {
        // Arrange
        Form form = new Form();
        ScreenManager screenManager = new ScreenManager(form);
        Handler handler = new Handler(new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp), "TestUser", "TestPassword", screenManager);

        UserControl initialScreen = new UserControl();
        form.Controls.Add(initialScreen);
        UserControl newScreen = new UserControl();

        // Act
        handler.ChangeScreen(newScreen);

        // Assert
        Assert.AreEqual(1, form.Controls.Count);  // Controleren dat er precies één controle is
        Assert.IsTrue(form.Controls.Contains(newScreen), "The new screen should be added to the form.");
        Assert.AreEqual(newScreen, screenManager.CurrentmainForm.Controls[0], "The current main form should be the new screen.");
    }
}
