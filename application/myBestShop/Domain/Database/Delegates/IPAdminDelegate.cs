using myBestShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using myBestShop.Utils;

namespace myBestShop.Domain.Database.Delegates
{
    public class IPAdminDelegate
    {
        public async Task<string> GetIPAdmin(int id_admin)
        {
            string ip_adress = null;
            try
            {
                DatabaseManager.mySqlConnection.Open();
                MySqlCommand mySqlCommand = new MySqlCommand("", DatabaseManager.mySqlConnection);
                mySqlCommand.Parameters.Add("@id_admin", MySqlDbType.VarString).Value = id_admin;
                MySqlDataReader myReader = mySqlCommand.ExecuteReader();
                if (myReader.Read())
                {
                    ip_adress = myReader.GetString(0);
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
            return ip_adress;
        }
        public async Task SetIPAdmin(int id_admin)
        {
            string ip_adress = null;
            try
            {
                DatabaseManager.mySqlConnection.Open();
                MySqlCommand mySqlCommand = new MySqlCommand("UPDATE `thedrot`.`ipadmin` SET `ip_adress_admin` = @ip_adresss, `last_in` = @DATAS WHERE (`id_Admin` = @id_admin);", DatabaseManager.mySqlConnection);
                mySqlCommand.Parameters.Add("@id_admin", MySqlDbType.Int32).Value = id_admin;
                mySqlCommand.Parameters.Add("@DATAS", MySqlDbType.DateTime).Value = DateTime.Now;
                mySqlCommand.Parameters.Add("@ip_adresss", MySqlDbType.VarString).Value = Utils.Utils.GetLocalIPAddress();
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
        }
    }
}
