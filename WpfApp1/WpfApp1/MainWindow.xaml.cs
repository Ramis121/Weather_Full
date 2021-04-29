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
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GetWeatherService _weatherServies;
        ObservableCollection<string> str;
        public Main main { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            str = new ObservableCollection<string>(); 
            _weatherServies = new GetWeatherService();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
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

        private void FileStream(string path)
        {
            using (var sw = new StreamWriter(path, true))
            {
                sw.WriteLine(txt.Text);   
            }

            using (var sr = new StreamReader(path, true))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    aaa.Text = sr.ReadToEnd();
                }
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Weather_Click();
        }

        private bool Weather_Click()
        {
            if (txt.Text != null)
                return true;
            else
                return false;
        }

        private void Button_Click_Infa(object sender, RoutedEventArgs e)
        {
            FileStream("Fail.txt"); 
            try
            {
                if (txt.Text != null)
                {
                    string first = txt.Text;
                    str.Add(first);
                }
                else
                    throw new Exception("В истории нет Городов");
            }
            catch (Exception ex)
            {
                txt.Text = ex.Message;
            }
        }

        private void Button_Click_Weather(object sender, RoutedEventArgs e)
        {
            Weather weather = new Weather();
            weather.Show();
            Close();
        }
    }
}
