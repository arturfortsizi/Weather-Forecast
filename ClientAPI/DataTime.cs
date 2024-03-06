using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Weather_Forecast.ClientAPI
{
    class DataTime
    {
        //Создание переменных
        private System.Timers.Timer timer;
        private System.Windows.Controls.Label timeLabel;
        private Image image;
        readonly TranslateTransform translateTransform = new TranslateTransform();
        

        //Создание и запуск таймера в конструкторе
        public DataTime(System.Windows.Controls.Label label, Image image)
        {
            timeLabel = label;
            timer = new System.Timers.Timer(500);
            timer.Elapsed += DataShow;
            timer.Start();

            this.image = image;
            ImageChange();
        }

        private void ImageChange()
        {
            if (DateTime.Now.Hour > 6 && DateTime.Now.Hour < 12)
            {
                image.Source = new BitmapImage(new Uri("C:/Users/Artur/Desktop/С#/C#/Weather Forecast/Images/Sunrise.png", UriKind.RelativeOrAbsolute));
            }
            else if (DateTime.Now.Hour > 11 && DateTime.Now.Hour < 17)
            {
                image.Source = new BitmapImage(new Uri("C:/Users/Artur/Desktop/С#/C#/Weather Forecast/Images/Sun.png", UriKind.RelativeOrAbsolute));
                image.Margin = new Thickness(0,10,0,0); //(0,10,0,0)
            }
            else if(DateTime.Now.Hour > 16 && DateTime.Now.Hour < 21)
            {
                image.Source = new BitmapImage(new Uri("C:/Users/Artur/Desktop/С#/C#/Weather Forecast/Images/Sunset.png", UriKind.RelativeOrAbsolute));
            }
            else
            {
                image.Source = new BitmapImage(new Uri("C:/Users/Artur/Desktop/С#/C#/Weather Forecast/Images/SunMoon.png", UriKind.RelativeOrAbsolute));
            }
        }

        //Вывод времени в приложении 
        private void DataShow(object sender, ElapsedEventArgs e)
        {
            timeLabel.Dispatcher.Invoke(() => timeLabel.Content = DateTime.Now.ToString("HH:m:s"));
        }

        public void TimerStop() => timer.Stop();
    }
}
