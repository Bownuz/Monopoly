namespace ChatApplicatie {
    partial class LoggingScreen {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            inputTextBox = new TextBox();
            messageListBox = new ListBox();
            sendMessageButton = new Button();
            SuspendLayout();
            // 
            // inputTextBox
            // 
            inputTextBox.Location = new Point(137, 255);
            inputTextBox.Name = "inputTextBox";
            inputTextBox.Size = new Size(100, 23);
            inputTextBox.TabIndex = 0;
            // 
            // messageListBox
            // 
            messageListBox.FormattingEnabled = true;
            messageListBox.ItemHeight = 15;
            messageListBox.Location = new Point(117, 155);
            messageListBox.Name = "messageListBox";
            messageListBox.Size = new Size(120, 94);
            messageListBox.TabIndex = 1;
            // 
            // sendMessageButton
            // 
            sendMessageButton.Location = new Point(283, 255);
            sendMessageButton.Name = "sendMessageButton";
            sendMessageButton.Size = new Size(75, 23);
            sendMessageButton.TabIndex = 2;
            sendMessageButton.Text = "Submit";
            sendMessageButton.UseVisualStyleBackColor = true;
            // 
            // LoggingScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(sendMessageButton);
            Controls.Add(messageListBox);
            Controls.Add(inputTextBox);
            Name = "LoggingScreen";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox inputTextBox;
        private ListBox messageListBox;
        private Button sendMessageButton;
    }
}
