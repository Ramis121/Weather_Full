using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Weather.xaml
    /// </summary>
    public partial class Weather : Window
    {
        private GetWeatherService _weatherServies;
        public Weather()
        {
            InitializeComponent();
            _weatherServies = new GetWeatherService();
        }

        private void Button_ClickWeather(object sender, RoutedEventArgs e)
        {
            var weather = _weatherServies.GetWeather(textBox.Text);
            if(weather != null)
            {
                this.DataContext = weather;
            }
                
        }
    }
}
