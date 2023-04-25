using myBestShop.Domain.Database;
using myBestShop.Domain.Database.Delegates;
using myBestShop.Domain.Entities;
using myBestShop.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace myBestShop.Presentation.MainAdmin
{
    public partial class CreateComp : Form
    {
        DatabaseManager dbManager;
        public CreateComp()
        {
            InitializeComponent();
            dbManager = DatabaseManager.instance;
        }

        private async void SaveCompInDB_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" &&
                textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "" && textBox8.Text != "") {
                Computer comp = new Computer(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text, textBox8.Text);
                string result = await dbManager.Main.addComputerInDB(comp);
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
