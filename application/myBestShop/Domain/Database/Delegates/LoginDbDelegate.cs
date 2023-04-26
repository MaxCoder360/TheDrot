using myBestShop.Domain.Entities;
using myBestShop.Utils;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static myBestShop.Utils.Utils;

namespace myBestShop.Domain.Database.Delegates
{
    public class LoginDbDelegate
    {



        public async Task<ReturnAUF> getUserSessionKeyByLogin(LoginHolder holder)
        {
            string userLogin = holder.userName;
            string userPass = holder.password;
            ReturnAUF AUF = null;
            try
            {
                DatabaseManager.mySqlConnection.Open();
                MySqlCommand mySqlCommand = new MySqlCommand("SELECT * FROM users where mail = @login AND password = @password;", DatabaseManager.mySqlConnection);
                mySqlCommand.Parameters.Add("@login", MySqlDbType.VarChar).Value = userLogin;
                mySqlCommand.Parameters.Add("@password", MySqlDbType.Binary).Value = CreateMD5(userPass);
                MySqlDataReader myReader = mySqlCommand.ExecuteReader();
                if (myReader.Read())
                {
                    AUF = new ReturnAUF(myReader.GetInt32(0), myReader.GetString(7));
                }
                myReader.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                DatabaseManager.mySqlConnection.Close();
            }
            return AUF;
        }




        
    }
}
