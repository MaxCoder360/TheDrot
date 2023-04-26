using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;

namespace myBestShop.Domain.Entities
{
    public class Session
    {
        public int id_session { get; }
        public DateTime start_time_rent { get; }
        public DateTime end_time_rent { get; }
        public int id_admin { get; }
        public int id_user { get; }
        public int id_computer { get; }
        public string name { get; }
        public string surname { get; }
        
        public Session (int id_session, DateTime start_time_rent, DateTime end_time_rent, int id_admin, int id_computer, int id_user, string name, string surname )
        {
            this.id_session = id_session;
            this.name = name;
            this.surname = surname;
            this.id_admin = id_admin;
            this.end_time_rent = end_time_rent;
            this.start_time_rent = start_time_rent;
            this.id_user = id_user;
            this.id_computer = id_computer;
        }
    }
}
