using ChatClientApplicatie.GuiScreens;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class ScreenManagerTests {
    [TestMethod]
    public void ChangeScreen_ShouldClearAndAddNewScreen() {
        // Arrange
        Form form = new Form();
        ScreenManager screenManager = new ScreenManager(form);
        UserControl initialScreen = new UserControl();
        form.Controls.Add(initialScreen);
        UserControl newScreen = new UserControl();

        // Act
        screenManager.ChangeScreen(newScreen);

        // Assert
        Assert.AreEqual(1, form.Controls.Count);  // Check dat er slechts één controle is
        Assert.IsTrue(form.Controls.Contains(newScreen));
    }
}