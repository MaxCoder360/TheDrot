﻿using myBestShop.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myBestShop.Domain.WebService
{
    public class AdminWebServiceMock : IAdminWebService
    {
        public Task blockRemoteComputer(int userId)
        {
            return Task.Run(() =>
            {
                // blocks some computer by id
            });
        }

        public async Task<int> fetchUserCount()
        {
            return 4;
        }

        public async Task<List<string>> fetchUserProcesses(int userId)
        {
            if (userId == 0)
            {
                return new List<string> { "NVideo Container", "Обработчик команд Windows" };
            } else if (userId == 1)
            {
                return new List<string> { "Microsoft Visual Studio 2022", "Обработчик команд Windows", "Anti Strike: Global Offense" };
            } else if (userId == 2)
            {
                return new List<string> { "Microsoft Visual Studio 2022", "Диспетчер задач Windows", "Неизвестная вирусная программа" };
            }

            return new List<string> { };
        }

        public async Task<ComputerStatus> fetchUserStatus(int userId)
        {
            if (userId == 0) {
                return ComputerStatus.AVAILABLE;
            }
            else if (userId == 1)
            {
                return ComputerStatus.IS_USED;
            } 
            else if (userId == 2)
            {
                return ComputerStatus.IN_DANGER;
            }

            return ComputerStatus.UNAVAILABLE;
        }
    }
}