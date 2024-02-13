using System.Windows;
using Weather_Forecast.ClientAPI;

namespace Weather_Forecast
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataTime timers;
        
        public MainWindow()
        {
            InitializeComponent();
            timers = new DataTime(TimeLabel);
           
        }

        public void GetWeatherBtn_Click(object sender, RoutedEventArgs e)
        {
            Weather_API weather = new Weather_API(CountryTextBox.Text);
        }
    }
}