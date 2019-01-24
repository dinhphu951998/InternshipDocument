using FactoryPatternExample_Transportation.Factory;
using FactoryPatternExample_Transportation.ObjectCreation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPatternExample_Transportation
{
    class Program
    {
        static void Main(string[] args)
        {
            string carName = Console.ReadLine();
            AutoFactory factory = new AutoFactory();
            IAuto car = factory.CreateInstance(carName);
            car.TurnOn();
            car.TurnOff();
            Console.ReadLine();
        }
    }
}
