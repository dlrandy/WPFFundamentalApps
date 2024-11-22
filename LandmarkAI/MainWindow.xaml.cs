using LandmarkAI.classes;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Windows;
using System.Windows.Media.Imaging;

namespace LandmarkAI
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs args)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files (*.png;*.jpg)|*.png;*.jpg;*.jpeg|All files (*.*)|*.*";
            dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            var fileIsSelected = dialog.ShowDialog();
            if (fileIsSelected == true)
            {
                var fileName = dialog.FileName;
                SelectedImage.Source = new BitmapImage(new Uri(fileName));
                MakePredictionAsync(fileName);
            }
        }

        private async void MakePredictionAsync(string fileName)
        {
            string url =
                "https://southcentralus.api.cognitive.microsoft.com/customvision/v3.0/Prediction/2c2fdd71-d9c7-40b5-8ba5-6aec9e2d1b6f/classify/iterations/Iteration1/image";

            string predictionKey = "13e6b3e48ea7454b8c79922f0ab8b647";
            string contentType = "application/octet-stream";
            var file = File.ReadAllBytes(fileName);
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Prediction-Key", predictionKey);
                using (var content = new ByteArrayContent(file))
                {
                    content.Headers.ContentType = new MediaTypeHeaderValue(contentType);
                    var response = await client.PostAsync(url, content);
                    var json = await response.Content.ReadAsStringAsync();
                    List<Prediction> predictions = (List<Prediction>)JsonConvert.DeserializeObject<CustomVision>(json).Predictions;
                    PredictionListView.ItemsSource = predictions;
                }
            }
        }
    }
}