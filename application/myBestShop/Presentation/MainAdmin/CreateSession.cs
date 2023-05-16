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
using System.Windows.Media.Animation;

namespace myBestShop.Presentation.MainAdmin
{
    public partial class CreateSession : Form
    {
        public Session MyReturnValue { get; set; } = null;
        public int computerId;

        public CreateSession(List<User> users, int computerId)
        {
            InitializeComponent();
            dataGridView.DataSource = users.ToArray();
            dataGridView.Columns["password"].Visible = false;
            dataGridView.Columns["admin"].Visible = false;
            dataGridView.Columns["passport"].Visible = false;
            dataGridView.Columns["computerId"].Visible = false;

            dataGridView.ClearSelection(); // почемуто не работает)
            dataGridView.CurrentCell = null;

            this.computerId = computerId;
            textBox4.Text = computerId.ToString();
        }

        private void find_Click(object sender, EventArgs e)
        {
            bool assssssssssssssssssssssss = false;
            if (textBox1.Text == "")
            {
                dataGridView.ClearSelection();
                dataGridView.CurrentCell = null;
                return;
            }
            for (int i = 0; i < dataGridView.RowCount; i++)
            {
                dataGridView.Rows[i].Selected = false;
                for (int j = 0; j < dataGridView.ColumnCount; j++)
                    if (dataGridView.Rows[i].Cells[j].Value != null)
                        if (dataGridView.Rows[i].Cells[j].Value.ToString().Contains(textBox1.Text))
                        {
                            dataGridView.Rows[i].Selected = true;
                            dataGridView.CurrentCell = dataGridView.Rows[i].Cells[j];
                            assssssssssssssssssssssss = true;
                            break;
                        }
                if (assssssssssssssssssssssss) break;
                dataGridView.ClearSelection();
                dataGridView.CurrentCell = null;
            }
        }

        private void SaveSessionInDB_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentCell == null)
            {
                MessageBox.Show("Вы не выбрали чела", "ЖЕСТЬ") ;
                return;
            } 
            DateTime start_datetime = DateTime.Now;
            DateTime end_datetime = start_datetime.AddMinutes(Convert.ToDouble(textBox3.Text)).AddHours(Convert.ToDouble(textBox2.Text));
            int ass = Convert.ToInt32(dataGridView[0, dataGridView.CurrentCell.RowIndex].Value);
            int assss = computerId;
            MyReturnValue = new Session(start_datetime, end_datetime, -1, assss, ass);
            this.Close();
        }
    }
}
