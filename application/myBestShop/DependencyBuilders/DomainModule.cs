using myBestShop.Domain.WebService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static myBestShop.Utils.AppConfig;

namespace myBestShop.DependencyBuilders
{
    public static class DomainModule
    {
        public static WebServiceConfig createWebConfig(ConfigType type)
        {
            return WebServiceConfig.createWebConfig(type);
        }

        public static AdminWebService createAdminWebService(WebServiceConfig config)
        {
            return new AdminWebService(config.baseUrl);
        }

        public static UserWebService createUserWebService(WebServiceConfig config)
        {
            return new UserWebService();
        }
    }
}
