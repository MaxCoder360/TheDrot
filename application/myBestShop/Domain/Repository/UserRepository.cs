using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using myBestShop.Domain.Database;
using myBestShop.Domain.WebService;
using myBestShop.Utils;

namespace myBestShop.Domain.Repository
{
    public class UserRepository : IRepository
    {
        public static string loginTag = "Login_observer_tag";
        public static string getServerTimeTag = "Get_server_time_tag";
        
        private IUserWebService webService;
        private DatabaseManager dbManager;

        public Observable<object> observable;

        public UserRepository(IUserWebService webService, DatabaseManager manager)
        {
            this.webService = webService;
            observable = new Observable<object>();
            this.webService.addObservable(observable);
            dbManager = manager;
        }

        public async Task logInUser(LoginHolder holder)
        {
            Logger.println("UShfuid");
            observable.notify(new Result<object> { data = default, exception = null, isLoading = true }, UserRepository.loginTag);
            var result = await dbManager.Login.getUserSessionKeyByLogin(holder);
            Logger.println(result.ToString());
            if (result != null)
            {
                observable.notify(new Result<object> { data = result, exception = null, isLoading = false }, UserRepository.loginTag);
                return;
            }
            Logger.println("jkdsals");
            observable.notify(new Result<object> { data = default, exception = new Exception("Log in user failed"), isLoading = false }, UserRepository.loginTag);
        }

        /*public async Task getServerTime(int userSessionKey)
        {
            webService.fetchServerTime(userSessionKey);
        }*/

        /*public async Task fetchTestData()
        {
            await webService.fetchTestData();
        }*/
    }
}
