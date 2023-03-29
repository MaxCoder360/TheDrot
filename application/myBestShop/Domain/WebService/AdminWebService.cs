using myBestShop.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myBestShop.Domain.WebService
{
    public class AdminWebService: IAdminWebService
    {
        private string baseUrl;
        public AdminWebService(string baseUrl)
        {
            this.baseUrl = baseUrl;
        }

        public Task<ComputerStatus> fetchUserStatus(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<List<string>> fetchUserProcesses(int userId)
        {
            throw new NotImplementedException();
        }

        public Task blockRemoteComputer(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<int> fetchUserCount(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
