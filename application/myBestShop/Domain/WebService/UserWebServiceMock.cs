using myBestShop.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static myBestShop.Utils.AppConfig;

namespace myBestShop.Domain.WebService
{
    public class UserWebServiceMock : IUserWebService
    {
        public string baseUrl;

        async Task<int> IUserWebService.fetchSessionKey(LoginHolder holder)
        {
            int result = -1;
            if (holder.userName == "")
            {
                await Task.Run(() => result = 0);
            } else if (holder.userName == "MaxCode360")
            {
                await Task.Run(() => result = 1);
            }
            else
            {
                await Task.Run(() => result = 2);
            }
            return result;
        }

        Task<string> IUserWebService.fetchServerTime(int userSessionKey)
        {
            return new Task<string>(() => DateTime.Now.ToString());
        }

        public UserWebServiceMock(WebServiceConfig config)
        {
            baseUrl = config.baseUrl;
        }
    }
}
