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
        Task<ComputerStatus> fetchUserStatus(int userId)
        {
            throw new NotImplementedException();
        }
        Task<List<string>> fetchUserProcesses(int userId)
        {
            throw new NotImplementedException();
        }
        Task blockRemoteComputer(int userId)
        {
            throw new NotImplementedException();
        }
        Task<int> fetchUserCount(int userId)
        {
            throw new NotImplementedException();
        }

        public Task addUser()
        {
            throw new NotImplementedException();
        }

        public Task<LoginHolder> getLogin()
        {
            throw new NotImplementedException();
        }
    }
}
