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
        private IUserWebService webService;
        public UserRepository(IUserWebService webService)
        {
            this.webService = webService;
            tag = GetType().Name;
        }

        public async Task logInUser(LoginHolder holder)
        {
            notify(new Result<object> { data = default, exception = null, isLoading = true });

            int sessionKey = await webService.fetchSessionKey(holder);
            if (sessionKey == -1)
            {
                notify(new Result<object> { data = sessionKey, exception = new ArgumentException("Log in failed."), isLoading = false });
            }

            notify(new Result<object> { data = sessionKey, exception = null, isLoading = false });
        }

        public async Task getServerTime(int userSessionKey)
        {
            notify(new Result<object> { data = default, exception = null, isLoading = true });

            string serverTimeStr = await webService.fetchServerTime(userSessionKey);
            if (serverTimeStr == null)
            {
                notify(new Result<object> { data = default, exception = new Exception("Server side exception"), isLoading = false });
            }

            notify(new Result<object> { data = DateTime.Parse(serverTimeStr), exception = null, isLoading = false });
        }
    }
}
