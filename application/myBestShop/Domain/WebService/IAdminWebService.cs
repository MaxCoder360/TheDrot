using myBestShop.Domain.Entities;
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
        Task<ComputerStatus> fetchUserStatus(Computer computer);
        Task<List<string>> fetchUserProcesses(Computer computer);
        Task blockRemoteComputer(Computer computer);
    }
}
