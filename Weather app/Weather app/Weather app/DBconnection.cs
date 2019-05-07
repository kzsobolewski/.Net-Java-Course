using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather_app
{
    public class DBconnection
    {
        static private Model.WeatherDataDB Weather_Data_Base = new Model.WeatherDataDB();
        public DBconnection() { }


        public void add_to_DB(Model.WeatherData data)
        {
            var forecast = new Model.WeatherData() { City = data.City, Time = data.Time, Temperature = data.Temperature };

            Weather_Data_Base.WeatherDatas.Add(forecast);
            Weather_Data_Base.SaveChanges();
 
        }
    public Model.WeatherDataDB get()
        {
            return Weather_Data_Base;
        }

        



    }
}
