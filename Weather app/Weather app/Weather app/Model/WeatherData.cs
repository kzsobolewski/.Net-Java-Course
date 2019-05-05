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
        public int Id { get; set; }

        public string City { get; set; }
        public DateTime Time { get; set; }
        public float Temperature { get; set; }

        public WeatherData(){}


        public WeatherData(String city,DateTime time, float temp)
        {
            City = city;
            Time = time;
            Temperature = temp;
        }
    }
}
