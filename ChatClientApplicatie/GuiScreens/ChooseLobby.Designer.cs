namespace ChatClientApplicatie {
    partial class ChooseLobby {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            messageListBox = new ListBox();
            sendMessageButton = new Button();
            inputTextBox = new TextBox();
            SuspendLayout();
            // 
            // messageListBox
            // 
            messageListBox.FormattingEnabled = true;
            messageListBox.ItemHeight = 15;
            messageListBox.Location = new Point(15, 28);
            messageListBox.Name = "messageListBox";
            messageListBox.Size = new Size(120, 94);
            messageListBox.TabIndex = 2;
            // 
            // sendMessageButton
            // 
            sendMessageButton.Location = new Point(336, 241);
            sendMessageButton.Name = "sendMessageButton";
            sendMessageButton.Size = new Size(75, 23);
            sendMessageButton.TabIndex = 3;
            sendMessageButton.Text = "Submit";
            sendMessageButton.UseVisualStyleBackColor = true;
            // 
            // inputTextBox
            // 
            inputTextBox.Location = new Point(107, 221);
            inputTextBox.Name = "inputTextBox";
            inputTextBox.Size = new Size(100, 23);
            inputTextBox.TabIndex = 4;
            // 
            // ChooseLobby
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(inputTextBox);
            Controls.Add(sendMessageButton);
            Controls.Add(messageListBox);
            Name = "ChooseLobby";
            Size = new Size(747, 505);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox messageListBox;
        private Button sendMessageButton;
        private TextBox inputTextBox;
    }
}
