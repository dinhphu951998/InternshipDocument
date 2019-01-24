using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyDesignPattern.Context
{
    class ShippingCalculatorService
    {
        private IShippingStrategy strategy;

        public ShippingCalculatorService(IShippingStrategy strategy)
        {
            this.strategy = strategy;
        }

        public int CalculateCost()
        {
            return strategy.CalculateShippingCost();
        }

    }
}
