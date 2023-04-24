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
            LogInUser,
        };

        public string data;
        public string type;

        public WsJsonTemplate(string data, string type)
        {
            this.data = data;
            this.type = type;
        }
    }
}
