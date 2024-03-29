﻿using System;
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
        public ComputerStatus status { get; private set; }

        public ComputerWrapper(int computerId, ComputerStatus status)
        {
            this.computerId = computerId;
            this.status = status;
        }

        public Pair<Color, string> convertStatusToTableViewFormat()
        {
            if (status == ComputerStatus.UNAVAILABLE)
            {
                return new Pair<Color, string>(Color.FromArgb(-6118750), "На ремонте"); // Grey Color
                // style.ForeColor = Color.Black;
            } else if (status == ComputerStatus.IN_DANGER)
            {
                return new Pair<Color, string>(Color.FromArgb(-1048576), "Под угрозой"); // Red Color
                // style.ForeColor = Color.Black;
            }
            else if (status == ComputerStatus.AVAILABLE)
            {
                return new Pair<Color, string>(Color.FromArgb(-16725986), "Свободен"); // Green Color
                // style.ForeColor = Color.Black;
            }
            else if (status == ComputerStatus.IS_USED)
            {
                return new Pair<Color, string>(Color.FromArgb(-659426), "Занят"); // Yellow Color
                // style.ForeColor = Color.Black;
            }
            else if (status == ComputerStatus.UNKNOWN)
            {
                return new Pair<Color, string>(Color.FromArgb(-14803426), "Статус неизвестен"); // Black Color
                // style.ForeColor = Color.Black;
            }

            if (AppConfig.BUILD_CONFIG == AppConfig.ConfigType.DEBUG_CONFIG)
            {
                throw new Exception("Status is undefined");
            } else
            {
                Logger.println("Status is undefined");
                return new Pair<Color, string>(Color.FromArgb(-14803426), "Статус неизвестен"); // Black Color
            }
        }
    }
}
