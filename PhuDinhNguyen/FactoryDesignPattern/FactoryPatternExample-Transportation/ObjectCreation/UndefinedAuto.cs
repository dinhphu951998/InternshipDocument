using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPatternExample_Transportation.ObjectCreation
{
    class UndefinedAuto : IAuto
    {
        public void TurnOff()
        {
            Console.WriteLine("An undefined auto is turned off");
        }

        public void TurnOn()
        {
            Console.WriteLine("An undefined auto is turned on and is running");
        }
    }
}
