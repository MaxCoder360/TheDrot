using myBestShop.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myBestShop.Domain.WebService
{
    public interface IUserWebService
    {
        Task fetchSessionKey(LoginHolder holder);
        Task fetchServerTime(int userSessionKey);
        Task fetchTestData();
    }
}
