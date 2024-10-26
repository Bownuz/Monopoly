namespace ChatClientApplicatie {
    partial class SignInScreen {
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
            UsernameTextBox = new TextBox();
            PasswordTextBox = new TextBox();
            UsernameLabel = new Label();
            PasswordLabel = new Label();
            SubmitButton = new Button();
            CreateAcount = new Button();
            SuspendLayout();
            // 
            // UsernameTextBox
            // 
            UsernameTextBox.Location = new Point(263, 129);
            UsernameTextBox.Name = "UsernameTextBox";
            UsernameTextBox.Size = new Size(100, 23);
            UsernameTextBox.TabIndex = 0;
            // 
            // PasswordTextBox
            // 
            PasswordTextBox.Location = new Point(263, 169);
            PasswordTextBox.Name = "PasswordTextBox";
            PasswordTextBox.Size = new Size(100, 23);
            PasswordTextBox.TabIndex = 1;
            // 
            // UsernameLabel
            // 
            UsernameLabel.AutoSize = true;
            UsernameLabel.Location = new Point(185, 137);
            UsernameLabel.Name = "UsernameLabel";
            UsernameLabel.Size = new Size(63, 15);
            UsernameLabel.TabIndex = 2;
            UsernameLabel.Text = "Username:";
            UsernameLabel.Click += label1_Click;
            // 
            // PasswordLabel
            // 
            PasswordLabel.AutoSize = true;
            PasswordLabel.Location = new Point(188, 177);
            PasswordLabel.Name = "PasswordLabel";
            PasswordLabel.Size = new Size(60, 15);
            PasswordLabel.TabIndex = 3;
            PasswordLabel.Text = "Password:";
            // 
            // SubmitButton
            // 
            SubmitButton.Location = new Point(173, 228);
            SubmitButton.Name = "SubmitButton";
            SubmitButton.Size = new Size(75, 23);
            SubmitButton.TabIndex = 4;
            SubmitButton.Text = "Submit";
            SubmitButton.UseVisualStyleBackColor = true;
            SubmitButton.Click += SubmitButton_Click;
            // 
            // CreateAcount
            // 
            CreateAcount.Location = new Point(263, 228);
            CreateAcount.Name = "CreateAcount";
            CreateAcount.Size = new Size(124, 23);
            CreateAcount.TabIndex = 5;
            CreateAcount.Text = "Create Acount";
            CreateAcount.UseVisualStyleBackColor = true;
            CreateAcount.Click += CreateAcount_Click;
            // 
            // UserControl1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(CreateAcount);
            Controls.Add(SubmitButton);
            Controls.Add(PasswordLabel);
            Controls.Add(UsernameLabel);
            Controls.Add(PasswordTextBox);
            Controls.Add(UsernameTextBox);
            Name = "UserControl1";
            Size = new Size(669, 568);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox UsernameTextBox;
        private TextBox PasswordTextBox;
        private Label UsernameLabel;
        private Label PasswordLabel;
        private Button SubmitButton;
        private Button CreateAcount;
    }
}
