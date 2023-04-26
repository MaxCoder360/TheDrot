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
        public int id { get; }
        public string name { get; }
        public string surname { get; }
        public int id_session { get; }
        /*public DateTime*/
        public Session (int id, string name, string surname, int IDictionar)
        { 
        }
    }
}
