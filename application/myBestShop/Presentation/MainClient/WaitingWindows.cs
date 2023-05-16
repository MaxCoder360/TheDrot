using myBestShop.Domain.Entities;
using myBestShop.Domain.Repository;
using myBestShop.Utils;
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
    public partial class WaitingWindows : Form
    {
        private Session sess;
        private Form parent;
        private UserRepository repository;
        public WaitingWindows(Form perent, Session sess)
        {
            this.parent = perent;
            InitializeComponent();
            this.sess = sess;
            label1.Text = sess.name + ' ' + sess.surname;
            var repositoryConfig = DependencyBuilders.DomainModule.createRepositoryConfig(AppConfig.BUILD_CONFIG, UserTypeExt.UserType.USER);
            repository = (UserRepository)DependencyBuilders.DomainModule.createRepository(repositoryConfig);
        }

        private void WaitingWindows_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoginHolder login = new LoginHolder(sess.login, textBox1.Text);
            Task.Run(async () =>
            {
                var kek = await repository.dbManager.Login.getUserSessionKeyByLogin(login);
                if (kek != null)
                {
                    this.Invoke(new Action(() => { this.Close(); }));
                }
                else
                { MessageBox.Show("Не правельный пароль", "НеДо ошибка",MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
            });

        }
    }
}
