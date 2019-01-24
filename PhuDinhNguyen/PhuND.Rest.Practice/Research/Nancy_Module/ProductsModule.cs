using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy;

namespace Research.Nancy_Module
{
    public class ProductsModule : NancyModule
    {
        
        public ProductsModule()
        {
            Get["/"] = _ => "Hello World!";
        }
    }
}