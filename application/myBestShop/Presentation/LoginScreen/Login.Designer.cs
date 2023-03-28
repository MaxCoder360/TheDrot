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
            this.label1 = new System.Windows.Forms.Label();
            this.label_login = new System.Windows.Forms.Label();
            this.label_password = new System.Windows.Forms.Label();
            this.text_login = new System.Windows.Forms.TextBox();
            this.text_password = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.label1.Location = new System.Drawing.Point(27, 54);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(339, 22);
            this.label1.TabIndex = 1;
            this.label1.Text = "САМЫЙ ЛУЧШИЙ КОМПКЛАБ TheDrot";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label_login
            // 
            this.label_login.AutoSize = true;
            this.label_login.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label_login.Location = new System.Drawing.Point(51, 148);
            this.label_login.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_login.Name = "label_login";
            this.label_login.Size = new System.Drawing.Size(69, 20);
            this.label_login.TabIndex = 2;
            this.label_login.Text = "ЛОГИН:";
            // 
            // label_password
            // 
            this.label_password.AutoSize = true;
            this.label_password.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label_password.Location = new System.Drawing.Point(41, 201);
            this.label_password.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_password.Name = "label_password";
            this.label_password.Size = new System.Drawing.Size(80, 20);
            this.label_password.TabIndex = 3;
            this.label_password.Text = "ПАРОЛЬ:";
            // 
            // text_login
            // 
            this.text_login.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.text_login.Location = new System.Drawing.Point(123, 146);
            this.text_login.Margin = new System.Windows.Forms.Padding(2);
            this.text_login.Name = "text_login";
            this.text_login.Size = new System.Drawing.Size(215, 26);
            this.text_login.TabIndex = 4;
            // 
            // text_password
            // 
            this.text_password.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.text_password.Location = new System.Drawing.Point(123, 199);
            this.text_password.Margin = new System.Windows.Forms.Padding(2);
            this.text_password.Name = "text_password";
            this.text_password.PasswordChar = '*';
            this.text_password.Size = new System.Drawing.Size(215, 26);
            this.text_password.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.button1.Location = new System.Drawing.Point(123, 282);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(143, 30);
            this.button1.TabIndex = 6;
            this.button1.Text = "Войти";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // LoginScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 366);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.text_password);
            this.Controls.Add(this.text_login);
            this.Controls.Add(this.label_password);
            this.Controls.Add(this.label_login);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "LoginScreen";
            this.Text = "АВТОРИЗАЦИЯ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button login;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_login;
        private System.Windows.Forms.Label label_password;
        private System.Windows.Forms.TextBox text_login;
        private System.Windows.Forms.TextBox text_password;
        private System.Windows.Forms.Button button1;
    }
}

