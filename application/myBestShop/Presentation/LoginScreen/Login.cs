using myBestShop.Domain.Repository;
using myBestShop.Utils;
using myBestShop.DependencyBuilders;
using MySql.Data.MySqlClient;
using System;
using System.Text;
using System.Windows.Forms;

namespace myBestShop
{
    public partial class LoginScreen : Form
    {
        private UserRepository repository;
        public LoginScreen()
        {
            InitializeComponent();

            var config = DomainModule.createRepositoryConfig(AppConfig.BUILD_CONFIG, UserTypeExt.UserType.USER);
            repository = (UserRepository)DomainModule.createRepository(config);

            addObservers();
        }

        private void addObservers()
        {
            repository.addObserver(new LoginObserver(onLoginSuccessful), UserRepository.loginTag);
        }

        private object onLoginSuccessful(object o)
        {
            MainAdmin adminScreen = new MainAdmin();
            adminScreen.Show();

            // Close();

            return null;
        }

        private void login_Click(object sender, EventArgs e)
        {
            // cannot remove it
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // cannot remove it
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var loginHandler = new LoginHolder(loginField.Text, passwordField.Text);
            await repository.logInUser(loginHandler);
        }

        public class LoginObserver : Observer
        {
            private Func<object, object> onLogin;

            public LoginObserver(Func<object, object> onLogin)
            {
                this.onLogin = onLogin;
            }

            public void handleResult<ResultT>(Result<ResultT> result) where ResultT : class
            {
                if (result == null)
                {
                    Logger.println("Login screen: smth went wrong");
                    return;
                }
                if (result.isError)
                {
                    Logger.print("Login screen: ");
                    Logger.println(result.exception.ToString());
                }
                if (result.isLoading)
                {
                    Logger.println("Login screen is loading");
                }
                if (result.data != null)
                {
                    Logger.print("Login screen current data is ");
                    Logger.println(result.data.ToString());

                    onLogin(result.data);
                } else
                {
                    Logger.println("Login screen: invalid result data");
                }
            }
        }
    }
}
