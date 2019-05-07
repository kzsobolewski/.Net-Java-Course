using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace Weather_app.Model
{
    public class WeatherDataDB : DbContext
    {
        public WeatherDataDB() : base("WeatherDataDB")
        {
            Database.SetInitializer<WeatherDataDB>(new CreateDatabaseIfNotExists<WeatherDataDB>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<WeatherData> WeatherDatas { get; set; }
    }
}
