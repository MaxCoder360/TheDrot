using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace myBestShop.Presentation.MainClient
{
    public partial class SendMessageToAdmin : Form
    {
        Func<string, Task> action;
        public SendMessageToAdmin(Func<string, Task> sendAction)
        {
            InitializeComponent();
            this.action = sendAction;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            var message = textBox1.Text;
            action(message);
        }
    }
}
