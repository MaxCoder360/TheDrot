using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using myBestShop.Domain.WebService;
using myBestShop.Utils;

namespace myBestShop.Domain.Repository
{
    class LoginRepository
    {
        private UserWebService webService;
        public LoginRepository(UserWebService webService)
        {
            this.webService = webService;
        }

        public async Task<Result<int>> logInUser(LoginHolder holder)
        {
            int sessionKey = await webService.fetchSessionKey(holder);
            if (sessionKey == -1)
            {
                return new Result<int> { data = sessionKey, exception = new ArgumentException("Log in failed."), isLoading = false };
            }

            return new Result<int> { data = sessionKey };
        }

        public async Task<Result<DateTime>> getServerTime()
        {
            string serverTimeStr = await webService.fetchServerTime();
            if (serverTimeStr == null)
            {
                return new Result<DateTime> { data = default, exception = new Exception("Server side exception"), isLoading = false };
            }

            return new Result<DateTime> { data = DateTime.Parse(serverTimeStr), exception = null, isLoading = false };
        }
    }
}
