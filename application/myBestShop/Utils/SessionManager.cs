using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myBestShop.Utils
{
    class SessionManager
    {
        public int sessionKey { get; private set; }

        private static SessionManager inst = null;

        public static SessionManager createInstance(LoginHolder holder)
        {
            if (inst != null) {
                throw new ArgumentException("Session is already initialized");
            }
            inst = new SessionManager(holder);

            return inst;
        }

        private SessionManager(LoginHolder holder)
        {

        }
    }
}
