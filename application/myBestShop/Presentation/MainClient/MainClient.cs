using myBestShop.Domain.Repository;
using myBestShop.Domain.WebService;
using myBestShop.Presentation.MainClient.Observers;
using myBestShop.Utils;
using System;
using System.Windows.Forms;
using System.Threading.Tasks;
using myBestShop.Presentation.MainClient;
using myBestShop.Domain.Entities;

namespace myBestShop
{
    public partial class MainClient : Form
    {
        private Form parent;
        private UserRepository repository;
        private int computerId;

        // observers
        private SessionKeyObserver sessionKeyObserver;
        public MainClient(Form parent, Session sess)
        {
            InitializeComponent();
            this.parent = parent;
            this.computerId = sess.id_user;
            labelName.Text += sess.name + " " + sess.surname;

            var repositoryConfig = DependencyBuilders.DomainModule.createRepositoryConfig(AppConfig.BUILD_CONFIG, UserTypeExt.UserType.USER);
            repository = (UserRepository)DependencyBuilders.DomainModule.createRepository(repositoryConfig);

            Task.Run(async () => {
                await repository.updateStatusOnAdminSide(computerId, ComputerStatus.UNAVAILABLE);
            });

            // получение времени из бд для пользователя
            Value_time = (long)(sess.end_time_rent - DateTime.Now).TotalSeconds;
            label_pass_time.Text = Int2StringTime(Value_time);
            timer_pass_time = new Timer();
            timer_pass_time.Tick += new EventHandler(tm_Tick);
            timer_pass_time.Interval = 1000;
            timer_pass_time.Start();
        }

        long Value_time = 0;
        private string Int2StringTime(long time)
        {
            long hours = (time - (time % (60 * 60))) / (60 * 60);
            long minutes = (time - time % 60) / 60 - hours * 60;
            long seconds = time % 60;
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
            SendMessageToAdmin sendMessageForm = new SendMessageToAdmin(async (message) => {
                await repository.sendMessageToAdmin(message, computerId);
            });

            sendMessageForm.Show();
        }

        private void button_exit_Click(object sender, EventArgs e)
        {
            Task.Run(async () => {
                await repository.updateStatusOnAdminSide(computerId, ComputerStatus.AVAILABLE);
            });
            parent.Show();
            Program.isLogined = false;
        }

        private void MainClient_Load(object sender, EventArgs e)
        {

        }
    }
}
