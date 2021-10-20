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

            //int levels = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine(Points(levels));

            //string postText = Console.ReadLine();
            //Post post = new Post();
            //post.Text = postText;
            //post.ShowPost();

            //int[] arr = new int[5];
            //for (int i = 0; i < 5; i++)
            //{
            //    arr[i] = Convert.ToInt32(Console.ReadLine());
            //}
            //Console.WriteLine(arr.Min() + arr.Max());

            int discount = Convert.ToInt32(Console.ReadLine());

            Dictionary<string, int> coffee = new Dictionary<string, int>();
            coffee.Add("Americano", 50);
            coffee.Add("Latte", 70);
            coffee.Add("Flat White", 60);
            coffee.Add("Espresso", 60);
            coffee.Add("Cappuccino", 80);
            coffee.Add("Mocha", 90);

            var name = coffee.Keys.ToArray();
            
            foreach (var item in name)
            {
                if (coffee.ContainsKey(item))
                {
                    var price = coffee[item];
                    double newPrice = discount/100;
  
                    price = price / 100 * discount;
                    Console.WriteLine(item + ": " + price);
                }
            }

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
            //if (levels == 0)
            //    return 0;
            //return levels + Points(levels - 1);

            return (levels == 0) ? 0: levels + Points(levels - 1);
        }
    }
}
