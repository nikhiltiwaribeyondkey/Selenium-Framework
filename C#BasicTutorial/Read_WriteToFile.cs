using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_BasicTutorial
{
    internal class Read_WriteToFile
    {

        public static void Main(string[] args)
        {


            String[] names = { "twestting1", "testing 7" };

            //using (StreamWriter writer = new StreamWriter("C:\\Users\\nikhil.tiwari\\source\\repos\\abc.txt", append: true))
            using (StreamWriter writer = new StreamWriter("abc.txt",append:true))
            {
                foreach (string name in names)
                {
                    writer.WriteLine(name);
                }
            }
            Console.WriteLine("Writing Done ");

            Console.WriteLine("Reading File  Done ");
            using (StreamReader reader = new StreamReader("abc.txt"))
            {
                while (reader.ReadLine()!=null) { 
                    Console.WriteLine(reader.ReadLine());
                }
            }


        }
    }
}
