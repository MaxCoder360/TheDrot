﻿using myBestShop.Domain.Database;
using myBestShop.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace myBestShop
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // initialize observable storage to keep info about observables
            ObservableStorage.initialize();
            DatabaseManager.createInstance();
            try
            {
                //new Form1()
                Application.Run(new LoginScreen());
            }
            catch
            {
                Application.Exit();
            }
        }
    }
}