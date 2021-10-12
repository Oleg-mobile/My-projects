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
            //int totalPrice = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine(Discount(totalPrice));

            //DrawPyramid(6);

            int levels = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(Points(levels));

            Console.ReadLine();
        }

        static int Discount(int price)  //  чена с учётом скидки
        {
            if (price >= 10000)
                return Convert.ToInt32(price - (0.2 * price));
            else
                return price;
        }

        static void DrawPyramid(int n) // рисует пирамиду
        {
            for (int i = 1; i <= n; i++)  // построчно
            {
                for (int j = i; j <= n; j++)  // рисует пробелы
                {
                    Console.Write("  ");
                }
                for (int k = 1; k <= 2 * i - 1; k++)  // рисует звёздочки
                {
                    Console.Write("*" + " ");
                }
                Console.WriteLine();
            }
        }

        static int Points(int levels)
        {
            if (levels == 0)
                return 0;
            return levels + Points(levels - 1);
        }
    }
}
