using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyDesignPattern.ConcreteStrategy
{
    class AlibabaStrategy : IShippingStrategy
    {
        private const int price = 500;

        public int CalculateShippingCost()
        {
            return price;
        }
    }
}
