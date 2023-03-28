using myBestShop.Utils;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myBestShop.Domain.Database.Delegates
{
    public class LoginDelegate
    {
        public LoginDelegate()
        {

        }

        private MainAdmin mainAdmin = null;
        private MainClient mainClient = null;
        public void findUserIdByLogin(LoginHolder holder)
        {
            string userLogin = holder.userName;
            string userPass = holder.password;

            if (userLogin != "" && userPass != "")
            {
                bool isEmployee = true;
                try
                {
                    DATA.mySqlConnection.Open();
                    MySqlCommand mySqlCommand = new MySqlCommand("SELECT * FROM client where mail = @login AND password = @password", DATA.mySqlConnection);
                    mySqlCommand.Parameters.Add("@login", MySqlDbType.VarChar).Value = userLogin;
                    mySqlCommand.Parameters.Add("@password", MySqlDbType.Binary).Value = CreateMD5(userPass);
                    MySqlDataReader myReader = mySqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        Console.WriteLine("isClient");
                        if (mainAdmin is null)
                        {
                            DATA.id = myReader.GetInt32(0);
                            myReader.Close();
                            DATA.mySqlConnection.Close();
                            mainClient = new MainClient();
                            /*mainClient.Closed += (s, args) => this.Close();
                            mainClient.Show();
                            this.Visible = false;*/
                        }
                        isEmployee = false;
                    }
                    else
                    {
                        Console.WriteLine("NO");
                    }
                    myReader.Close();


                }
                catch (MySqlException ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                finally
                {
                    DATA.mySqlConnection.Close();
                }
                if (isEmployee)
                {
                    try
                    {
                        DATA.mySqlConnection.Open();
                        MySqlCommand mySqlCommand = new MySqlCommand("SELECT * FROM employee where mail = @login AND password = @password", DATA.mySqlConnection);
                        mySqlCommand.Parameters.Add("@login", MySqlDbType.VarChar).Value = userLogin;
                        mySqlCommand.Parameters.Add("@password", MySqlDbType.Binary).Value = CreateMD5(userPass);
                        MySqlDataReader myReader = mySqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            Console.WriteLine("isEmployee");
                            if (mainAdmin is null)
                            {
                                DATA.id = myReader.GetInt32(0);
                                myReader.Close();
                                DATA.mySqlConnection.Close();
                                mainAdmin = new MainAdmin();
                                /*mainAdmin.Closed += (s, args) => this.Close();
                                mainAdmin.Show();
                                this.Visible = false;*/
                            }
                        }
                        else
                        {
                            Console.WriteLine("NO");
                        }

                        myReader.Close();



                    }
                    catch (MySqlException ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                    finally
                    {
                        DATA.mySqlConnection.Close();
                    }

                }
            }

        }

        public static string CreateMD5(string input)
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
