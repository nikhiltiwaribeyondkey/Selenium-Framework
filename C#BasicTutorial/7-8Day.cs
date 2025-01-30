using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_BasicTutorial
{

    class Animal
    {
       public virtual void feature()
        {
            Console.WriteLine("Dog Bark");
        }
    }


    class Dog:Animal
    {
        public override void feature()
        {
            Console.WriteLine(" Dog have Four Leg");
        }
    }
    class Rectangle
    {
        private float width;
        private float height;
        private float area;


       public void setValue(float height, float width)
        {
            this.height = height;
            this.width = width;
        }

        public float getArea() { return height * width; }
    }
    internal class _7_8Day
    {
               public static  void Main(string[] args)
            {
            Rectangle rect = new Rectangle();
            //rect.width = 20.4F;
            rect.setValue(20.9F, 13.4F);

            Console.WriteLine($"Area is -- {rect.getArea()}");  


            Dog dog=new Dog();
            dog.feature();

            Animal animal=new Animal(); 
            animal.feature();   

            }   
    }
}
