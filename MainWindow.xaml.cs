using System.Drawing;
using System.Windows;
using System.Windows.Media;
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

        //System.Windows.Media.Color color = System.Windows.Media.Color.FromRgb(1,1,1);

        //Отслеживание нажатия на кнопку !(Проверять TextBox на налчие символов)!
        public void GetWeatherBtn_Click(object sender, RoutedEventArgs e)
        {
            //BackGround.Background = new SolidColorBrush(color);
            Weather_API weather = new Weather_API(CountryTextBox.Text);
        }
    }
}