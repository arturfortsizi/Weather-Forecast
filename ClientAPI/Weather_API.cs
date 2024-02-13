﻿using System.Net.Http;
using System.Windows;
using Newtonsoft.Json.Linq;

namespace Weather_Forecast.ClientAPI
{
    class Weather_API : MainWindow
    {
        //Создание переменных
        private const string API_KEY = "a0d36a11bde668359c9fd3eaec26be68";
        private string city;

        //Создание конструктора и запись города в него
        public Weather_API(string city)
        {
            this.city = city;
            TreatmentData();
        }

        //Работа с сылками !(Отловить ошибки с городом)!
        public async Task<string> GetWeather()
        {
            HttpClient client = new HttpClient();
            string url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={API_KEY}&units=metric";
            return await client.GetStringAsync(url);
        } 

        //Работа с json и вывод результата
        private async void TreatmentData()
        {
            string data = await GetWeather();

            var json = JObject.Parse(data);
            string temperature = json["main"]["temp"].ToString();
            MessageBox.Show(temperature);
        }

    }
}