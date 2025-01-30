using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_BasicTutorial
{
    internal class CollectionFramework
    {
        public static void Main(String[] args)
        {
            // 
            ArrayList arrayList = new ArrayList();
            arrayList.Add(1);
            arrayList.Add("Name");
            arrayList.Add("Name");
            foreach (var   i in arrayList) {
                Console.WriteLine($"Item are - {i} ");
            }


            Hashtable ht = new Hashtable();

            ht.Add("1",1);
            ht.Add("Name","Name");
            ht.Add("arraylist",arrayList);

            if (!ht.Contains("Name")){ 
                ht.Add("Name", "Name");
            }



            foreach (var item in ht)
            {
                Console.WriteLine($"Item of HashTable - {item} ");
            }

            try
            {

                // 
                Dictionary<string, int> map = new Dictionary<string, int>();
                map.Add("a", 1);
                map.Add("b", 2);

                //map.Add("a", 3);

                foreach (var i in map)
                {
                    Console.WriteLine($" Key {i.Key} value {i.Value}");

                }
            }
            catch (Exception ex) {
                Console.WriteLine($"Exception  {ex.Message}");
            }

            

        }
    }
}
