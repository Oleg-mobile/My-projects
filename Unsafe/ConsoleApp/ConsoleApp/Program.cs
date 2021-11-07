using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        // ConsoleApp -> properties -> build -> allow unsafe code
        static void Main(string[] args)
        {
            unsafe  // keyword for using unsafe code
            {
                int i = 30;
                int* address = &i;  // declaring a pointer and
                                    // getting the address of the first memory location
                                    // of the variable i
                void* pointer;  // void pointer
                pointer = &i;
                Console.WriteLine("Value i: {0}", *address);  // dereference, return 30
                Console.WriteLine("Value (void) i: {0}", *(int*)pointer);  // void pointer
                Console.WriteLine("Address i: {0}", (long)address);  // for x64 use long, return address
                Console.WriteLine();

                int a = 5;
                int b = 7;
                Calc(a, &b);
                Console.WriteLine("Value a: {0}", a);  // return 5
                Console.WriteLine("Value b: {0}", b);  // return 700, because it was passed by the link
                Console.WriteLine();

                Calc2(a, ref b);
                Console.WriteLine("Value a: {0}", a);  // return 5
                Console.WriteLine("Value b: {0}", b);  // return 800
                Console.WriteLine();

                int** adr = &address;  // a pointer to a pointer or the address of a variable address
                Console.WriteLine("Address of the pointer to i: {0}", (long)adr);  // return address of the memory cell
                Console.WriteLine("Address i: {0}", (long)*adr);  // return address of the variable
                Console.WriteLine("Value i: {0}", **adr);  // return the value of the variable = 30
                Console.WriteLine();

                Console.WriteLine("Sqr a: {0}", * MySqr(&a));
                Console.WriteLine();

                int[] arr = {1, 7, 3, 6, 2};

                fixed (int* parr = arr)
                {
                    int ind;
                    for (ind = 0; ind < 5; ++ind)
                    {
                        Console.WriteLine("arr[{0}]: {1}", ind, parr[ind]);
                    }
                    Console.WriteLine("Number of elements: {0}", ((*parr + ind) - *parr));
                }
                Console.WriteLine();

                string str = "Pensilvania";
                char[] strArr = str.ToCharArray();
                Console.WriteLine("The length of the string 'Pennsylvania': {0}", StrLength(strArr));

                Console.ReadLine();
            }
        }

        public static unsafe void Calc(int i, int* j)  // value type and a reference to a value type
        {
            i = 500;
            *j = 700;
        }

        public static void Calc2(int i, ref int j)  // safe option
        {
            i = 600;
            j = 800;
        }

        public static unsafe int* MySqr(int* i)
        {
            int rez;
            rez = *i * *i;
            return &rez;
        }

        public static unsafe int StrLength(char[] str)  // string length
        {
            int index;  // offset
            fixed (char* pstr = str)
            {
                for (index = 0; *(pstr + index) != '\0'; index++)  // \0 - the symbol of the end of the string
                    {}
                return index;
            }
        }
    }
}
