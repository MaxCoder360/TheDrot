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
            this.tables_box = new System.Windows.Forms.ComboBox();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.labelName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // tables_box
            // 
            this.tables_box.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tables_box.FormattingEnabled = true;
            this.tables_box.Items.AddRange(new object[] {
            "discount",
            "imac",
            "imacbook",
            "iphone",
            "office",
            "order",
            "order_composition",
            "product",
            "сlient"});
            this.tables_box.Location = new System.Drawing.Point(7, 153);
            this.tables_box.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tables_box.Name = "tables_box";
            this.tables_box.Size = new System.Drawing.Size(149, 28);
            this.tables_box.TabIndex = 17;
            this.tables_box.TextChanged += new System.EventHandler(this.tables_box_TextChanged);
            // 
            // dataGridView
            // 
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(162, 14);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 62;
            this.dataGridView.RowTemplate.Height = 28;
            this.dataGridView.Size = new System.Drawing.Size(1090, 820);
            this.dataGridView.TabIndex = 15;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(12, 22);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(122, 20);
            this.labelName.TabIndex = 14;
            this.labelName.Text = "Здравствуйте,\r\n";
            // 
            // MainClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1265, 849);
            this.Controls.Add(this.tables_box);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.labelName);
            this.Name = "MainClient";
            this.Text = "MainClient";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox tables_box;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Label labelName;
    }
}