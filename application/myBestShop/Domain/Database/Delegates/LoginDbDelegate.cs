using myBestShop.Utils;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myBestShop.Domain.Database.Delegates
{
    public class LoginDbDelegate
    {
        public LoginDbDelegate()
        {

        }

        public async Task<int> getUserSessionKeyByLogin(LoginHolder holder)
        {
            string userLogin = holder.userName;
            string userPass = holder.password;
            int id = -1;
            try
            {
                DatabaseManager.mySqlConnection.Open();
                MySqlCommand mySqlCommand = new MySqlCommand("SELECT * FROM client where mail = @login AND password = @password", DatabaseManager.mySqlConnection);
                mySqlCommand.Parameters.Add("@login", MySqlDbType.VarChar).Value = userLogin;
                mySqlCommand.Parameters.Add("@password", MySqlDbType.Binary).Value = CreateMD5(userPass);
                MySqlDataReader myReader = mySqlCommand.ExecuteReader();
                if (myReader.Read())
                {
                    id = myReader.GetInt32(0);
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
            return id;
        }




        private string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }
    }
}
