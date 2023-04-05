using System;
using System.Windows.Forms;

namespace myBestShop
{
    public partial class MainClient : Form
    {
        public MainClient()
        {
            InitializeComponent();
            // todo при открытии формы изменять labelName на имя человека который авторизовался
            labelName.Text += "Краев Максим Максимович";

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
    }
}
