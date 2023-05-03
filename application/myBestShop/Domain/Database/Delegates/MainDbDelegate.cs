using myBestShop.Domain.Entities;
using myBestShop.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;
using MySql.Data.MySqlClient;
using System.Drawing;
using static myBestShop.Utils.Utils;
using System.Diagnostics.Eventing.Reader;
using System.Threading;

namespace myBestShop.Domain.Database.Delegates
{
    public class MainDbDelegate
    {
        bool WAIT = false;

        public async Task<List<Computer>> getAllComputers()
        {
            List<Computer> computers = new List<Computer>();
            try
            {
                if (DatabaseManager.mySqlConnection == null)
                {
                    throw new Exception("nnvnvnvnnv");
                }
                DatabaseManager.mySqlConnection.Open();
                MySqlCommand mySqlCommand = new MySqlCommand("SELECT id_computer, ip_adress FROM thedrot.computers;", DatabaseManager.mySqlConnection);
                if (mySqlCommand == null)
                {
                    throw new Exception("UUroewurefow");
                }
                MySqlDataReader myReader = mySqlCommand.ExecuteReader();
                while (myReader.Read())
                {
                    computers.Add(new Computer(myReader.GetInt32(0), myReader.GetString(1)));
                }
                myReader.Close();
            }
            catch (Exception ex)
            {
                Logger.println(ex.ToString());
            }
            finally
            {
                DatabaseManager.mySqlConnection.Close();
            }
            return computers;
        }

        public async Task<Computer> getAllInfoAboutComputer(int ID)
        {
            Computer computers = null;
            try
            {
                DatabaseManager.mySqlConnection.Open();
                MySqlCommand mySqlCommand = new MySqlCommand("SELECT * FROM thedrot.computers WHERE id_computer = @id;", DatabaseManager.mySqlConnection);
                mySqlCommand.Parameters.Add("@id", MySqlDbType.Int32).Value = ID;
                MySqlDataReader myReader = mySqlCommand.ExecuteReader();
                if (myReader.Read())
                {
                    computers = new Computer(myReader.GetInt32(0), myReader.GetString(1), myReader.GetString(2), myReader.GetString(3), myReader.GetString(4), myReader.GetString(5), myReader.GetString(6), myReader.GetString(7), myReader.GetString(8));
                }
                myReader.Close();
            }
            catch (Exception ex)
            {
                Logger.println(ex.ToString());
            }
            finally
            {
                DatabaseManager.mySqlConnection.Close();
            }
            return computers;
        }

        public async Task<string> addComputerInDB(Computer comp)
        {
            string check = null;
            try
            {
                DatabaseManager.mySqlConnection.Open();
                MySqlCommand mySqlCommand = new MySqlCommand("INSERT INTO `thedrot`.`computers` (`type`, `manufacturer`, `serial_number`, `CPU`, `GPU`, `RAM`, `Storage`, `ip_adress`) VALUES (@type, @manufacturer, @serial_number, @CPU, @GPU, @RAM, @Storage, @ip_adress);", DatabaseManager.mySqlConnection);
                mySqlCommand.Parameters.Add("@type", MySqlDbType.VarString).Value = comp.type;
                mySqlCommand.Parameters.Add("@manufacturer", MySqlDbType.VarString).Value = comp.manufacturer;
                mySqlCommand.Parameters.Add("@serial_number", MySqlDbType.VarString).Value = comp.serial_number;
                mySqlCommand.Parameters.Add("@CPU", MySqlDbType.VarString).Value = comp.CPU;
                mySqlCommand.Parameters.Add("@GPU", MySqlDbType.VarString).Value = comp.GPU;
                mySqlCommand.Parameters.Add("@RAM", MySqlDbType.VarString).Value = comp.RAM;
                mySqlCommand.Parameters.Add("@Storage", MySqlDbType.VarString).Value = comp.Storage;
                mySqlCommand.Parameters.Add("@ip_adress", MySqlDbType.VarString).Value = comp.ip_adress;
                mySqlCommand.ExecuteNonQuery();
                check = "OK";
            }
            catch (Exception ex)
            {
                Logger.println(ex.ToString());
                check = ex.Message;
            }
            finally
            {
                DatabaseManager.mySqlConnection.Close();
            }
            return check;
        }
        public async Task<string> addUserInDB(User user)
        {
            string check = null;
            try
            {
                DatabaseManager.mySqlConnection.Open();
                MySqlCommand mySqlCommand = new MySqlCommand("INSERT INTO `thedrot`.`users` (`mail`, `password`, `name`, `surname`, `phone_number`, `passport`, `admin`) VALUES (@mail, @password, @name, @surname, @phone_number, @passport, @admin);", DatabaseManager.mySqlConnection);
                mySqlCommand.Parameters.Add("@mail", MySqlDbType.VarString).Value = user.mail;
                mySqlCommand.Parameters.Add("@password", MySqlDbType.Binary).Value = CreateMD5(user.password);
                mySqlCommand.Parameters.Add("@name", MySqlDbType.VarString).Value = user.name;
                mySqlCommand.Parameters.Add("@surname", MySqlDbType.VarString).Value = user.surname;
                mySqlCommand.Parameters.Add("@phone_number", MySqlDbType.VarString).Value = user.phone_number;
                mySqlCommand.Parameters.Add("@passport", MySqlDbType.VarString).Value = user.passport;
                mySqlCommand.Parameters.Add("@admin", MySqlDbType.VarString).Value = user.admin;
                mySqlCommand.ExecuteNonQuery();
                check = "OK";
            }
            catch (Exception ex)
            {
                Logger.println(ex.ToString());
                check = ex.Message;
            }
            finally
            {
                DatabaseManager.mySqlConnection.Close();
            }
            return check;
        }

        public Session GetClientSession(ReturnAUF user)
        {
            Session sess = null;
            try
            {
                DatabaseManager.mySqlConnection.Open();
                MySqlCommand mySqlCommand = new MySqlCommand("SELECT sess.*, users.name, users.surname FROM thedrot.sessions AS sess, thedrot.users AS users WHERE sess.id_user = @id_user AND sess.end_time_rent >= @data_time AND sess.start_time_rent <= @data_time and users.id_user = @id_user;", DatabaseManager.mySqlConnection);
                mySqlCommand.Parameters.Add("@id_user", MySqlDbType.VarString).Value = user.id;
                mySqlCommand.Parameters.Add("@data_time", MySqlDbType.DateTime).Value = DateTime.Now;
                MySqlDataReader myReader = mySqlCommand.ExecuteReader();
                if (myReader.Read())
                {
                    sess = new Session(myReader.GetInt32(0), myReader.GetDateTime(4), myReader.GetDateTime(5), myReader.GetInt32(1), myReader.GetInt32(3), myReader.GetInt32(2), myReader.GetString(6), myReader.GetString(7));
                }
                myReader.Close();
            }
            catch (Exception ex)
            {
                Logger.println(ex.ToString());
            }
            finally
            {
                DatabaseManager.mySqlConnection.Close();
            }
            return sess;
        }


        public async Task<List<User>> getAllUsers()
        {
            int zhdum = 0;
            while (WAIT) // не знаю заем добавил)))
            {
                if (zhdum > 10)
                {
                    Logger.println("Не дождались подключения для " + "getAllInfoAboutComputer");
                    return null;
                }
                zhdum += 1;
                Thread.Sleep(500);

            }
            WAIT = true;
            List<User> users = new List<User>();

            try
            {
                DatabaseManager.mySqlConnection.Open();
                MySqlCommand mySqlCommand = new MySqlCommand("SELECT * FROM thedrot.users WHERE admin != 1;", DatabaseManager.mySqlConnection);
                MySqlDataReader myReader = mySqlCommand.ExecuteReader();
                while (myReader.Read())
                {
                    users.Add(new User(myReader.GetInt32(0), myReader.GetString(3), myReader.GetString(4), myReader.GetString(5), myReader.GetString(1)));
                }
                myReader.Close();
            }
            catch (Exception ex)
            {
                Logger.println(ex.ToString());
            }
            finally
            {
                DatabaseManager.mySqlConnection.Close();
            }

            WAIT = false;
            return users;
        }

        public async Task addSessionInDB(Session sess)
        {
            int zhdum = 0;
            while (WAIT) // не знаю заем добавил)))
            {
                if (zhdum > 10)
                {
                    Logger.println("Не дождались подключения для " + "addSessionInDB");
                    return;
                }
                zhdum += 1;
                Thread.Sleep(500);

            }
            WAIT = true;

            try
            {
                DatabaseManager.mySqlConnection.Open();
                MySqlCommand mySqlCommand = new MySqlCommand("INSERT INTO `thedrot`.`sessions` (`id_admin`, `id_user`, `id_computer`, `start_time_rent`, `end_time_rent`) VALUES (@id_admin, @id_user, @id_comp, @start_time, @end_time);", DatabaseManager.mySqlConnection);
                mySqlCommand.Parameters.Add("@id_admin", MySqlDbType.Int32).Value = sess.id_admin;
                mySqlCommand.Parameters.Add("@id_user", MySqlDbType.Int32).Value = sess.id_user;
                mySqlCommand.Parameters.Add("@id_comp", MySqlDbType.Int32).Value = sess.id_computer;
                mySqlCommand.Parameters.Add("@start_time", MySqlDbType.DateTime).Value = sess.start_time_rent;
                mySqlCommand.Parameters.Add("@end_time", MySqlDbType.DateTime).Value = sess.end_time_rent;
                mySqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Logger.println(ex.ToString());
            }
            finally
            {
                DatabaseManager.mySqlConnection.Close();
            }

            WAIT = false;
        }
    }
}
