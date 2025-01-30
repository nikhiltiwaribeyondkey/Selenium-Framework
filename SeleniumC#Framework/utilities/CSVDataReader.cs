using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumC_Framework.utilities
{
    internal class CSVDataReader
    {
        private List<TestData> testDataList;

        public class TestData
        {
            public string userName { get; set; }
            public string password { get; set; }
            public string product1 { get; set; }
            public string product2 { get; set; }
        }

        //public List<TestData> getTestDataCSV()
        //{

        //    using var reader = new StreamReader("data/testDataCSV.csv");
        //     using(var csv= new CSVDataReader(reader, new CsvConfi))
        //}
    }
}
