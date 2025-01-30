using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_BasicTutorial
{
    class BaseClass
    {

        virtual public void calling()
        {
            Console.WriteLine(" Calling Base Class");
        }
    }

    class ChildClass:BaseClass
    {
        override public void calling()
        {
            Console.WriteLine(" Calling Child Class");
        }

        public int  adding(int a, int b)
        {
            return a + b;

        }
        public int    adding(int a, int b, int c)
        {
return a + b + c;   
        }
        public int adding(int a, int b, int c,int d)
        {
            return a + b + c+d;
        }
    }

    internal class Polymorphism
    {
        public static void Main(string[] args) {

            ChildClass c = new ChildClass();
            //BaseClass c = new ChildClass();
            c.calling();

            Console.WriteLine($" Sum is {c.adding(3, 4)}");
            Console.WriteLine($" Sum is {c.adding(3, 4,5)}");

            //BaseClass baseClass = new BaseClass();


        }
    }
}
