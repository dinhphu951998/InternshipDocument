using StrategyTransportationExample.IStrategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyTransportationExample.Racer
{
    class Bike : IStrategyRaceable
    {
        public int Racing()
        {
            return 20; // time to finish
        }
    }
}
