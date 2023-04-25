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
        public string type { get; }
        public string manufacturer { get; }
        public string serial_number { get; }
        public string CPU { get; }
        public string GPU { get; }
        public string RAM { get; }
        public string Storage { get; }
        public string ip_adress { get; }


        public Computer(int id, string ip_adress)
        {
            this.id = id;
            this.ip_adress = ip_adress;
        }

        public Computer(int id, string type, string manufacturer, string serial_number, string CPU, string GPU, string RAM, string Storage, string ip_adress) { 
            this.id = id;
            this.type = type;
            this.manufacturer = manufacturer;
            this.serial_number = serial_number;
            this.CPU = CPU;
            this.GPU = GPU;
            this.RAM = RAM;
            this.Storage = Storage;
            this.ip_adress = ip_adress;
        }

        public override string ToString()
        {
            return type + ", " + manufacturer + ", " + CPU + ", " + GPU + ", " + RAM + ", " + Storage;
        }
    }
}
