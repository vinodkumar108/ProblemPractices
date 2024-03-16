using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompareCar
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Car> lstCar = new List<Car>();

            lstCar.Add(new Car("C1", 100, 10));
            lstCar.Add(new Car("C2", 39, 10));
            lstCar.Add(new Car("C3", 33, 10));
            lstCar.Add(new Car("C4", 35, 10));

            foreach (var item in lstCar)
            {
                Console.WriteLine("Without Sort Car Name:" + item.name);
            }

            Console.Write("Sorting Method Call");
            Console.Write("--------------------------------");

            lstCar.Sort(new CarComparer());

            foreach(var item in lstCar)
            {
                Console.WriteLine("Car Name:" + item.name);
            }

            Console.Read();
        }
    }

    class Car
    {
        public string name;
        public int distance;
        public int hours;
        public double avgSpeed;

        public Car(string name,int dis,int hr)
        {
            this.name = name;
            this.distance = dis;
            this.hours = hr;
            this.avgSpeed = ((double)distance) / (double)hours;
        }
    }

    public class CarComparer:IComparer<Car>
    {
        int IComparer<Car>.Compare(Car x, Car y)
        {

            return x.distance - y.distance;
            //if(x.avgSpeed < y.avgSpeed)
            //{
            //    return -2;
            //}
            //else if(x.avgSpeed > y.avgSpeed)
            //{
            //    return 2;
            //}
            //else
            //{
            //    return 0;
            //}
        }
    }
}
