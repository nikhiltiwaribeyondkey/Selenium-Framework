using System;
using System.ComponentModel;

namespace Demo
{

    interface IAnimal
    {
        void name();
        void sound();
    }

    class Dog : IAnimal
    {
        public void name()
        {
            Console.WriteLine("Dog");
        }

        public void sound()
        {
            Console.WriteLine("Bark");
        }
    }

    class Cat : IAnimal
    {
        public void name()
        {
            Console.WriteLine("Cat");
        }

        public void sound()
        {
            Console.WriteLine("Meow");
        }
    }
    class Example
    {  static void Main(String[] args)
        {

            Cat c = new Cat();
            c.name();   
            c.sound();

            Dog d = new Dog();
            d.name();
            d.sound();

            //System.Console.WriteLine("asdbaka ks k");
            //int number = 10;
            //String name = "Nikhil";
            //float per = 10.5f;


            //System.Console.WriteLine($"Type of Number {per}");

            //int[] arrayy = { 1, 2, 34, 5 };
            //String[] nameList = { "asfsamf", "afafn", "asdmasd" };

            //for(int i = 0; i <= nameList.Length; i++)
            //{

            //}







        }
    }
}