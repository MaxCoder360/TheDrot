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
        void fetchUserStatus(Computer computer);
        void fetchUserProcesses(Computer computer);
        void blockRemoteComputer(Computer computer);
    }
}
