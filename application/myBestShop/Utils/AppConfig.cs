using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myBestShop.Utils
{
    public static class AppConfig
    {
        public enum ConfigType {
            DEBUG_CONFIG = 0,
            RELEASE_CONFIG = 1
        }

        public static ConfigType BUILD_CONFIG = ConfigType.DEBUG_CONFIG;

        public class WebServiceConfig
        {
            public string baseUrl { get; private set; }
            public static WebServiceConfig createWebConfig(ConfigType type)
            {
                string currentUrl = null;
                if (type == ConfigType.DEBUG_CONFIG)
                {
                    currentUrl = Consts.LOCALHOST_URL;
                } else if (type == ConfigType.RELEASE_CONFIG)
                {
                    currentUrl = Consts.OPEN_URL;
                }

                return new WebServiceConfig(currentUrl);
            }

            private WebServiceConfig(string baseUrl)
            {
                this.baseUrl = baseUrl;
            }
        }
    }

    public static class Consts
    {
        public static string LOCALHOST_URL = "127.0.0.1";
        public static string OPEN_URL = "0.0.0.0";
    }
}
