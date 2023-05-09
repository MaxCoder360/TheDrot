namespace myBestShop
{
    partial class MainClient
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
            this.components = new System.ComponentModel.Container();
            this.labelName = new System.Windows.Forms.Label();
            this.timer_pass_time = new System.Windows.Forms.Timer(this.components);
            this.label_on_time = new System.Windows.Forms.Label();
            this.label_pass_time = new System.Windows.Forms.Label();
            this.button_pause = new System.Windows.Forms.Button();
            this.button_call_admin = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelName.Location = new System.Drawing.Point(11, 25);
            this.labelName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(126, 20);
            this.labelName.TabIndex = 14;
            this.labelName.Text = "Здравствуйте, ";
            // 
            // label_on_time
            // 
            this.label_on_time.AutoSize = true;
            this.label_on_time.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label_on_time.Location = new System.Drawing.Point(131, 25);
            this.label_on_time.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_on_time.Name = "label_on_time";
            this.label_on_time.Size = new System.Drawing.Size(153, 20);
            this.label_on_time.TabIndex = 15;
            this.label_on_time.Text = "осталось времени:";
            // 
            // label_pass_time
            // 
            this.label_pass_time.AutoSize = true;
            this.label_pass_time.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label_pass_time.Location = new System.Drawing.Point(301, 25);
            this.label_pass_time.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_pass_time.Name = "label_pass_time";
            this.label_pass_time.Size = new System.Drawing.Size(59, 20);
            this.label_pass_time.TabIndex = 16;
            this.label_pass_time.Text = "TIMER";
            // 
            // button_pause
            // 
            this.button_pause.Location = new System.Drawing.Point(11, 89);
            this.button_pause.Margin = new System.Windows.Forms.Padding(2);
            this.button_pause.Name = "button_pause";
            this.button_pause.Size = new System.Drawing.Size(184, 58);
            this.button_pause.TabIndex = 17;
            this.button_pause.Text = "Поставить на паузу";
            this.button_pause.UseVisualStyleBackColor = true;
            this.button_pause.Click += new System.EventHandler(this.button_pause_Click);
            // 
            // button_call_admin
            // 
            this.button_call_admin.Location = new System.Drawing.Point(360, 89);
            this.button_call_admin.Margin = new System.Windows.Forms.Padding(2);
            this.button_call_admin.Name = "button_call_admin";
            this.button_call_admin.Size = new System.Drawing.Size(184, 58);
            this.button_call_admin.TabIndex = 18;
            this.button_call_admin.Text = "Вызвать админа";
            this.button_call_admin.UseVisualStyleBackColor = true;
            this.button_call_admin.Click += new System.EventHandler(this.button_call_admin_Click);
            // 
            // MainClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 180);
            this.Controls.Add(this.button_call_admin);
            this.Controls.Add(this.button_pause);
            this.Controls.Add(this.label_pass_time);
            this.Controls.Add(this.label_on_time);
            this.Controls.Add(this.labelName);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainClient";
            this.Text = "MainClient";
            this.Load += new System.EventHandler(this.MainClient_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Timer timer_pass_time;
        private System.Windows.Forms.Label label_on_time;
        private System.Windows.Forms.Label label_pass_time;
        private System.Windows.Forms.Button button_pause;
        private System.Windows.Forms.Button button_call_admin;
    }
}