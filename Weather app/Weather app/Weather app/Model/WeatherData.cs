using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Weather_app.Model
{
    public class WeatherData
    {
        [Key]
        private int Id { get; set; }
         
        public string City { get; set; }
        public DateTime Time { get; set; }
        public float Temperature { get; set; }


        public WeatherData(String city="unknown",DateTime time = new DateTime() , float temp = 0)
        {
            this.City = city;
            this.Time = time;
            this.Temperature = temp;
        }
    }
}
