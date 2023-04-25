using myBestShop.Domain.Database;
using myBestShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace myBestShop.Presentation.MainAdmin
{
    public partial class createUser : Form
    {
        DatabaseManager dbManager;
        public createUser()
        {
            InitializeComponent();
            dbManager = DatabaseManager.instance;
        }

        private async void SaveUserInDB_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" &&
                textBox5.Text != "" && textBox7.Text != "")
            {
                User user = new User(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text);
                string result = await dbManager.Main.addUserInDB(user);
                if (result != "OK")
                {
                    const string caption = "ОшиБка";
                    MessageBox.Show(result, caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    this.Close();
                }
            }
            else
            {
                const string message = "Нужно заполнить все поля";
                const string caption = "ОшиБка";
                MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
    }
}
