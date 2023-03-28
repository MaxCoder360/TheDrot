using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myBestShop.Utils
{
    public enum ComputerStatus
    {
        AVAILABLE,
        IN_DANGER,
        IS_USED,
        UNAVAILABLE
    }

    public class UserTypeExt
    {
        public enum UserType
        {
            ADMIN = 0,
            USER = 1,
        }

        public static UserType fromInteger(int userType)
        {
            if (userType == 0)
            {
                return UserType.ADMIN;
            }

            return UserType.USER;
        }
    }
}
