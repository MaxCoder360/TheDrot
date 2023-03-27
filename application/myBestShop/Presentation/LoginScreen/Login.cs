using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace myBestShop
{
    
    
    public partial class Login : Form
    {
        private MainAdmin mainAdmin = null;
        private MainClient mainClient = null;

        private void InitializeConnect()
        {
            if (DATA.mySqlConnection is null)
            {
                try
                {
                    DATA.mySqlConnection = new MySqlConnection("Server=172.20.10.2;Database=apple_store;Uid=test;Pwd=anime;SslMode=Preferred;");
                    DATA.mySqlConnection.Open();
                }
                catch
                {
                    MessageBox.Show("Человек, ты не в корпоротивной сети или у тебя нет интернета", "ПРОБЛЕМА", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
                finally
                {
                    DATA.mySqlConnection.Close();
                }

            }
        }

        public Login()
        {
            InitializeConnect();
            InitializeComponent();
        }

        private void login_Click(object sender, EventArgs e)
        {
            string userLogin = text_login.Text;
            string userPass = text_password.Text;
           

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
                            mainClient.Closed += (s, args) => this.Close();
                            mainClient.Show();
                            this.Visible = false;
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
                                mainAdmin.Closed += (s, args) => this.Close();
                                mainAdmin.Show();
                                this.Visible = false;
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
            else
            {
                MessageBox.Show("Человек, ты не до конца ввёл данные", "ПРОБЛЕМА", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
