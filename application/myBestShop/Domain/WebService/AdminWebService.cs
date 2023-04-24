using myBestShop.Domain.Entities;
using myBestShop.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;

namespace myBestShop.Domain.WebService
{
    public class AdminWebService: IAdminWebService
    {
        private List<WebSocket> wsPool;
        public AdminWebService(List<Computer> allAvailableComputers)
        {
            wsPool = new List<WebSocket>();
        }

        public Task<ComputerStatus> fetchUserStatus(Computer computer)
        {
            throw new NotImplementedException();
        }

        public Task<List<string>> fetchUserProcesses(Computer computer)
        {
            throw new NotImplementedException();
        }

        public Task blockRemoteComputer(Computer computer)
        {
            throw new NotImplementedException();
        }

        private void initializeWebSockets(List<Computer> availableComputers)
        {
            wsPool.Clear();
            foreach (Computer computer in availableComputers)
            {
                if (computer != null)
                {
                    WebSocket socket = new WebSocket(computer.ip_adress);

                }
            }
        }
    }
}
