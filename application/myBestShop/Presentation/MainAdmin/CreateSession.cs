using myBestShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace myBestShop.Presentation.MainAdmin
{
    public partial class CreateSession : Form
    {
        public CreateSession(List<User> users)
        {
            InitializeComponent();
            dataGridView.DataSource = users.ToArray();
            dataGridView.CurrentCell = null;
            dataGridView.Columns["password"].Visible = false;
            dataGridView.Columns["admin"].Visible = false;
            dataGridView.Columns["passport"].Visible = false;
            dataGridView.Columns["computerId"].Visible = false;
        }

        private void find_Click(object sender, EventArgs e)
        {
            dataGridView.DefaultCellStyle.BackColor = Color.White;
            for (int i = 0; i < dataGridView.RowCount; i++)
            {
                dataGridView.Rows[i].Selected = false;
                for (int j = 0; j < dataGridView.ColumnCount; j++)
                    if (dataGridView.Rows[i].Cells[j].Value != null)
                        if (dataGridView.Rows[i].Cells[j].Value.ToString().Contains(textBox1.Text))
                        {
                            dataGridView.Rows[i].Selected = true;
                            dataGridView.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                            
                            break;
                        }
                dataGridView.CurrentCell = null;
            }


        }
    }
}
