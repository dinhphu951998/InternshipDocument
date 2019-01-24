using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPatternExample_Transportation.ObjectCreation
{
    class BMW335Xi : IAuto
    {
        public void TurnOff()
        {
            Console.WriteLine("BMW 335 Xi is turned off");
        }

        public void TurnOn()
        {
            Console.WriteLine("BMW 335 Xi is turned on and is running");
        }
    }
}
