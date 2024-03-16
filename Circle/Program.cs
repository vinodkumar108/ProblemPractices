using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circle
{
    class Program
    {
        static void Main(string[] args)
        {
        }
        class Circle
        {
            // Define properties here
            float radius;

            // Define constructor here
            public Circle(float r)
            {
                this.radius = r;
            }


            public float perimeter()
            {
                // Complete the function
                return (float)(2 * 3.14 * this.radius);

            }

            public float area()
            {
                // Complete the function
                return (float)(3.14 * this.radius * this.radius);

            }
        };

        /*
            Circle a = new Circle(3)  // Radius = 3
            a.perimeter() // 18.84
            a.area() // 28.26
        */
    }
}
