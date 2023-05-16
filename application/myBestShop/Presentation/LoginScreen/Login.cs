using myBestShop.Domain.Repository;
using myBestShop.Utils;
using myBestShop.DependencyBuilders;
using System;
using System.Text;
using System.Windows.Forms;
using WebSocketSharp.Server;
using static myBestShop.Utils.Utils;
using myBestShop.Domain.Entities;
using myBestShop.Domain.Database.Delegates;
using System.Windows.Input;

namespace myBestShop
{
    public partial class LoginScreen : Form
    {
        public UserRepository repository;

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
            Session sess = repository.dbManager.Main.GetClientSession(auth);
            if (!auth.is_admin && sess != null)
            {
                Program.isLogined = true;
                MainClient clientScreen = new MainClient(this, sess);
                clientScreen.Show();
                this.Hide();
            } else if (auth.is_admin)
            {
                Program.isLogined = true;
                MainAdmin adminScreen = new MainAdmin(this, auth);
                adminScreen.Show();
                this.Hide();
            } else
            {
                MessageBox.Show("Что-то пошло не так. Проверьте введенные данные и повторите попытку.");
            }
            loginField.Text = "";
            passwordField.Text = "";

            // Close();

            return null;
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
                    MessageBox.Show("Данные введены нЕ веррно.");
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
                    MessageBox.Show("Данные введены нЕ веррно.");
                    Logger.println("Login screen: invalid result data");
                }
            }
        }

        private void LoginScreen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
