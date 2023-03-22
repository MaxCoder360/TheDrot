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
            this.labelName = new System.Windows.Forms.Label();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.save = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // deliveryInWork
            // 
            this.deliveryInWork.Location = new System.Drawing.Point(12, 85);
            this.deliveryInWork.Name = "deliveryInWork";
            this.deliveryInWork.Size = new System.Drawing.Size(120, 84);
            this.deliveryInWork.TabIndex = 0;
            this.deliveryInWork.Text = "Просмотр компьтеров";
            this.deliveryInWork.UseVisualStyleBackColor = true;
            this.deliveryInWork.Click += new System.EventHandler(this.deliveryInWork_Click);
            // 
            // deliveryClosed
            // 
            this.deliveryClosed.Location = new System.Drawing.Point(12, 175);
            this.deliveryClosed.Name = "deliveryClosed";
            this.deliveryClosed.Size = new System.Drawing.Size(120, 84);
            this.deliveryClosed.TabIndex = 1;
            this.deliveryClosed.Text = "Редактирование Компьтеров";
            this.deliveryClosed.UseVisualStyleBackColor = true;
            this.deliveryClosed.Click += new System.EventHandler(this.deliveryClosed_Click);
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(26, 20);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(122, 20);
            this.labelName.TabIndex = 2;
            this.labelName.Text = "Здравствуйте,\r\n";
            // 
            // dataGridView
            // 
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(176, 12);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 62;
            this.dataGridView.RowTemplate.Height = 28;
            this.dataGridView.Size = new System.Drawing.Size(1090, 820);
            this.dataGridView.TabIndex = 3;
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(30, 720);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(118, 62);
            this.save.TabIndex = 4;
            this.save.Text = "Сохранить изменения";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.button1_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 265);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 75);
            this.button1.TabIndex = 5;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // MainAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1278, 844);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.save);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.deliveryClosed);
            this.Controls.Add(this.deliveryInWork);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainAdmin";
            this.Text = "ПАНЕЛЬ УПРАВЛЕНИЯ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button deliveryInWork;
        private System.Windows.Forms.Button deliveryClosed;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.Button button1;
    }
}