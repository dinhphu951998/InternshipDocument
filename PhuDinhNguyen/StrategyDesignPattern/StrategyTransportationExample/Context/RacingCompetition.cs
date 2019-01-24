using StrategyTransportationExample.IStrategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyTransportationExample.Context
{
    class RacingCompetition
    {
        public void StartRacingCompetition(IStrategyRaceable racer1, IStrategyRaceable racer2)
        {
            int pointRacer1 = racer1.Racing();
            int pointRacer2 = racer2.Racing();
            if(pointRacer1 < pointRacer2)
            {
                Console.WriteLine("Racer 1 win");
            }else if(pointRacer1 > pointRacer2)
            {
                Console.WriteLine("Racer 2 win");
            }else
            {
                Console.WriteLine("Draw");
            }
        }

    }
}
