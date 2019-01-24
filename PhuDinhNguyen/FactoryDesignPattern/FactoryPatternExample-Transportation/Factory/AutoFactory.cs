using FactoryPatternExample_Transportation.ObjectCreation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPatternExample_Transportation.Factory
{
    class AutoFactory
    {
        private Dictionary<string, Type> autos;

        public AutoFactory()
        {
            LoadAutoFactories();
        }

        public IAuto CreateInstance(string typeName)
        {
            IAuto instance = null;
            Type type = getCarType(typeName);
            if (type == null)
            {
                instance = new UndefinedAuto();
            }
            else
            {
                instance = Activator.CreateInstance(type) as IAuto;
            }
            return instance;
        }

        private Type getCarType(string carName)
        {
            foreach (var auto in autos)
            {
                if (auto.Key.ToLower().Contains(carName.ToLower()))
                {
                    return auto.Value;
                }
            }
            return null;
        }


        private void LoadAutoFactories()
        {
            if (autos == null)
            {
                autos = new Dictionary<string, Type>();
            }
            Type[] types = Assembly.GetExecutingAssembly().GetTypes();
            foreach (var type in types)
            {
                if (typeof(IAuto).IsAssignableFrom(type))
                {
                    string typeName = type.Name;
                    autos.Add(typeName, type);
                }
            }
        }
    }

}
