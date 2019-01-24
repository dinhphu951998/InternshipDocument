using Nancy;
using Nancy.Bootstrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationDemoNancy.Route_Config
{
    public class CustomNancyBootstrapper : DefaultNancyBootstrapper
    {
        protected override NancyInternalConfiguration InternalConfiguration
        {
            get
            {
                return NancyInternalConfiguration.WithOverrides(config =>
                {
                    config.TrieNodeFactory = typeof(MyTrieNodeFactory);
                });
            }
        }
    }
}
