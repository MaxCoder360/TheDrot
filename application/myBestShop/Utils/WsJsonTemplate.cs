using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myBestShop.Utils
{
    public enum WsJsonDataTypes
    {
        FetchUserStatus,
        RequestAdmin,
        ExtendAvailableTimeForClient
    };

    public class WsJsonTemplate
    {
        public string data { get; set; }
        public WsJsonDataTypes type { get; set; }

        public WsJsonTemplate(string data, WsJsonDataTypes type)
        {
            this.data = data;
            this.type = type;
        }
    }
}
