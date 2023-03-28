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
            this.computerStatusGrid = new System.Windows.Forms.DataGridView();
            this.save = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.computerStatusGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // deliveryInWork
            // 
            this.deliveryInWork.Location = new System.Drawing.Point(3, 54);
            this.deliveryInWork.Margin = new System.Windows.Forms.Padding(2);
            this.deliveryInWork.Name = "deliveryInWork";
            this.deliveryInWork.Size = new System.Drawing.Size(110, 56);
            this.deliveryInWork.TabIndex = 0;
            this.deliveryInWork.Text = "Просмотр компьтеров";
            this.deliveryInWork.UseVisualStyleBackColor = true;
            this.deliveryInWork.Click += new System.EventHandler(this.deliveryInWork_Click);
            // 
            // deliveryClosed
            // 
            this.deliveryClosed.Location = new System.Drawing.Point(3, 114);
            this.deliveryClosed.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.deliveryClosed.Name = "deliveryClosed";
            this.deliveryClosed.Size = new System.Drawing.Size(110, 55);
            this.deliveryClosed.TabIndex = 1;
            this.deliveryClosed.Text = "Редактирование Компьтеров";
            this.deliveryClosed.UseVisualStyleBackColor = true;
            this.deliveryClosed.Click += new System.EventHandler(this.deliveryClosed_Click);
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(17, 13);
            this.labelName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(80, 13);
            this.labelName.TabIndex = 2;
            this.labelName.Text = "Здравствуйте,\r\n";
            // 
            // computerStatusGrid
            // 
            this.computerStatusGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.computerStatusGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.computerStatusGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.computerStatusGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.computerStatusGrid.Location = new System.Drawing.Point(117, 8);
            this.computerStatusGrid.Margin = new System.Windows.Forms.Padding(2);
            this.computerStatusGrid.Name = "computerStatusGrid";
            this.computerStatusGrid.RowHeadersWidth = 62;
            this.computerStatusGrid.RowTemplate.Height = 28;
            this.computerStatusGrid.Size = new System.Drawing.Size(727, 533);
            this.computerStatusGrid.TabIndex = 3;
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(3, 478);
            this.save.Margin = new System.Windows.Forms.Padding(2);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(110, 63);
            this.save.TabIndex = 4;
            this.save.Text = "Сохранить изменения";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.button1_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 173);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(110, 49);
            this.button1.TabIndex = 5;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // MainAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 549);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.save);
            this.Controls.Add(this.computerStatusGrid);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.deliveryClosed);
            this.Controls.Add(this.deliveryInWork);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainAdmin";
            this.Text = "ПАНЕЛЬ УПРАВЛЕНИЯ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_FormClosing);
            this.Load += new System.EventHandler(this.MainAdmin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.computerStatusGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button deliveryInWork;
        private System.Windows.Forms.Button deliveryClosed;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.DataGridView computerStatusGrid;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.Button button1;
    }
}