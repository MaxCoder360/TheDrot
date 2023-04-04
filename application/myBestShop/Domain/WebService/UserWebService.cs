using myBestShop.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static myBestShop.Utils.AppConfig;

namespace myBestShop.Domain.WebService
{
    public class UserWebService : IUserWebService
    {
        public string baseUrl;

        Task<int> IUserWebService.fetchSessionKey(LoginHolder holder)
        {
            throw new NotImplementedException();
        }

        Task<string> IUserWebService.fetchServerTime(int userSessionKey)
        {
            throw new NotImplementedException();
        }

        public UserWebService(WebServiceConfig config)
        {
            baseUrl = config.baseUrl;
        }
    }
}
