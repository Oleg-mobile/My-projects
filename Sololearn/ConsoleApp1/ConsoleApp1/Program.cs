using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main()
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

            //int discount = Convert.ToInt32(Console.ReadLine());
<<<<<<< HEAD

            //Dictionary<string, int> coffee = new Dictionary<string, int>();
            //coffee.Add("Americano", 50);
            //coffee.Add("Latte", 70);
            //coffee.Add("Flat White", 60);
            //coffee.Add("Espresso", 60);
            //coffee.Add("Cappuccino", 80);
            //coffee.Add("Mocka", 90);

            //var name = coffee.Keys.ToArray();

            //foreach (var item in name)
            //{
            //    if (coffee.ContainsKey(item))
            //    {
            //        var price = coffee[item];
            //        int newPrice = price - price * discount / 100;

            //        Console.WriteLine(item + ": " + newPrice);
            //    }
            //}

            string inpupString = "5*(7-4)";
            if (IsStringCorrect(inpupString))
                Console.WriteLine(GetSubStr(inpupString));

            Console.ReadLine();
        }

        static bool IsStringCorrect(string inpStr)
        {
            int op = 0, cl = 0;
            if (inpStr == null || inpStr == "") return false;

            foreach (char ch in inpStr)
            {
                if (ch.Equals('(')) op++;
                if (ch.Equals(')')) cl++;
                //if (ch)
            }
            if (op != cl) return false;

            return true;
        }

        static string GetSubStr(string inpStr)
        {
            string subStr = "";

            for (int i = 0; i < inpStr.Length; i++)
            {
                if (inpStr[i].Equals(')'))
                {
                    for (int j = i - 1; j >= 0; j--)
                    {
                        if (inpStr[j].Equals('('))
                        {
                            subStr = inpStr.Substring(j + 1, i - j - 1);
                        }
                    }
                }
            }
            return subStr;
=======

            //Dictionary<string, int> coffee = new Dictionary<string, int>();
            //coffee.Add("Americano", 50);
            //coffee.Add("Latte", 70);
            //coffee.Add("Flat White", 60);
            //coffee.Add("Espresso", 60);
            //coffee.Add("Cappuccino", 80);
            //coffee.Add("Mocha", 90);

            //var name = coffee.Keys.ToArray();

            //foreach (var item in name)
            //{
            //    if (coffee.ContainsKey(item))
            //    {
            //        var price = coffee[item];
            //        int newPrice = price - price * discount / 100;

            //        Console.WriteLine(item + ": " + newPrice);
            //    }
            //}

            //Enumerable.Range(1, 10).ForEach(x => Console.Write("Привет!)"));

            Samp2.G(); // class
            Samp2.H(); // H
>>>>>>> 033225fc5e32c3c0151791f8f51dea238ac234fa

        }

        static int Discount(int price)  //  цена с учётом скидки
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
    public static class Samp1
    {
        static void F()
        {
            i = 1;
        }
        static int i = 0;
    }

    public static class Samp2
    {
        static string who = "class";

        public static void F()
        {
            string who = "F";
        }

        public static void G()
        {
            F();
            Console.WriteLine(who);
        }

        public static void H()
        {
            string who = "H";
            F();
            Console.WriteLine(who);
        }
    }

    public static class Samp3
    {
        //static string who = "class";
        //static void Mixed()
        //{
        //    Console.WriteLine(who + " ");  // переменная не инициализирована!!!
        //    string who = "Mixed";
        //    Console.WriteLine(who);
        //}
    }

    public static class Samp4
    {
        static void M1()
        {
            int i = 0;
            {
                int i = 1;  // имя используется
            }
        }
        static void M2(int i)
        {
            int i = 0;     // имя используется
        }
        static void M3()
        {
            {
                int i = 0;
            }
            {
                int i = 1;
            }
        }
    }
}
