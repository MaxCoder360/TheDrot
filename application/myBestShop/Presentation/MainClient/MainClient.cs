using myBestShop.Domain.Repository;
using myBestShop.Domain.WebService;
using myBestShop.Presentation.MainClient.Observers;
using myBestShop.Utils;
using System;
using System.Windows.Forms;

namespace myBestShop
{
    public partial class MainClient : Form
    {
        private Form parent;
        private UserRepository repository;

        // observers
        private SessionKeyObserver sessionKeyObserver;
        public MainClient(Form parent)
        {
            InitializeComponent();
            // todo при открытии формы изменять labelName на имя человека который авторизовался
            labelName.Text += "Краев Максим Максимович";
            this.parent = parent;

            var repositoryConfig = DependencyBuilders.DomainModule.createRepositoryConfig(AppConfig.BUILD_CONFIG, UserTypeExt.UserType.USER);
            repository = (UserRepository)DependencyBuilders.DomainModule.createRepository(repositoryConfig);

            // получение времени из бд для пользователя
            Value_time = 3712;
            label_pass_time.Text = Int2StringTime(Value_time);
            timer_pass_time = new Timer();
            timer_pass_time.Tick += new EventHandler(tm_Tick);
            timer_pass_time.Interval = 1000;
            timer_pass_time.Start();
        }

        int Value_time = 0;
        private string Int2StringTime(int time)
        {
            int hours = (time - (time % (60 * 60))) / (60 * 60);
            int minutes = (time - time % 60) / 60 - hours * 60;
            int seconds = time % 60;
            return String.Format("{0:00} ч. {1:00} м. {2:00} с.", hours, minutes, seconds);
        }

        private object onSessionKeyObtained(int sessionKey)
        {

            return null;
        }

        void tm_Tick(object sender, EventArgs e)
        {
            if (Value_time != 0)
            {
                label_pass_time.Text = Int2StringTime(Value_time);
                Value_time--;
            }
            else
            {
                (sender as Timer).Stop();
                (sender as Timer).Dispose();
            }
        }

        private void button_pause_Click(object sender, EventArgs e)
        {
            if (this.timer_pass_time.Enabled)
            {
                this.timer_pass_time.Stop();
            } else
            {
                this.timer_pass_time.Start();
            }
        }

        private void button_call_admin_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Администратор сейчас подойдет к Вам!");
        }

        private void button_exit_Click(object sender, EventArgs e)
        {
            parent.Show();
            this.Close();
        }

        private void MainClient_Load(object sender, EventArgs e)
        {

        }
    }
}
