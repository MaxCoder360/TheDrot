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
    }
}
