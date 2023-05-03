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
    public class AdminRepository : IRepository
    {
        public static string userStatusTag = "User_status_tag";

        private AdminWebService webService;
        public DatabaseManager dbManager;

        public Observable<object> observable;
        public AdminRepository(IAdminWebService webService, DatabaseManager manager)
        {
            this.webService = (AdminWebService)webService;
            observable = new Observable<object>();
            this.webService.observable = observable;
            this.webService.initialize();
            this.dbManager = manager;
        }

        public async Task fetchUserStatuses(List<Computer> computers)
        {
            Utils.Logger.println("fetch User Status" + computers.Count);
            webService.updateWebSockets();
            for (int i = 0; i < computers.Count; i++)
            {
                Computer comp = computers[i];
                webService.fetchUserStatus(comp);
            }
        }
    }
}
