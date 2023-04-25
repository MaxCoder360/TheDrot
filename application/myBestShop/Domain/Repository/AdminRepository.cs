using myBestShop.Domain.WebService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using myBestShop.DependencyBuilders;
using static myBestShop.Utils.AppConfig;
using myBestShop.Utils;
using myBestShop.Domain.Database;
using myBestShop.Domain.Entities;

namespace myBestShop.Domain.Repository
{
    public class AdminRepository : Observable<object>, IRepository
    {
        public static string userStatusTag = "User_status_tag";

        private AdminWebService webService;
        private DatabaseManager dbManager;
        public AdminRepository(IAdminWebService webService, DatabaseManager manager)
        {
            this.webService = (AdminWebService)webService;
            this.dbManager = manager;
        }

        public async Task fetchUserStatuses()
        {
            List<Computer> computers = await dbManager.Main.getAllComputers();

            webService.updateWebSockets();
            for (int i = 0; i < computers.Count; i++)
            {
                Computer comp = computers[i];
                webService.fetchUserStatus(comp);
            }
        }
    }
}
