using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_BasicTutorial
{
    internal class _4DayAssignmentString
    {
        // Using For Loop
         void ReverseStringUsingForLoop(string str)
        {
            // Using For  Loop
            for (int i = str.Length - 1; i >= 0; i--)
            {
                Console.Write(str[i]);
                //reverseString.Append(toReverse[i]);

            }
        }
        
        // Using Build in Fuction
        void UsingBuildInFunction(string str)
        {
            //StringBuilder usingBuildIn= new StringBuilder(str.Reverse().ToArray());
            String newString = new String(str.Reverse().ToArray());
            Console.WriteLine(newString);




        }
        
        void ToCountCharacterUsingForLoop(string str){
            char[] strArray = str.ToCharArray();
            int count = 0;
            for (int i = 0; i < strArray.Length; i++)
            { 
                if( strArray[i] == 'b')
                {
                    count++;
                } 
                
            }

            Console.WriteLine($"B count {count}");


        }
        

        void TOCountNumberRecurrenceUsingLoop(int[] number, int toFind)
        {
            int count = 0;
            //for (int i = 0; i <number.Length; i++)
            //{
            //    if (number[])
            //}
            foreach (int i in number) { 
                if(i== toFind)
                {
                    count++;
                }
            }

            Console.WriteLine($"{toFind} is {count}");
        }
        
        void ArrayListDemo()
        {
            ArrayList list=new ArrayList();

            list.Add("sasa");
            list.Add(2);

        }
        public static void Main(string[] args)
        {
            _4DayAssignmentString obj = new _4DayAssignmentString();

            obj.ReverseStringUsingForLoop("automation");
            Console.WriteLine();    
            obj.UsingBuildInFunction("automation");

            obj.ToCountCharacterUsingForLoop("aabbbcc");

            obj.TOCountNumberRecurrenceUsingLoop([1,2,2,2,4,5],1);


        }
    }
}

//using System.Text;

//String toReverse = "automation";
////char[] reverseString = ;

//// Using For  Loop
//for (int i = toReverse.Length-1; i >= 0; i--){
//    Console.Write(toReverse[i]);  
//    //reverseString.Append(toReverse[i]);
    
//}

////String newReverse = toReverse.Reverse();

//// Using Built In Function 
//String newString = new String(toReverse.Reverse().ToArray());
//Console.WriteLine($" Reverse Array {newString}");

//// String Builder
//StringBuilder stringBuilder = new StringBuilder(toReverse);
//Console.WriteLine($"StringBuilder {stringBuilder}");









