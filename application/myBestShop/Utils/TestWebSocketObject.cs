using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myBestShop.Utils
{
    public class TestWebSocketObject
    {
        public string type { get; private set; }
        public string symbol { get; private set; }

        public TestWebSocketObject(string type, string symbol)
        {
            this.type = type;
            this.symbol = symbol;
        }
    }
}
