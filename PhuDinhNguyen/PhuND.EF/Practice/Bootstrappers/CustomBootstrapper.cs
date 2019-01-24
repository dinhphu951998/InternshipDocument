using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy.TinyIoc;
using Transportation.BusinessLogic.Logic;
using Transportation.BusinessLogic;
using System.Data.Entity;
using Repository;
using AutoMapper;
using Practice.View_Models;
using Practice.Auto_Mapper;
using Repository.Repository;
using Transportation.Framework.Models;
using Nancy.Hosting.Aspnet;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Practice.Bootstrappers
{
    public class CustomBootstrapper : DefaultNancyBootstrapper
    {
        private string connectionString = 
                ConfigurationManager.ConnectionStrings["TransportationManagementEntitiesDapper"].ConnectionString;

        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            container.Register<IVehicleBusinessLogic, VehicleBusinessLogic>();

            container.Register<IBaseRepository<Vehicle>, DVehicleRepository>();

            container.Register<IDbConnection>(new SqlConnection(connectionString));

            container.Register<DbContext, TransportationManagementEntities>().AsPerRequestSingleton();

            container.Register<IMapper, IMapper>(AutoMapperConfiguration.GetInstance());

            base.ConfigureApplicationContainer(container);
        }


    }
}