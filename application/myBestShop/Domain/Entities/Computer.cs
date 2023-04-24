using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myBestShop.Domain.Entities
{
    public class Computer
    {
        public int id { get; }

        public string ip_adress { get; }

        public Computer(int id, string ip_adress)
        {
            this.id = id;
            this.ip_adress = ip_adress;
        }
    }
}
