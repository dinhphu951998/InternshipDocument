using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Repository;
using Transportation.BusinessLogic.Logic;
using Repository.Repository;
using Transportation.Framework.Models;

namespace Transportation.BusinessLogic
{
    public class VehicleBusinessLogic : IVehicleBusinessLogic
    {
        private IBaseRepository<Vehicle> repository;

        public VehicleBusinessLogic(IBaseRepository<Vehicle> repository)
        {
            this.repository = repository;
        }

        public void AddVehicle(Vehicle Vehicle)
        {
            repository.Add(Vehicle);
        }


        public IEnumerable<Vehicle> GetVehicles()
        {
            return this.repository.GetAll();
        }

        public Vehicle Find(int Id)
        {
            return this.repository.Find(Id);
        }

        public void UpdateVehicle(Vehicle vehicle)
        {
            this.repository.Update(vehicle);
        }

        public void DeleteVehicle(Vehicle vehicle)
        {
            this.repository.Delete(vehicle);
        }
    }
}