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

        public static SessionManager instance = null;

        public static void createSession(int sessionKey)
        {
            if (instance != null) {
                throw new ArgumentException("Session is already initialized");
            }
            instance = new SessionManager(sessionKey);
        }

        public static void destroySession()
        {
            instance = null;
        }

        private SessionManager(int sessionKey)
        {
            this.sessionKey = sessionKey;
        }
    }
}
