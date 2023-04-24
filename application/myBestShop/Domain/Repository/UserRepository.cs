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
        public static string obtainSessionKeyTag = "Obtain_session_key_tag";
        
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
    }
}
