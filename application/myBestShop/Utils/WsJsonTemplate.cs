using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myBestShop.Utils
{
    public class WsJsonTemplate
    {
        public enum WsJsonDataTypes
        {
            FetchUserStatus,
            RequestAdmin,
            ExtendAvailableTimeForClient
        };

        public string data;
        public WsJsonDataTypes type;

        public WsJsonTemplate(string data, WsJsonDataTypes type)
        {
            this.data = data;
            this.type = type;
        }
    }
}
