using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.Entity;
using System.Collections.ObjectModel;
using Weather_app.Model;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Weather_app
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        ObservableCollection<WeatherData> items = new ObservableCollection<WeatherData> { };
        public ObservableCollection<WeatherData> Items
        {
            get => items;
        }

        DBconnection dBconnection = new DBconnection();
        public MainWindow()
        {
            InitializeComponent();
            DownloadDataAsyncInfiniteLoop();
            DataContext = this;


        }


        private void Add_forecast_Click(object sender, RoutedEventArgs e)
        {
            string new_City = CitisComboBox.Text;
            float new_Temp = 0;
            DateTime new_Date = new DateTime(00 - 00 - 0000);

            Regex regex = new Regex(@"(((0|1)[0-9]|2[0-9]|3[0-1])-(0[1-9]|1[0-2])-((19|20)\d\d))$");
            bool result_date = regex.IsMatch(DataTextBox.Text.Trim());
            if (result_date == false || DataTextBox.Text.Length == 0)
            {
                MessageBox.Show("Invalid Date. Expecting \"Day-Month-Year\" format. ",
                "Info",
                MessageBoxButton.OK,
                MessageBoxImage.Information);
            }
            else
            {
                new_Date = Convert.ToDateTime(DataTextBox.Text);
            }
            float parsedValue;
            bool result_temperature = float.TryParse(TemperaturaTextBox.Text, out parsedValue);
            if (result_temperature == false || TemperaturaTextBox.Text.Length == 0)
            {
                MessageBox.Show("Invalid Temperature. Try again",
                "Info",
                MessageBoxButton.OK,
                MessageBoxImage.Information);
            }
            else
            {
                new_Temp = parsedValue;

            }
            if((result_date && result_temperature)==true)
            {
                var weatherdata = new WeatherData(new_City, new_Date, new_Temp,123,4,7);
                dBconnection.add_to_DB(weatherdata);
                synchronize(dBconnection);
            }
        }

        private void DataTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TemperaturaTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }


        //////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////


        private int loopTimeSeconds = 5; 

        // Downloading and returning weather data in json
        private async Task<string> GetJsonAsync(string uri)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using (HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                return await reader.ReadToEndAsync();
            }
        }

        // Parsing the json with weather
        private async void DownloadWeatherData(){
            var city = CitisComboBox.Text;
            float temperature, longitude, latitude, pressure, humidity, windSpeed, clouds;
            string weatherType, description;
            var urlAPI = "https://openweathermap.org/data/2.5/weather?q=" + city + "&appid=b6907d289e10d714a6e88b30761fae22";
            try
            {
                JObject resultJson = JObject.Parse(await GetJsonAsync(urlAPI));
                temperature = (float)resultJson["main"]["temp"];
                //more unused info: 
                longitude = (float)resultJson["coord"]["lon"];
                latitude = (float)resultJson["coord"]["lat"];
                pressure = (float)resultJson["main"]["pressure"];
                humidity = (float)resultJson["main"]["humidity"];
                windSpeed = (float)resultJson["wind"]["speed"];
                clouds = (float)resultJson["clouds"]["all"];

                log_textbox.Text += "Loaded properly.\n";

                var weatherdata = new WeatherData(city, DateTime.Now, temperature, humidity,pressure,windSpeed);
                dBconnection.add_to_DB(weatherdata);
                synchronize(dBconnection);
            }
            catch (Exception err)
            {
                log_textbox.Text += "Error: Json not loaded properly: " + err;
                return;
            }
        }

        // Download button click
        private async void Download_weather_Click(object sender, RoutedEventArgs e)
        {
            DownloadWeatherData();
        }

        // Infinite loop for downloading data
        private async Task DownloadDataAsyncInfiniteLoop()
        {
            while (true)
            {
                DownloadWeatherData();
                await Task.Delay(TimeSpan.FromSeconds(5));
            }
        }

        private void synchronize(DBconnection dBconnection)
        {
            Items.Clear();
            foreach (var WeatherData in dBconnection.get().WeatherDatas)
            {             
                items.Add(WeatherData);
            }

        }
    }

}
