using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
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
using Newtonsoft.Json.Linq;
using System.Net;

namespace Lab02_parser
{
    public partial class MainWindow : Window
    {
        static HttpClient client = new HttpClient();

        ObservableCollection<Element> items = new ObservableCollection<Element> { };

        public ObservableCollection<Element> Items
        {
            get => items;
        }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

 
        private async void DownloadJsonButton_Click(object sender, RoutedEventArgs e)
        {
            loading_spinner.Visibility = Visibility.Visible;
            status_TextBlock.Text = "Loading...";

            var url = "http://api.icndb.com/jokes/random";
            var urlImg = "https://some-random-api.ml/dogimg";

            HttpResponseMessage res = await client.GetAsync(url);
            res.EnsureSuccessStatusCode();
            string responseBody = await res.Content.ReadAsStringAsync();
            JObject json = JObject.Parse(responseBody);

            HttpResponseMessage resImg = await client.GetAsync(urlImg);
            resImg.EnsureSuccessStatusCode();
            string responseBodyImg = await resImg.Content.ReadAsStringAsync();
            JObject jsonImg = JObject.Parse(responseBodyImg);

            string parsed_joke = (string)json["value"]["joke"];
            int parsed_number = (int)json["value"]["id"];
            string parsed_image_url = (string)jsonImg["link"];


            items.Add(new Element { Text = parsed_joke, Number = parsed_number, ImageUrl = parsed_image_url });

            loading_spinner.Visibility = Visibility.Hidden;
            status_TextBlock.Text = "Done.";
            
        }
    }
}