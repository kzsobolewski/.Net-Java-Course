using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Weather_app.Model
{
    [Table("WeatherDataTable")]
    public class WeatherData
    {
        [Key]
        public int Id { get; set; }

        public string City { get; set; }
        public DateTime Time { get; set; }
        public float Temperature { get; set; }
        public float? Humidity { get; set; } //nullable
        public float? Pressure { get; set; } //nullable
        public float? Windspeed { get; set; } //nullable

        public WeatherData() { }


        public WeatherData(String city, DateTime time, float temp, float humidity, float pressure, float windspeed)
        {
            City = city;
            Time = time;
            Temperature = temp;
            Humidity = humidity;
            Pressure = pressure;
            Windspeed = windspeed;
        }
    }
}
