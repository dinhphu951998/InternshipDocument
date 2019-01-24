using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyDesignPattern.ConcreteStrategy
{
    public class FedExStrategy : IShippingStrategy
    {
        private const int price = 100;

        public int CalculateShippingCost()
        {
            //There might be more complex algorithms
            return price;
        }
    }
}
