using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Transportation.Framework.Models;

namespace Repository
{
    public class DVehicleRepository : IBaseRepository<Vehicle>
    {
        private IDbConnection db;

        public DVehicleRepository(IDbConnection db)
        {
            this.db = db;
        }

        public void Add(Vehicle entity)
        {
            string sql = "insert into Vehicle([Name],[Wheel],[OwnerId]) values(@Name, @Wheel, @OwnerId); " +
                        "select SCOPE_IDENTITY()";
            var Id = db.Query<int>(sql, entity).Single();
            entity.Id = Id;
        }

        public void Delete(Vehicle entity)
        {
            string sql = "delete from Vehicle where Id = @Id";
            db.Execute(sql, entity);
        }

        public Vehicle Find(int Id)
        {
            string sql = "select [Id],[Name],[Wheel],[OwnerId] from Vehicle where Id = @Id;" +
                         "SELECT  o.[Id],o.[Name],o.[Age] FROM [Owner] o join Vehicle v on o.Id = v.OwnerId where v.Id = @Id";

            using (var multipleQuery = this.db.QueryMultiple(sql, new { Id}))
            {
                var vehicle = multipleQuery.Read<Vehicle>().SingleOrDefault();
                var owner = multipleQuery.Read<Owner>().SingleOrDefault();
                if(vehicle != null && owner != null)
                {
                    vehicle.Owner = owner;
                }
                return vehicle;
            }
        }

        public IEnumerable<Vehicle> GetAll()
        {
            return db.Query<Vehicle>("select [Id],[Name],[Wheel],[OwnerId] from Vehicle");
        }

        public void Update(Vehicle entity)
        {
            string sql = "update Vehicle set Name = @Name, Wheel = @Wheel, OwnerId = @OwnerId where Id = @Id";
            db.Execute(sql, entity);
        }
    }
}