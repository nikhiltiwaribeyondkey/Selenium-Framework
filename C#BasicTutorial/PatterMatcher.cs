using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace C_BasicTutorial
{

   
    internal class PatterMatcher
    {
        static  public void showMatcher(String text, String pattern)
        {
            MatchCollection mc= Regex.Matches(text, pattern);
           
            foreach (Match item in mc)
            {
                Console.WriteLine(item);
                
            }


        }
        public static  void Main(String[] args)
        {
            showMatcher("this is My String ",@"\bS\S*");
        }
    }
}
