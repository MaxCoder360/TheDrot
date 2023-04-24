using myBestShop.Domain.Entities;
using myBestShop.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;
using MySql.Data.MySqlClient;

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

        public async Task<LoginHolder> getLogin()
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
    }
}
