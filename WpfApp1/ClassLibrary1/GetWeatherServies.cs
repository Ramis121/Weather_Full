using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class GetWeatherService 
    {
        private string apiConnectionStrin = "https://api.openweathermap.org/data/2.5/weather";
        private string apiKey = "9771d62513cca77c98e236c4f4b52bcb";

        public Root DataContext { get; private set; }

        public Root GetWeather(string city)
        {
            var client = new RestClient(apiConnectionStrin);
            var reuqest = new RestRequest(Method.GET);

            reuqest.AddParameter("q", city);
            reuqest.AddParameter("apiKey", apiKey);

            var root = client.Execute<Root>(reuqest);
            if (root.IsSuccessful)
            {
                return root.Data;
            }
            return null;
        }
    }
}
