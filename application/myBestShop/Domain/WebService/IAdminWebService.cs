using myBestShop.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myBestShop.Domain.WebService
{
    public interface IAdminWebService
    {
        Task<ComputerStatus> fetchUserStatus(int userId);
        Task<List<string>> fetchUserProcesses(int userId);
        Task blockRemoteComputer(int userId);
    }
}
