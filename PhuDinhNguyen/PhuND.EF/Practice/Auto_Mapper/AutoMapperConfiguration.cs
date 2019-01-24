using AutoMapper;
using Practice.View_Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Transportation.Framework.Models;

namespace Practice.Auto_Mapper
{
    public class AutoMapperConfiguration
    {
        private static IMapper mapper;
        private static MapperConfiguration config;


        public static IMapper GetInstance()
        {
            if (config == null && mapper == null)
            {
                config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Vehicle, VehicleResponseViewModel>();

                    cfg.CreateMap<Owner, OwnerResponseViewModel>();
                    //cfg.CreateMap<VehicleRequestViewModel, Vehicle>();
                });

                mapper = config.CreateMapper();
            }
            return mapper;
        }

    }
}