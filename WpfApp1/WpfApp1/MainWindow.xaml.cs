using Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GetWeatherService _weatherServies;
        ObservableCollection<string> str; 
        public MainWindow()
        {
            InitializeComponent();
            str = new ObservableCollection<string>();
            listb.ItemsSource = str;
            _weatherServies = new GetWeatherService();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Task.Delay(10); 
                var weather = _weatherServies.GetWeather(txt.Text);
                if (weather != null)
                {
                    this.DataContext = weather;
                }
                else { throw new Exception("Error"); }
            }
            catch (Exception rx)
            {
                textbox3.Text = rx.Message;
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e){ }

        private void Button_Click_Infa(object sender, RoutedEventArgs e)
        {
            string first = txt.Text;
            str.Add(first);
        }

        private void Button_Click_Weather(object sender, RoutedEventArgs e)
        {
            Weather weather = new Weather();
            weather.Show();
            Close();
        }
    }
}
