//using System;
//using System.Collections.Generic;
using System.Diagnostics;

namespace C_BasicTutorial
{
  public  class InheritanceEngine
    {
        String engineName;
        String model;

        public void setEngine(String engineName,String modelNumber)
        {
            this.engineName = engineName;
            this.model = modelNumber;
        }
       public  void GetEngineName()
        {
            Console.WriteLine($"Engine Name For Engine Class -- {engineName} and Model Number -- {model}");
        }


}
}

//namespace C_BasicTutorial
//{
//    public class InheritanceEngineBaseClass
//    {
//    }
//}
