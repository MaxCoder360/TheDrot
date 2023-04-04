using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using myBestShop.Domain.WebService;
using myBestShop.Utils;

namespace myBestShop.Domain.Repository
{
    public class UserRepository : Observable<object>, IRepository
    {
        public static string loginTag = "Login_observer_tag";
        public static string getServerTimeTag = "Get_server_time_tag";
        private IUserWebService webService;
        public UserRepository(IUserWebService webService)
        {
            this.webService = webService;
        }

        public async Task logInUser(LoginHolder holder)
        {
            notify(new Result<object> { data = default, exception = null, isLoading = true }, loginTag);

            int sessionKey = await webService.fetchSessionKey(holder);
            if (sessionKey == -1)
            {
                notify(new Result<object> { data = sessionKey, exception = new ArgumentException("Log in failed."), isLoading = false }, loginTag);
            }

            notify(new Result<object> { data = sessionKey, exception = null, isLoading = false }, loginTag);
        }

        public async Task getServerTime(int userSessionKey)
        {
            notify(new Result<object> { data = default, exception = null, isLoading = true }, getServerTimeTag);

            string serverTimeStr = await webService.fetchServerTime(userSessionKey);
            if (serverTimeStr == null)
            {
                notify(new Result<object> { data = default, exception = new Exception("Server side exception"), isLoading = false }, getServerTimeTag);
            }

            notify(new Result<object> { data = DateTime.Parse(serverTimeStr), exception = null, isLoading = false }, getServerTimeTag);
        }
    }
}
