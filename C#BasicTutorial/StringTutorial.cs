using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_BasicTutorial
{
    internal class StringTutorial
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("String Tutorial");

            int a = 10;

            String fName = "Jonh";
            String lName = "Nick";

            String fullName=String.Concat(fName," ",lName);
           
            Console.WriteLine($" FUll Name {fullName}");
            char[] nameArray = fullName.ToLower().ToCharArray();
            Console.WriteLine($" FUll Name Array  {nameArray}");
            foreach (var item in nameArray)
            {
                Console.WriteLine($" FUll Name Array  {item}");
            }


            String toReverse = "automation";
            for (int i = 0; i < toReverse.Length; i++) { 


            }
            

          

        }
    }
}
