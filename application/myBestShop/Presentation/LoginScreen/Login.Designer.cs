namespace myBestShop
{
    partial class LoginScreen
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.TheDrotTitle = new System.Windows.Forms.Label();
            this.loginLabel = new System.Windows.Forms.Label();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.loginField = new System.Windows.Forms.TextBox();
            this.passwordField = new System.Windows.Forms.TextBox();
            this.loginButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TheDrotTitle
            // 
            this.TheDrotTitle.AutoSize = true;
            this.TheDrotTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.TheDrotTitle.Location = new System.Drawing.Point(27, 54);
            this.TheDrotTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TheDrotTitle.Name = "TheDrotTitle";
            this.TheDrotTitle.Size = new System.Drawing.Size(339, 22);
            this.TheDrotTitle.TabIndex = 1;
            this.TheDrotTitle.Text = "САМЫЙ ЛУЧШИЙ КОМПКЛАБ TheDrot";
            this.TheDrotTitle.Click += new System.EventHandler(this.label1_Click);
            // 
            // loginLabel
            // 
            this.loginLabel.AutoSize = true;
            this.loginLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.loginLabel.Location = new System.Drawing.Point(51, 148);
            this.loginLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.loginLabel.Name = "loginLabel";
            this.loginLabel.Size = new System.Drawing.Size(69, 20);
            this.loginLabel.TabIndex = 2;
            this.loginLabel.Text = "ЛОГИН:";
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.passwordLabel.Location = new System.Drawing.Point(41, 201);
            this.passwordLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(80, 20);
            this.passwordLabel.TabIndex = 3;
            this.passwordLabel.Text = "ПАРОЛЬ:";
            // 
            // loginField
            // 
            this.loginField.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.loginField.Location = new System.Drawing.Point(123, 146);
            this.loginField.Margin = new System.Windows.Forms.Padding(2);
            this.loginField.Name = "loginField";
            this.loginField.Size = new System.Drawing.Size(215, 26);
            this.loginField.TabIndex = 4;
            // 
            // passwordField
            // 
            this.passwordField.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.passwordField.Location = new System.Drawing.Point(123, 199);
            this.passwordField.Margin = new System.Windows.Forms.Padding(2);
            this.passwordField.Name = "passwordField";
            this.passwordField.PasswordChar = '*';
            this.passwordField.Size = new System.Drawing.Size(215, 26);
            this.passwordField.TabIndex = 5;
            // 
            // loginButton
            // 
            this.loginButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.loginButton.Location = new System.Drawing.Point(123, 282);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(143, 30);
            this.loginButton.TabIndex = 6;
            this.loginButton.Text = "Войти";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // LoginScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 366);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.passwordField);
            this.Controls.Add(this.loginField);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.loginLabel);
            this.Controls.Add(this.TheDrotTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "LoginScreen";
            this.Text = "АВТОРИЗАЦИЯ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button login;
        private System.Windows.Forms.Label TheDrotTitle;
        private System.Windows.Forms.Label loginLabel;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.TextBox loginField;
        private System.Windows.Forms.TextBox passwordField;
        private System.Windows.Forms.Button loginButton;
    }
}

