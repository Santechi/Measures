using System;
using System.Linq;
using Xunit;
using System.Collections.ObjectModel;
using Test.Model;
using System.IO;
using Newtonsoft.Json;

namespace TestXUnitTests
{
    public class LoadJsonTest
    {
        /*
        * Тестирует метод:
        * 
            public ObservableCollection<Client> LoadClientsData(ObservableCollection<Client> Clients, string path)
            {
                string clientsJSON = File.ReadAllText(path);
                Clients = JsonConvert.DeserializeObject<ObservableCollection<Client>>(clientsJSON);

                return Temp.TempLoadData(Clients);
            }
        */

        [Fact]
        public void ShouldLoadClientsDataIntoCollectionFromJson()
        {
            // Ожидаемый результат
            var expected = JsonConvert.DeserializeObject<ObservableCollection<Client>>(File.ReadAllText($"{Environment.CurrentDirectory}\\/ClientsLoadTest.json"));

            // Входящие данные
            ObservableCollection<Client> clients = new ObservableCollection<Client>();
            Client client = new Client();
            string path = $"{Environment.CurrentDirectory}\\/ClientsLoadTest.json";

            // Результат
            var actual = client.LoadClientsData(clients, path);
            var result = actual.SequenceEqual(expected);

            Assert.True(result);
        }

        /*
        * Тестирует метод:
        * 
            public ObservableCollection<Date> LoadMeasureDatesData(ObservableCollection<Date> MeasureDates, string path)
            {
                string measureDatesJSON = File.ReadAllText(path);
                MeasureDates = JsonConvert.DeserializeObject<ObservableCollection<Date>>(measureDatesJSON);

                return Temp.TempLoadData(MeasureDates);
            }
        */

        [Fact]
        public void ShouldLoadMeasureDatesDataIntoCollectionFromJson()
        {
            // Ожидаемый результат
            var expected = JsonConvert.DeserializeObject<ObservableCollection<Date>>(File.ReadAllText($"{Environment.CurrentDirectory}\\/MeasureDatesLoadTest.json"));

            // Входящие данные
            ObservableCollection<Date> measureDates = new ObservableCollection<Date>();
            Date measureDate = new Date();
            string path = $"{Environment.CurrentDirectory}\\/MeasureDatesLoadTest.json";

            // Результат
            var actual = measureDate.LoadMeasureDatesData(measureDates, path);

            var result = actual.SequenceEqual(expected);

            Assert.True(result);
        }
    }
}
