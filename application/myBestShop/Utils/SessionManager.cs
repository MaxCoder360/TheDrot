using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static myBestShop.Utils.UserTypeExt;

namespace myBestShop.Utils
{
    class SessionManager
    {
        public int sessionKey { get; private set; }

        // User type - variable for keeping info about user role (client or admin)
        // 0 - client
        // 1 - admin
        // else - ArgumentException()
        public UserType userType { get; private set; }

        public static SessionManager instance = null;

        public static void createSession(int sessionKey, int userType)
        {
            if (instance != null) {
                throw new ArgumentException("Session is already initialized");
            }
            instance = new SessionManager(sessionKey, userType);
        }

        public static void destroySession()
        {
            instance = null;
        }

        private SessionManager(int sessionKey, int userType)
        {
            if (userType != 0 && userType != 1)
            {
                throw new ArgumentException("Given user type is neither admin, nor client");
            }

            this.sessionKey = sessionKey;
            this.userType = UserTypeExt.fromInteger(userType);
        }
    }
}
