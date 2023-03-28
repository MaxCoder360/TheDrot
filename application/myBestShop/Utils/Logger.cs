using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myBestShop.Utils
{
    public class Logger
    {
        public static void print(string message)
        {
            Console.Write(message);
        }

        public static void println(string message)
        {
            Console.WriteLine(message);
        }
    }
}
