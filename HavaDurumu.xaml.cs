using System;
using System.Collections.Generic;
using Microsoft.Maui.Controls;

namespace GorselProgramlamaOdev21010310066
{
    public partial class HavaDurumu : ContentPage
    {
        private List<WeatherInfo> weatherInfos = new List<WeatherInfo>();

        public HavaDurumu()
        {
            InitializeComponent();
        }

        private async void OnImageTapped(object sender, EventArgs e)
        {
           
            CityEntry.IsVisible = true;
            GetWeatherButton.IsVisible = true;
        }

        private async void OnGetWeatherButtonClicked(object sender, EventArgs e)
        {
            string city = CityEntry.Text;
            if (!string.IsNullOrWhiteSpace(city))
            {
                string normalizedCity = NormalizeCityName(city);
                string currentWeatherUrl = $"http://www.mgm.gov.tr/sunum/sondurum-show-2.aspx?m={normalizedCity}&rC=111&rZ=fff";
                string forecastWeatherUrl = $"http://www.mgm.gov.tr/sunum/tahmin-show-2.aspx?m={normalizedCity}&basla=1&bitir=5&rC=111&rZ=fff";

               
                WeatherInfo weatherInfo = new WeatherInfo(city, currentWeatherUrl, forecastWeatherUrl);
                weatherInfos.Add(weatherInfo);

                
                Label cityLabel = new Label
                {
                    Text = $"Þehir: {city}",
                    FontAttributes = FontAttributes.Bold,
                    HorizontalOptions = LayoutOptions.Center
                };
                WeatherStackLayout.Children.Add(cityLabel);

                Image currentWeatherImage = new Image
                {
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Center,
                    HeightRequest = 140,
                    WidthRequest = 140,
                    Source = ImageSource.FromUri(new Uri(currentWeatherUrl))
                };
                WeatherStackLayout.Children.Add(currentWeatherImage);

                Image forecastWeatherImage = new Image
                {
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Center,
                    HeightRequest = 140,
                    WidthRequest = 140,
                    Source = ImageSource.FromUri(new Uri(forecastWeatherUrl))
                };
                WeatherStackLayout.Children.Add(forecastWeatherImage);

                Image deleteImage = new Image
                {
                    Source = "del.png", 
                    HeightRequest = 24,
                    WidthRequest = 24,
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Center
                };

                
                TapGestureRecognizer deleteTapGestureRecognizer = new TapGestureRecognizer();
                deleteTapGestureRecognizer.Tapped += (s, ev) => OnDeleteButtonClicked(weatherInfo);
                deleteImage.GestureRecognizers.Add(deleteTapGestureRecognizer);

                WeatherStackLayout.Children.Add(deleteImage);
            }
            else
            {
                await DisplayAlert("Hata", "Lütfen bir þehir ismi girin.", "Tamam");
            }

            
            CityEntry.IsVisible = false;
            GetWeatherButton.IsVisible = false;
        }

        private void OnDeleteButtonClicked(WeatherInfo weatherInfo)
        {
           
            WeatherStackLayout.Children.RemoveAt(weatherInfos.IndexOf(weatherInfo) * 4); 
            WeatherStackLayout.Children.RemoveAt(weatherInfos.IndexOf(weatherInfo) * 4); 
            WeatherStackLayout.Children.RemoveAt(weatherInfos.IndexOf(weatherInfo) * 4); 
            WeatherStackLayout.Children.RemoveAt(weatherInfos.IndexOf(weatherInfo) * 4); 
            weatherInfos.Remove(weatherInfo);
        }

        private string NormalizeCityName(string cityName)
        {
            cityName = cityName.ToUpper();
            cityName = cityName.Replace('Ç', 'C')
                               .Replace('Ö', 'O')
                               .Replace('Þ', 'S')
                               .Replace('Ý', 'I')
                               .Replace('Ü', 'U')
                               .Replace('Ð', 'G');
            return cityName;
        }

        private class WeatherInfo
        {
            public string City { get; }
            public string CurrentWeatherUrl { get; }
            public string ForecastWeatherUrl { get; }

            public WeatherInfo(string city, string currentWeatherUrl, string forecastWeatherUrl)
            {
                City = city;
                CurrentWeatherUrl = currentWeatherUrl;
                ForecastWeatherUrl = forecastWeatherUrl;
            }
        }
    }
}
