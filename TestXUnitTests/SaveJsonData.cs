using System;
using System.Linq;
using Xunit;
using System.Collections.ObjectModel;
using Test.Model;
using System.IO;
using Newtonsoft.Json;

namespace TestXUnitTests
{
    public class SaveJsonData
    {
        /*
         * Тестирует метод:
         * 
           public void SaveClientsData(ObservableCollection<Client> clients, string path)
           {
                using (StreamWriter writer = File.CreateText(path))
                {
                    string output = JsonConvert.SerializeObject(clients);
                    writer.Write(output);
                }
            }
         */

        [Fact]
        public void ShouldSaveClientsDataFromCollectionToJson()
        {
            // Ожидаемый результат
            ObservableCollection<Client> expected = new ObservableCollection<Client>()
            {
                new Client { Id = "AAA001", Name = "Name01", City = "Саратов", Address = "Adress01", PhoneNumber = "PhoneNumber01", MeasureDate = "10.11.2021", MeasureTime = null },
                new Client { Id = "AAA002", Name = "Name02", City = "Саратов", Address = "Adress02", PhoneNumber = "PhoneNumber02", MeasureDate = "11.11.2021", MeasureTime = null },
                new Client { Id = "AAA003", Name = "Name03", City = "Москва", Address = "Adress03", PhoneNumber = "PhoneNumber03", MeasureDate = "10.11.2021", MeasureTime = "10:00-12:00" },
                new Client { Id = "AAA004", Name = "Name04", City = "Саратов", Address = "Adress04", PhoneNumber = "PhoneNumber04", MeasureDate = "12.11.2021", MeasureTime = null },
                new Client { Id = "AAA005", Name = "Name05", City = "Москва", Address = "Adress05", PhoneNumber = "PhoneNumber05", MeasureDate = "10.11.2021", MeasureTime = "14:00-16:00" },
                new Client { Id = "AAA006", Name = "Name06", City = "Саратов", Address = "Adress06", PhoneNumber = "PhoneNumber06", MeasureDate = "11.11.2021", MeasureTime = null },
                new Client { Id = "AAA007", Name = "Name07", City = "Саратов", Address = "Adress07", PhoneNumber = "PhoneNumber07", MeasureDate = "10.11.2021", MeasureTime = null },
                new Client { Id = "AAA008", Name = "Name08", City = "Москва", Address = "Adress08", PhoneNumber = "PhoneNumber08", MeasureDate = "10.11.2021", MeasureTime = "16:00-18:00" },
                new Client { Id = "AAA009", Name = "Name09", City = "Москва", Address = "Adress09", PhoneNumber = "PhoneNumber09", MeasureDate = "11.11.2021", MeasureTime = "10:00-12:00" },
                new Client { Id = "AAA010", Name = "Name10", City = "Саратов", Address = "Adress10", PhoneNumber = "PhoneNumber10", MeasureDate = "13.11.2021", MeasureTime = null }
            };

            // Входящие данные
            ObservableCollection<Client> clients = new ObservableCollection<Client>()
            {
                new Client { Id = "AAA001", Name = "Name01", City = "Саратов", Address = "Adress01", PhoneNumber = "PhoneNumber01", MeasureDate = "10.11.2021", MeasureTime = null },
                new Client { Id = "AAA002", Name = "Name02", City = "Саратов", Address = "Adress02", PhoneNumber = "PhoneNumber02", MeasureDate = "11.11.2021", MeasureTime = null },
                new Client { Id = "AAA003", Name = "Name03", City = "Москва", Address = "Adress03", PhoneNumber = "PhoneNumber03", MeasureDate = "10.11.2021", MeasureTime = "10:00-12:00" },
                new Client { Id = "AAA004", Name = "Name04", City = "Саратов", Address = "Adress04", PhoneNumber = "PhoneNumber04", MeasureDate = "12.11.2021", MeasureTime = null },
                new Client { Id = "AAA005", Name = "Name05", City = "Москва", Address = "Adress05", PhoneNumber = "PhoneNumber05", MeasureDate = "10.11.2021", MeasureTime = "14:00-16:00" },
                new Client { Id = "AAA006", Name = "Name06", City = "Саратов", Address = "Adress06", PhoneNumber = "PhoneNumber06", MeasureDate = "11.11.2021", MeasureTime = null },
                new Client { Id = "AAA007", Name = "Name07", City = "Саратов", Address = "Adress07", PhoneNumber = "PhoneNumber07", MeasureDate = "10.11.2021", MeasureTime = null },
                new Client { Id = "AAA008", Name = "Name08", City = "Москва", Address = "Adress08", PhoneNumber = "PhoneNumber08", MeasureDate = "10.11.2021", MeasureTime = "16:00-18:00" },
                new Client { Id = "AAA009", Name = "Name09", City = "Москва", Address = "Adress09", PhoneNumber = "PhoneNumber09", MeasureDate = "11.11.2021", MeasureTime = "10:00-12:00" },
                new Client { Id = "AAA010", Name = "Name10", City = "Саратов", Address = "Adress10", PhoneNumber = "PhoneNumber10", MeasureDate = "13.11.2021", MeasureTime = null }
            };
            Client client = new Client();
            string path = $"{Environment.CurrentDirectory}\\/ClientsSaveTest.json";

            // Результат
            client.SaveClientsData(clients, path);
            var actual1 = JsonConvert.DeserializeObject<ObservableCollection<Client>>(File.ReadAllText($"{Environment.CurrentDirectory}\\/ClientsSaveTest.json"));

            var result = actual1.SequenceEqual(expected);

            Assert.True(result);
        }

        /*
         * Тестирует метод:
         * 
           public void SaveMeasuresData(ObservableCollection<Date> dates, string path)
           {
                using (StreamWriter writer = File.CreateText(path))
                {
                    string output = JsonConvert.SerializeObject(dates);
                    writer.Write(output);
                }
           }
        */

        [Fact]
        public void ShouldSaveMeasureDateDataFromCollectionToJson()
        {
            // Ожидаемый результат
            ObservableCollection<Date> expected = new ObservableCollection<Date>()
            {
                new Date { ClientID = "AAA001", CityName = "Москва", MeasureDate = "10.11.2021", MeasureDayOfWeek = DayOfWeek.Wednesday, Interval = "08:00-10:00" },
                new Date { ClientID = "AAA002", CityName = "Саратов", MeasureDate = "10.11.2021", MeasureDayOfWeek = DayOfWeek.Wednesday, Interval = "" },
                new Date { ClientID = "AAA003", CityName = "Саратов", MeasureDate = "10.11.2021", MeasureDayOfWeek = DayOfWeek.Wednesday, Interval = "" },
                new Date { ClientID = "AAA004", CityName = "Москва", MeasureDate = "10.11.2021", MeasureDayOfWeek = DayOfWeek.Wednesday, Interval = "10:00-12:00" },
                new Date { ClientID = "AAA005", CityName = "Москва", MeasureDate = "10.11.2021", MeasureDayOfWeek = DayOfWeek.Wednesday, Interval = "08:00-10:00" },
                new Date { ClientID = "AAA006", CityName = "Саратов", MeasureDate = "10.11.2021", MeasureDayOfWeek = DayOfWeek.Wednesday, Interval = "" },
                new Date { ClientID = "AAA007", CityName = "Москва", MeasureDate = "10.11.2021", MeasureDayOfWeek = DayOfWeek.Wednesday, Interval = "14:00-16:00" },
                new Date { ClientID = "AAA008", CityName = "Саратов", MeasureDate = "10.11.2021", MeasureDayOfWeek = DayOfWeek.Wednesday, Interval = "" },
                new Date { ClientID = "AAA009", CityName = "Москва", MeasureDate = "10.11.2021", MeasureDayOfWeek = DayOfWeek.Wednesday, Interval = "08:00-10:00" },
                new Date { ClientID = "AAA010", CityName = "Саратов", MeasureDate = "10.11.2021", MeasureDayOfWeek = DayOfWeek.Wednesday, Interval = "" },
            };

            // Входящие данные
            ObservableCollection<Date> measureDates = new ObservableCollection<Date>()
            {
                new Date { ClientID = "AAA001", CityName = "Москва", MeasureDate = "10.11.2021", MeasureDayOfWeek = DayOfWeek.Wednesday, Interval = "08:00-10:00" },
                new Date { ClientID = "AAA002", CityName = "Саратов", MeasureDate = "10.11.2021", MeasureDayOfWeek = DayOfWeek.Wednesday, Interval = "" },
                new Date { ClientID = "AAA003", CityName = "Саратов", MeasureDate = "10.11.2021", MeasureDayOfWeek = DayOfWeek.Wednesday, Interval = "" },
                new Date { ClientID = "AAA004", CityName = "Москва", MeasureDate = "10.11.2021", MeasureDayOfWeek = DayOfWeek.Wednesday, Interval = "10:00-12:00" },
                new Date { ClientID = "AAA005", CityName = "Москва", MeasureDate = "10.11.2021", MeasureDayOfWeek = DayOfWeek.Wednesday, Interval = "08:00-10:00" },
                new Date { ClientID = "AAA006", CityName = "Саратов", MeasureDate = "10.11.2021", MeasureDayOfWeek = DayOfWeek.Wednesday, Interval = "" },
                new Date { ClientID = "AAA007", CityName = "Москва", MeasureDate = "10.11.2021", MeasureDayOfWeek = DayOfWeek.Wednesday, Interval = "14:00-16:00" },
                new Date { ClientID = "AAA008", CityName = "Саратов", MeasureDate = "10.11.2021", MeasureDayOfWeek = DayOfWeek.Wednesday, Interval = "" },
                new Date { ClientID = "AAA009", CityName = "Москва", MeasureDate = "10.11.2021", MeasureDayOfWeek = DayOfWeek.Wednesday, Interval = "08:00-10:00" },
                new Date { ClientID = "AAA010", CityName = "Саратов", MeasureDate = "10.11.2021", MeasureDayOfWeek = DayOfWeek.Wednesday, Interval = "" },
            };
            Date date = new Date();
            string path = $"{Environment.CurrentDirectory}\\/MeasureDatesSaveTest.json";

            // Результат
            date.SaveMeasuresData(measureDates, path);
            var actual = JsonConvert.DeserializeObject<ObservableCollection<Date>>(File.ReadAllText($"{Environment.CurrentDirectory}\\/MeasureDatesSaveTest.json"));

            var result = actual.SequenceEqual(expected);

            Assert.True(result);
        }
    }
}
