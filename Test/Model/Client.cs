using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Model
{
    public class Client     // Используется как источник к DataGrid
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Address { get; set; }        
        public string PhoneNumber { get; set; }
        public string MeasureDate { get; set; }
        public string MeasureTime { get; set; }

        public ObservableCollection<Client> LoadClientsData(ObservableCollection<Client> Clients, string path)
        {
            string clientsJSON = File.ReadAllText(path);
            Clients = JsonConvert.DeserializeObject<ObservableCollection<Client>>(clientsJSON);

            return Clients;
        }
        
        public void SaveClientsData(ObservableCollection<Client> clients, string path)
        {
            using (StreamWriter writer = File.CreateText(path))
            {
                string output = JsonConvert.SerializeObject(clients);
                writer.Write(output);
            }
        }

        public override bool Equals(object obj)
        {
            if (null == obj || obj.GetType() != typeof(Client))
                return false;

            var client = obj as Client;
            return client.Id == Id && client.Name == Name && client.City == City && client.Address == Address && client.PhoneNumber == PhoneNumber && client.MeasureDate == MeasureDate && client.MeasureTime == MeasureTime;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
