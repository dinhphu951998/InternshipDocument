﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Practice.View_Models
{
    public class VehicleResponseViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Wheel { get; set; }
        public int OwnerId { get; set; }
    }
}