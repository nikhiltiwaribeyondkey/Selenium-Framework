using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace SeleniumC_Framework.utilities
{
    internal class JsonReader
    {

         
        public String? getData(String token)
        {
            TestContext.Progress.WriteLine("String We getting asckasc  " + token);
            var myJsonString = File.ReadAllText("C:\\Users\\nikhil.tiwari\\source\\repos\\C#BasicTutorial\\SeleniumC#Framework\\data\\JsonTestData.json");
            var jsonObject=JToken.Parse(myJsonString);
            return jsonObject.SelectToken(token).Value<String>();
           

        }


        public String[]? getArrayData(String token)
        {
            TestContext.Progress.WriteLine("String We getting " + token);
            var myJsonString = File.ReadAllText("C:\\Users\\nikhil.tiwari\\source\\repos\\C#BasicTutorial\\SeleniumC#Framework\\data\\JsonTestData.json");
            var jsonObject = JToken.Parse(myJsonString);
            List<String> array = jsonObject.SelectTokens(token).Values<String>().ToList<String>();

            foreach ( var item in array)
            {
                TestContext.Progress.WriteLine("String We getting  Arafxghsxv sxba " + item);

            }
            


            return array.ToArray();
       }


    }
}
