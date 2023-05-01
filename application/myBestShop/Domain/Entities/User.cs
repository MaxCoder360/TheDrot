using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Controls;

namespace myBestShop.Domain.Entities
{
    public class User
    {
        public int id { get; }
        public string mail { get; }
        public string password { get; }
        public string name { get; }
        public string surname { get; }
        public string phone_number { get; }
        public string passport { get; }
        public string admin { get; }
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

        public User(string mail, string password, string name, string surname, string phone_number, string passport, string admin)
        {
            this.mail = mail;
            this.password = password;
            this.name = name;
            this.surname = surname;
            this.phone_number = phone_number;
            this.passport = passport;
            this.admin = admin;
        }
        public User(int id, string name, string surname, string phone_number, string mail)
        {
            this.id = id;
            this.name = name;
            this.surname = surname;
            this.phone_number = phone_number;
            this.mail = mail;
        }
    }
}
