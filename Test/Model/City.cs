using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.ObjectModel;
using System.IO;
using Newtonsoft.Json;

namespace Test.Model
{
    public class City   // Используется как искомое значение количества замеров на день недели в определенном городе
    {
        public string СityName { get; set; }
        public ObservableCollection<Day> Week { get; set; }

        public ObservableCollection<City> LoadCitiesData(ObservableCollection<City> Cities, string path)
        {
            string citiesJSON = File.ReadAllText(path);
            Cities = JsonConvert.DeserializeObject<ObservableCollection<City>>(citiesJSON);

            return Cities;
        }

        public void SaveCitiesData(ObservableCollection<City> cities, string path)
        {
            using (StreamWriter writer = File.CreateText(path))
            {
                string output = JsonConvert.SerializeObject(cities);
                writer.Write(output);
            }
        }
        
        public override bool Equals(object obj)
        {
            if (null == obj || obj.GetType() != typeof(City))
                return false;

            var city = obj as City;
            return city.СityName == СityName;

        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        
    }

}

