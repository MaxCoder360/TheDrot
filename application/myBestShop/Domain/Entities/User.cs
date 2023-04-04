using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myBestShop.Domain.Entities
{
    public class User
    {
        public int id { get; }
        public string name { get; }
        public string surname { get; }
        public int computerId { get; }

        public User(int id, string name, string surname, int computerId)
        {
            this.id = id;
            this.name = name;
            this.surname = surname;
            this.computerId = computerId;
        }

        public User(int id, int computerId)
        {
            this.id = id;
            this.computerId = computerId;
        }
    }
}
