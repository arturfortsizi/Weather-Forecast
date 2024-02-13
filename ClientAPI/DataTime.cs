using System.Timers;
using System.Windows;
using System.Windows.Controls;

namespace Weather_Forecast.ClientAPI
{
    class DataTime
    {
        //Создание переменных
        private System.Timers.Timer timer;
        private System.Windows.Controls.Label timeLabel;

        //Создание и запуск таймера в конструкторе
        public DataTime(System.Windows.Controls.Label label)
        {
            timeLabel = label;
            timer = new System.Timers.Timer(500);
            timer.Elapsed += DataShow;
            timer.Start();
        }

        //Вывод времени в приложении 
        private void DataShow(object sender, ElapsedEventArgs e)
        {
            timeLabel.Dispatcher.Invoke(() => timeLabel.Content = DateTime.Now.ToString("HH:m:s"));
        }
    }
}
