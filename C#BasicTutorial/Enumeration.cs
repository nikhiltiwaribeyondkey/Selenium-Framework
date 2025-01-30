using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_BasicTutorial
{
    internal class Enumeration
    {
        enum WeekDays
        {
            monday,
            tuesday,
            wednesday,
            
        }

        public static void Main()
        {
            WeekDays weekDays = WeekDays.monday;
            switch (weekDays) {
                case WeekDays.monday: Console.WriteLine("Monday");
                    break;
                case WeekDays.tuesday:
                    Console.WriteLine("Tuesday");
                    break;

                default:
                    Console.WriteLine("SUnday");
                    break;
            }
        }
    }
}
