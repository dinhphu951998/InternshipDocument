using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Transportation.Framework.Models;

namespace Repository.Repository
{
    public class EVehicleRepository : BaseRepository<Vehicle>
    {
        public EVehicleRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public override Vehicle Find(int Id)
        {
            return this.Get(v => v.Id == Id).FirstOrDefault();
        }

    }
}