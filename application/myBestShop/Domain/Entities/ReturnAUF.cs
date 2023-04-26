using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myBestShop.Domain.Entities
{
    public class ReturnAUF
    {
        public int id;
        public bool is_admin;
        public ReturnAUF(int id, string is_admin)
        {
            this.id = id;
            this.is_admin = (is_admin == "1");
        }
    }
}
