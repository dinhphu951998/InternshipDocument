using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Transportation.Framework.Models;

namespace Transportation.BusinessLogic.Logic
{
    public interface IVehicleBusinessLogic
    {
        IEnumerable<Vehicle> GetVehicles();
        void AddVehicle(Vehicle Vehicle);
        Vehicle Find(int Id);
        void UpdateVehicle(Vehicle vehicle);
        void DeleteVehicle(Vehicle vehicle);
    }
}