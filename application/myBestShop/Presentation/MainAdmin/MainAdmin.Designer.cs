namespace myBestShop
{
    partial class MainAdmin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.deliveryInWork = new System.Windows.Forms.Button();
            this.deliveryClosed = new System.Windows.Forms.Button();
            this.save = new System.Windows.Forms.Button();
            this.add_User = new System.Windows.Forms.Button();
            this.add_comp = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // deliveryInWork
            // 
            this.deliveryInWork.Location = new System.Drawing.Point(4, 5);
            this.deliveryInWork.Name = "deliveryInWork";
            this.deliveryInWork.Size = new System.Drawing.Size(165, 86);
            this.deliveryInWork.TabIndex = 0;
            this.deliveryInWork.Text = "Просмотр компьтеров";
            this.deliveryInWork.UseVisualStyleBackColor = true;
            this.deliveryInWork.Click += new System.EventHandler(this.deliveryInWork_Click);
            // 
            // deliveryClosed
            // 
            this.deliveryClosed.Location = new System.Drawing.Point(4, 94);
            this.deliveryClosed.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.deliveryClosed.Name = "deliveryClosed";
            this.deliveryClosed.Size = new System.Drawing.Size(165, 85);
            this.deliveryClosed.TabIndex = 1;
            this.deliveryClosed.Text = "Редактирование Компьтеров";
            this.deliveryClosed.UseVisualStyleBackColor = true;
            this.deliveryClosed.Click += new System.EventHandler(this.deliveryClosed_Click);
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(4, 735);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(165, 97);
            this.save.TabIndex = 4;
            this.save.Text = "Сохранить изменения";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.button1_Click);
            // 
            // add_User
            // 
            this.add_User.Location = new System.Drawing.Point(4, 182);
            this.add_User.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.add_User.Name = "add_User";
            this.add_User.Size = new System.Drawing.Size(165, 85);
            this.add_User.TabIndex = 5;
            this.add_User.Text = "Добовление пользователя";
            this.add_User.UseVisualStyleBackColor = true;
            this.add_User.Click += new System.EventHandler(this.add_User_Click);
            // 
            // add_comp
            // 
            this.add_comp.Location = new System.Drawing.Point(4, 270);
            this.add_comp.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.add_comp.Name = "add_comp";
            this.add_comp.Size = new System.Drawing.Size(165, 85);
            this.add_comp.TabIndex = 6;
            this.add_comp.Text = "Добовление компьтера";
            this.add_comp.UseVisualStyleBackColor = true;
            this.add_comp.Click += new System.EventHandler(this.add_comp_Click);
            // 
            // MainAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1278, 845);
            this.Controls.Add(this.add_comp);
            this.Controls.Add(this.add_User);
            this.Controls.Add(this.save);
            this.Controls.Add(this.deliveryClosed);
            this.Controls.Add(this.deliveryInWork);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainAdmin";
            this.Text = "ПАНЕЛЬ УПРАВЛЕНИЯ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_FormClosing);
            this.Load += new System.EventHandler(this.MainAdmin_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button deliveryInWork;
        private System.Windows.Forms.Button deliveryClosed;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.Button add_User;
        private System.Windows.Forms.Button add_comp;
    }
}