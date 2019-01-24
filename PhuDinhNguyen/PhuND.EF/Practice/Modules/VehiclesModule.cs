using AutoMapper;
using Nancy;
using Nancy.ModelBinding;
using Practice.View_Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Transportation.BusinessLogic.Logic;
using Transportation.Framework.Models;

namespace Practice.Modules
{
    public class VehiclesModule : NancyModule
    {
        private IVehicleBusinessLogic VehicleLogic;
        private IMapper mapper;

        public VehiclesModule(IVehicleBusinessLogic VehicleLogic, IMapper mapper)
        {
            this.VehicleLogic = VehicleLogic;
            this.mapper = mapper;

            Get["/vehicles"] = _ =>
            {
                int? index = Request.Query["index"];
                int? size = Request.Query["size"];
                
                var vehicles = this.VehicleLogic.GetVehicles();
                if (index != null && size != null)
                {
                    vehicles = vehicles.OrderBy(v => v.Id)
                                       .Skip(index.Value * size.Value)
                                       .Take(size.Value);
                }
                var result = mapper.Map<List<VehicleResponseViewModel>>(vehicles.ToList());
                return Response.AsJson(result, HttpStatusCode.OK);
            };

            Get["/vehicles/{Id:int}"] = parameter =>
            {
                int? Id = parameter["Id"];
                if (Id != null)
                {
                    var vehicle = this.VehicleLogic.Find(Id.Value);
                    var result = mapper.Map<VehicleResponseViewModel>(vehicle);
                    return Response.AsJson(result, HttpStatusCode.OK);
                }
                return Response.AsJson(new { message = "fail" }, HttpStatusCode.NotAcceptable);
            };

            Get["/vehicles/{Id:int}/owner"] = parameter =>
            {
                int? Id = parameter["Id"];
                if (Id != null)
                {
                    var vehicle = this.VehicleLogic.Find(Id.Value);
                    Owner owner = vehicle.Owner;
                    var result = mapper.Map<OwnerResponseViewModel>(owner);
                    return Response.AsJson(result, HttpStatusCode.OK);
                }
                return Response.AsJson(new { message = "fail" }, HttpStatusCode.NotAcceptable);
            };

            Post["/vehicles"] = parameter =>
           {
               var newEntity = this.Bind<Vehicle>();
               VehicleLogic.AddVehicle(newEntity);
               return Response.AsJson(new { message = "success" })
                              .WithHeader("Location", "vehicles/" + newEntity.Id);
           };

            Put["/vehicles"] = parameter =>
            {
                var vehicle = this.Bind<Vehicle>();
                //var entity = VehicleLogic.Find(vehicle.Id);
                if (vehicle != null)
                {
                    this.VehicleLogic.UpdateVehicle(vehicle);
                    VehicleResponseViewModel viewModel = mapper.Map<VehicleResponseViewModel>(vehicle);
                    return Response.AsJson(viewModel);
                }
                return Response.AsJson(new { message = "fail" }, HttpStatusCode.NotFound);
            };

            Delete["/vehicles/{Id:int}"] = parameter =>
            {
                int? Id = parameter["Id"];
                if (Id != null)
                {
                    var vehicleEntity = VehicleLogic.Find(Id.Value);
                    if (vehicleEntity != null)
                    {
                        VehicleLogic.DeleteVehicle(vehicleEntity);
                        return Response.AsJson(new { message = "success" });
                    }
                    return Response.AsJson(new { message = "fail" }, HttpStatusCode.BadRequest); 
                }
                return Response.AsJson(new { message = "fail" }, HttpStatusCode.NotAcceptable);
            };

            Get["/"] = _ =>
            {
                return "Hello world";
            };
        }


    }
}