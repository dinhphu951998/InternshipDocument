using StrategyTransportationExample.Context;
using StrategyTransportationExample.Racer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyTransportationExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car();
            Cheertah cheertah = new Cheertah();
            RacingCompetition competition = new RacingCompetition();
            competition.StartRacingCompetition(car, cheertah);
            Console.Read();
        }
    }
}
