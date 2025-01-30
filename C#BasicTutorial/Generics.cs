using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_BasicTutorial
{
    internal class Generics
    {

       static  void Swap<T>(ref T a,ref T b)
        {
            T temp = a;
            a = b;
            b = temp;

        }

        public static void Main(string[] args) {

            int x = 5;
            int y = 10;
            Console.WriteLine($"Before Swap: x = {x}, y = {y}");
            Swap(ref x, ref y);
            Console.WriteLine($"After Swap: x = {x}, y = {y}");

            string str1 = "Hello";
            string str2 = "World";
            Console.WriteLine($"Before Swap: str1 = {str1}, str2 = {str2}");
            Swap(ref str1, ref str2);
            Console.WriteLine($"After Swap: str1 = {str1}, str2 = {str2}");
        }

    }
}
