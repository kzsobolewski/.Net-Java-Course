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
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            using (var weatherDataDB = new WeatherDataDB())
            {
                /*
                // Create and save a new Blog
                Console.Write("Enter a name for a new Blog: ");
                var city = Console.ReadLine();

                var data = new WeatherData("poznan", DateTime.Now, 31);

                weatherDataDB.WeatherDatas.Add(data);
                weatherDataDB.SaveChanges();

                // Display all Blogs from the database
                var query = from b in weatherDataDB.WeatherDatas
                            orderby b.City
                            select b;

                Console.WriteLine("All blogs in the database:");
                foreach (var item in query)
                {
                    Console.WriteLine(item.City);
                }

                Console.WriteLine("Press any key to exit...");
                Console.Read();
                */
            }

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
                MessageBox.Show("Invalid Temperature.Try again",
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
                var weatherdata = new WeatherData(new_City, new_Date, new_Temp);
                items.Add(weatherdata);
            }
        }

        private void DataTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TemperaturaTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Download_weather_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
