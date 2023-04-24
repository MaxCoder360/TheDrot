using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using myBestShop.Domain.WebService;
using myBestShop.Utils;

namespace myBestShop.Domain.Repository
{
    public class UserRepository : IRepository
    {
        public static string loginTag = "Login_observer_tag";
        public static string getServerTimeTag = "Get_server_time_tag";
        private IUserWebService webService;

        public Observable<object> observable;

        public UserRepository(IUserWebService webService)
        {
            this.webService = webService;
            observable = new Observable<object>();
            this.webService.addObservable(observable);
        }

        public async Task logInUser(LoginHolder holder)
        {
            webService.fetchSessionKey(holder);
        }

        public async Task getServerTime(int userSessionKey)
        {
            webService.fetchServerTime(userSessionKey);
        }

        public async Task fetchTestData()
        {
            await webService.fetchTestData();
        }

        public async Task fetchTestData()
        {
            notify(new Result<object> { data = default, exception = null, isLoading = true }, "Default none tag");
            Logger.println("User repository: fetch test data before fetching");
            await webService.fetchTestData();
            Logger.println("User repository: fetch test data after fetching");

            notify(new Result<object> { data = "Default Success string", exception = null, isLoading = false }, "Default none tag");
        }
    }
}
