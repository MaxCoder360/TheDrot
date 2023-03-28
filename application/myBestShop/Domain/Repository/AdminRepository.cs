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

namespace myBestShop.Domain.Repository
{
    public class AdminRepository : IRepository
    {
        public AdminWebService webService;
        public DatabaseManager dbManager;
        public AdminRepository(AdminWebService webService, DatabaseManager manager)
        {
            this.webService = webService;
            this.dbManager = manager;
        }


    }
}
