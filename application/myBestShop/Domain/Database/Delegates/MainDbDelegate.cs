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

namespace myBestShop.Domain.Database.Delegates
{
    public class MainDbDelegate
    {
        
        public Task<int> getUserCount(int userId)
        {
            return new Task<int>(() =>
            {
                return 4;
            });
        }

        public async Task<List<Computer>> getAllComputers()
        {
            List<Computer> computers = new List<Computer>();
            try
            {
                DatabaseManager.mySqlConnection.Open();
                MySqlCommand mySqlCommand = new MySqlCommand("SELECT id_computer, ip_adress FROM thedrot.computers;", DatabaseManager.mySqlConnection);
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

        public async Task addUser()
        {
            throw new NotImplementedException();
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
    }
}
