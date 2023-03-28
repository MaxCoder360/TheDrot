using myBestShop.Utils;
using MySql.Data.MySqlClient;
using System;
using System.Text;
using System.Windows.Forms;

namespace myBestShop
{
    public partial class LoginScreen : Form, Observer
    {
        public LoginScreen()
        {
            InitializeComponent();
        }

        private void login_Click(object sender, EventArgs e)
        {
            string userLogin = text_login.Text;
            string userPass = text_password.Text;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        public void handleResult<T>(Result<T> result)
        {
            throw new NotImplementedException();
        }
    }
}
