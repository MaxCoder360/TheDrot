using myBestShop.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myBestShop.Domain.Database
{
    class DatabaseManager
    {
        public static DatabaseManager instance { get; private set; }

        public static void createInstance()
        {
            if (instance == null)
            {
                instance = new DatabaseManager();
            }
            else
            {
                throw new Exception("Database is already initialized");
            }
        }

        private DatabaseManager() { }

        public Task<int> getSessionKey()
        {
            throw new NotImplementedException();
        }

        public void addUser()
        {
            throw new NotImplementedException();
        }

        public Task<LoginHolder> getLogin()
        {
            throw new NotImplementedException();
        }
    }
}
