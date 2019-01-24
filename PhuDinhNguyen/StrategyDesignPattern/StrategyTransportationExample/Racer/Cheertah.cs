using StrategyTransportationExample.IStrategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyTransportationExample.Racer
{
    class Cheertah : IStrategyRaceable
    {
        public int Racing()
        {
            return 1; // time to finish
        }
    }
}
