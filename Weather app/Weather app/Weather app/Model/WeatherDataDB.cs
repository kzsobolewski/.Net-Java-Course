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
        //public WeatherDataDB(): base("DefaultConnection")
        //{
        //    Database.Initialize(true);
        //}

        public DbSet<WeatherData> WeatherDatas { get; set; }
    }
}
