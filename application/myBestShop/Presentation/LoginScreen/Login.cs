using myBestShop.Domain.Repository;
using myBestShop.Utils;
using myBestShop.DependencyBuilders;
using System;
using System.Text;
using System.Windows.Forms;
using static myBestShop.Domain.Database.Delegates.LoginDbDelegate;
using WebSocketSharp.Server;
using static myBestShop.Utils.Utils;

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
            repository.observable.addObserver(new LoginObserver(onLoginSuccessful), UserRepository.loginTag);
        }

        private object onLoginSuccessful(ReturnAUF auth)
        {
            if (!auth.is_admin)
            {
                MainClient clientScreen = new MainClient(this);
                clientScreen.Show();
                this.Hide();
            } else if (auth.is_admin)
            {
                MainAdmin adminScreen = new MainAdmin(this);
                adminScreen.Show();
                this.Hide();
            } else
            {
                MessageBox.Show("Что-то пошло не так. Проверьте введенные данные и повторите попытку.");
            }

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

        private async void loginButton_Click(object sender, EventArgs e)
        {
            var loginHandler = new LoginHolder(loginField.Text, passwordField.Text);
            await repository.logInUser(loginHandler);
        }

        public class LoginObserver : Observer
        {
            private Func<ReturnAUF, object> onLogin;

            public LoginObserver(Func<ReturnAUF, object> onLogin)
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
                    return;
                }
                if (result.isLoading)
                {
                    Logger.println("Login screen is loading");
                    return;
                }
                if (result.data != null)
                {
                    Logger.print("Login screen current data is ");
                    Logger.println(result.data.ToString());

                    var auth = (ReturnAUF)Convert.ChangeType(result.data, typeof(ReturnAUF));

                    onLogin(auth);
                } else
                {
                    Logger.println("Login screen: invalid result data");
                }
            }
        }
    }
}
