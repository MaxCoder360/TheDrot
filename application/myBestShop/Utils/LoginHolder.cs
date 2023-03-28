using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myBestShop.Utils
{
    public class LoginHolder
    {
        public string userName { get;  private set; }
        public string password { get; private set; }

        public LoginHolder(string userName, string password)
        {
            this.userName = userName;
            this.password = password;
        }
    }
}
