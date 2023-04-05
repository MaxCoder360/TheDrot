using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace myBestShop.Utils
{
    public enum ComputerStatus
    {
        AVAILABLE,
        IN_DANGER,
        IS_USED,
        UNAVAILABLE,
        UNKNOWN
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

    public class ComputerWrapper
    {
        public int computerId { get; private set; }
        public int userId { get; private set; }
        public ComputerStatus status { get; private set; }

        public ComputerWrapper(int computerId, int userId, ComputerStatus status)
        {
            this.computerId = computerId;
            this.status = status;
            this.userId = userId;
        }

        public Color convertStatusToDataGridStyle()
        {
            if (status == ComputerStatus.UNAVAILABLE)
            {
                return Color.FromArgb(-6118750); // Grey Color
                // style.ForeColor = Color.Black;
            } else if (status == ComputerStatus.IN_DANGER)
            {
                return Color.FromArgb(-1048576); // Red Color
                // style.ForeColor = Color.Black;
            }
            else if (status == ComputerStatus.AVAILABLE)
            {
                return Color.FromArgb(-16725986); // Green Color
                // style.ForeColor = Color.Black;
            }
            else if (status == ComputerStatus.IS_USED)
            {
                return Color.FromArgb(-659426); // Yellow Color
                // style.ForeColor = Color.Black;
            }
            else if (status == ComputerStatus.UNKNOWN)
            {
                return Color.FromArgb(-14803426); // Black Color
                // style.ForeColor = Color.Black;
            }

            return Color.Black;
        }
    }
}
