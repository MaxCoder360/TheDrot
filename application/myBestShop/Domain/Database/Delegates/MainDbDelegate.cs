using myBestShop.Domain.Entities;
using myBestShop.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<List<User>> getAllUsers()
        {
            return new List<User> { new User(1, 10), new User(2, 11), new User(3, 12), new User(0, 13) };
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
