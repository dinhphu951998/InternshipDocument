using Nancy.Hosting.Self;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationDemoNancy
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var host = new NancyHost(new Uri("http://localhost:12345")))
            {
                host.Start();

                Console.WriteLine("Nancy is running!");
                Console.WriteLine("Press enter to exit the application");
                Console.ReadLine();
            }

        }
    }
}
