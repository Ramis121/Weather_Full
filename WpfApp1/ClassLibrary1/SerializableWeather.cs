using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using Service;

namespace ClassLibrary1
{
    [Serializable]
    public class SerializableWeather
    {
        public Main main { get; set; }

        public SerializableWeather()
        {
            main.temp = 12;
            main.temp_max.ToString();
            main.temp_min.ToString();
            main.pressure.ToString();
            main.humidity.ToString();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Main));

            using(FileStream path = new FileStream("pach.xml", FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(path, main);
            }

            using (FileStream path = new FileStream("pach.xml", FileMode.OpenOrCreate))
            {
                Main mains = (Main)xmlSerializer.Deserialize(path); 
            }
        }
    }
}
