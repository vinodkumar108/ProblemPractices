using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS
{
    class Program
    {
        static void Main(string[] args)
        {
            A objA = new A();
            B objB = new B();
            A objC = new B();


            objA.Display();
            objA.Print();


            objB.Display();
            objB.Print();


            objC.Display();
            objC.Print();

            int val = (int)FileTypes.word;
            int val1 = (int)FileTypes.excel;
            int val2 = (int)FileTypes.txt;

            Console.WriteLine(val);
            Console.WriteLine(val1);
            Console.WriteLine(val2);

            Console.Read();
        }
    }

    public enum FileTypes
    {
        word,
        excel,
        pdf=100,
        txt
    }

    class A
    {

        public virtual void Display()
        {
            Console.WriteLine("Display-A");
        }
        public void Print()
        {
            Console.WriteLine("Print-A");
        }

    }

    class B : A
    {

        public override void Display()
        {
            Console.WriteLine("Display-B");
        }

        public new void Print()
        {
            Console.WriteLine("Print-B");
        }
    }

}
