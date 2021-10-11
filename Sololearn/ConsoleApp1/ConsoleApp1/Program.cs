using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int totalPrice = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine(Discount(totalPrice));
            Console.ReadLine();
        }

        static int Discount(int price)
        {
            if (price >= 10000)
                return Convert.ToInt32(price - (0.2 * price));
            else
                return price;
        }
    }
}
