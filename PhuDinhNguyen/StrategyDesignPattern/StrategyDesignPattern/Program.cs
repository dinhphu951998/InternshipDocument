using StrategyDesignPattern.ConcreteStrategy;
using StrategyDesignPattern.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyDesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Choosing the shipping service: ");
            ShippingCalculatorService service = new ShippingCalculatorService(new FedExStrategy());
            Console.WriteLine(service.CalculateCost());
            Console.Read();
        }
    }
}
