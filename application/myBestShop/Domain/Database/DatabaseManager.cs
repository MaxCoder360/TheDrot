﻿using myBestShop.Domain.Database.Delegates;
using myBestShop.Utils;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace myBestShop.Domain.Database
{
    class DatabaseManager
    {
        public static DatabaseManager instance { get; private set; }

        public LoginDelegate Login = new LoginDelegate();

        public static void createInstance()
        {
            if (instance == null)
            {
                instance = new DatabaseManager();
            }
            else
            {
                throw new Exception("Database is already initialized");
            }
        }

        private DatabaseManager() {
            initializeConnect();
        }

        private void initializeConnect()
        {
            if (DATA.mySqlConnection is null)
            {
                try
                {
                    DATA.mySqlConnection = new MySqlConnection("Server=172.20.10.2;Database=apple_store;Uid=test;Pwd=anime;SslMode=Preferred;");
                    DATA.mySqlConnection.Open();
                }
                catch(Exception ex)
                {
                    Logger.println("MySql connection initialization failed");
                    Logger.println(ex.Message);
                }
                finally
                {
                    DATA.mySqlConnection.Close();
                }

            }
        }

        public Task<int> getSessionKey()
        {
            throw new NotImplementedException();
        }

        public void addUser()
        {
            throw new NotImplementedException();
        }

        public Task<LoginHolder> getLogin()
        {
            throw new NotImplementedException();
        }
    }
}
