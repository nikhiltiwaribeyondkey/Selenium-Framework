using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_BasicTutorial
{

    internal class _5_6DayAssArrayList
    {

       static void SortArrayElement(int[] array)
        {
           for (int i = 0; i < array.Length; i++)
            {

                for(int j =0; j <= array.Length-1; j++)
                {
                     if (array[i] <= array[j])
                    {
                       int temp = array[i];
                        array[i] = array[j];
                        array[j]=temp;
                        
                    }
                }
            }
            //Console.WriteLine(array.ToString);
            foreach (int i in array)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine($"[{string.Join(", ", array)}]");


            // For largest Element in Array  
            Console.WriteLine($"Largest Element {array[array.Length-1]}");
            // OR 
            Console.WriteLine($"[{string.Join(", ", array.Last())}]");

        }
       
        static void largestElementInArray(int[] array)
        {
           
        }
        public static void Main(string[] args)
        {

            SortArrayElement([3, 1, 2, 0, 15, 4]);
        } 

    }
}
