using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace C_BasicTutorial
{
    public class ChildClass : InheritanceEngine
    {

        public  void showMsg()
        {
            Console.WriteLine($"Calling Child Class Function");
        }
    }
    internal class InheritanceChildClass 
    {
        public static void Main(String[] args)
        {
            ChildClass childObj = new ChildClass();

            childObj.showMsg();
            childObj.setEngine("Kia","2024");
            childObj.GetEngineName();
        } 
    }
}
