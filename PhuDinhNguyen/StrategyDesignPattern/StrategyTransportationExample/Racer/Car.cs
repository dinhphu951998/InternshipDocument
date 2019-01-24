using StrategyTransportationExample.IStrategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyTransportationExample.Racer
{
    class Car : IStrategyRaceable
    {
        public int Racing()
        {
            return 10; // time to finish
        }
    }
}
