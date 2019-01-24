using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPatternExample_Transportation.ObjectCreation
{
    class MiniCooper : IAuto
    {
        public void TurnOff()
        {
            Console.WriteLine("Mini Cooper is turned off");
        }

        public void TurnOn()
        {
            Console.WriteLine("Mini Cooper is turned on and is running");
        }
    }
}
