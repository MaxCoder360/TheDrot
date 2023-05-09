using myBestShop.Domain.Database.Delegates;
using myBestShop.Utils;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace myBestShop.Domain.Database
{
    public class DatabaseManager
    {
        private static MySqlConnection _mySqlConnection = null;
        public static MySqlConnection mySqlConnection { 
            get 
            {
                if (_mySqlConnection == null)
                {
                    return null;
                }
                if (_mySqlConnection.State != System.Data.ConnectionState.Closed)
                {
                    return (MySqlConnection)_mySqlConnection.Clone();
                }

                return _mySqlConnection;
            }
            set
            {
                _mySqlConnection = value;
            }
        }
        public static DatabaseManager instance { get; private set; }
        public static void createInstance()
        {
            if (instance == null)
            {
                instance = new DatabaseManager();
            }
            else
            {
                Logger.println("MySql connection initialized");
            }
        }


        public LoginDbDelegate Login = new LoginDbDelegate();
        public MainDbDelegate Main = new MainDbDelegate();
        public IPAdminDelegate IPadmin = new IPAdminDelegate();


        private DatabaseManager() {
            initializeConnect();
        }

        private void initializeConnect()
        {
            if (mySqlConnection is null)
            {
                try
                {
                    mySqlConnection = new MySqlConnection("Server=DESKTOP-MU21P6Q;Port=3306;Database=thedrot;Uid=test;Pwd=password;SslMode=Preferred;ConnectionTimeout=4000");
                    mySqlConnection.Open();
                }
                catch(Exception ex)
                {
                    Logger.println("MySql connection initialization failed");
                    Logger.println(ex.Message);
                    Logger.println("всё ок");
                }
                finally
                {
                    mySqlConnection.Close();
                }

            }
        }

    }
}
