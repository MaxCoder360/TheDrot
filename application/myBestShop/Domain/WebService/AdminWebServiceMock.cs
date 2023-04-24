using myBestShop.Domain.Entities;
using myBestShop.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myBestShop.Domain.WebService
{
    public class AdminWebServiceMock : IAdminWebService
    {
        void IAdminWebService.blockRemoteComputer(Computer computer)
        {
            // no test provided
        }

        void IAdminWebService.fetchUserProcesses(Computer computer)
        {
            // no test provided
        }

        void IAdminWebService.fetchUserStatus(Computer computer)
        {
            // no test provided
        }
    }
}
