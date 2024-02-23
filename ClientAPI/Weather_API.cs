using System.Net.Http;

namespace Weather_Forecast.ClientAPI
{
    class Weather_API : MainWindow
    {
        //Ключь
        private const string API_KEY = "a0d36a11bde668359c9fd3eaec26be68";

        //Работа с сылками
        //Сделать отловить ошибки с городом
        public async Task<string> GetWeather(string city)
        {
            HttpClient client = new HttpClient();
            string url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={API_KEY}&units=metric";
            return await client.GetStringAsync(url);
        }
    }
}
