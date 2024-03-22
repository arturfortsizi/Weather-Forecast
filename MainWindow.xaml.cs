using Newtonsoft.Json.Linq;
using System.ComponentModel;
using System.IO;
using System.Windows;
using Weather_Forecast.ClientAPI;

namespace Weather_Forecast
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DataTime timers;
        private bool theme = true;
        private JSON_Save saveTopic = new();
        private FileInfo file = new("data.json");
        //System.Windows.Media.Color color = System.Windows.Media.Color.FromRgb(1,1,1);
        //BackGround.Background = new SolidColorBrush(color);

        public MainWindow()
        {
            InitializeComponent();
            timers = new DataTime(TimeLabel, Time_Img);
            Closing += CloseProgram;
            if (!file.Exists)
                saveTopic.JSONSave(theme);
            else
                theme = saveTopic.JSONLoad();

            if (theme)
                Light_theme();
            else
                Dark_theme();
        }

        private void CloseProgram(object? sender, CancelEventArgs e)
        {
            timers.TimerStop();
        }

        //Отслеживание нажатия на кнопку 
        //Сделать проверку TextBox на налчие символов(города)
        //Работа с json и вывод результата
        /*
        * json["main"]["temp"].ToString(); - Температура
        * json["main"]["temp_min"].ToString(); - Мин темп
        * json["main"]["temp_max"].ToString(); - Макс темп
        * json["wind"]["speed"]; - Скорость Ветра
        * json["wind"]["gust"]; - Порыв  
        * json["wind"]["deg"]; - Угол ветра
        * json["main"]["humidity"]; - Влажность
        * json["main"]["pressure"]; - Давление на уровне моря
        * json["main"]["grnd_level"]; - Давление на уровне Земли
        */
        public async void GetWeatherBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CountryTextBox.Text.Length < 3)
            {
                TemperatureLabel.Content = "Введите существующий город";
                return;
            }

            Weather_API weather = new();
            string data = await weather.GetWeather(CountryTextBox.Text);
            Error_Label.Visibility = Visibility.Hidden;

            if (data != null)
            {
                var json = JObject.Parse(data);

                TemperatureLabel.Content = $"Температура: {json["main"]["temp"].ToString()} °C";
                TempMin_Label.Content = $"Мин: {json["main"]["temp_min"]} °C";
                TempMax_Label.Content = $"Макс: {json["main"]["temp_max"]} °C";

                WindSpeedLabel.Content = $"Скорость ветра: {json["wind"]["speed"]} м/с";
                WindGust_Label.Content = $"Порыв: {json["wind"]["gust"]} м/с";
                WindDeg_Label.Content = $"Угол: {json["wind"]["deg"]}";

                HumidityLabel.Content = $"Влажность: {json["main"]["humidity"]}%";
                GrndLevel_Label.Content = $"Давление(земля): {json["main"]["grnd_level"]} мм";
                Pressure_Label.Content = $"Давление(море): {json["main"]["pressure"]} мм";
            }
            else
                Error_Label.Visibility = Visibility.Visible;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            theme = !theme;
            saveTopic.JSONSave(theme);

            if (theme)
                Light_theme();
            else
                Dark_theme();
        }

        //Рассписать светлую тему
        private void Light_theme()
        {
            //TemperatureLabel.Foreground = ;
            MessageBox.Show("Light_theme");
        }

        //Рассписать тёмную тему
        private void Dark_theme()
        {
            MessageBox.Show("Dark_theme");
        }
    }
}
