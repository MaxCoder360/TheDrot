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

        private IAdminWebService webService;
        private DatabaseManager dbManager;
        public AdminRepository(IAdminWebService webService, DatabaseManager manager)
        {
            this.webService = webService;
            this.dbManager = manager;
        }

        public async Task fetchUserStatuses()
        {
            notify(new Result<object> { data = default, exception = null, isLoading = true }, userStatusTag);

            List<User> users = await dbManager.Main.getAllUsers();
            List<ComputerWrapper> statuses = new List<ComputerWrapper>();

            foreach (User user in users)
            {
                try
                {
                    var status = await webService.fetchUserStatus(user.id);
                    statuses.Append(new ComputerWrapper(user.computerId, user.id, status));
                } catch (Exception)
                {
                    statuses.Append(new ComputerWrapper(user.computerId, user.id, ComputerStatus.UNKNOWN));
                }
            }

            notify(new Result<object> { data = statuses, exception = null, isLoading = false }, userStatusTag);
        }
    }
}
