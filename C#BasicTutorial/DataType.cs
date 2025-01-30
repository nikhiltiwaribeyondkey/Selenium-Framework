using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_BasicTutorial
{
    class BasicExample
    {
        int marks;
        string name;

        public void set(int marks, string name)
        {

            this.marks = marks;
            this.name = name;
        }

  public        void show() {
            Console.WriteLine($" Name {name} Marks {marks}");
        }
    }
    internal class DataType
    {
        public static void Main(string[] args)
        {

            int a = 10;
            String name = "name";
            float per = 5.4F;
            char chars = 'q';

            BasicExample example = new BasicExample();
            example.set(45, "Rohit");
            example.show();
            
        }
    }
}
