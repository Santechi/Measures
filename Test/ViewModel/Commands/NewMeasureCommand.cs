using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows;
using Test.Model;
using Test.ViewModel.Commands;

using Test.ViewModel;
using System.ComponentModel;

namespace Test.ViewModel.Commands
{
    public class NewMeasureCommand : BaseCommand
    {
        public NewMeasureCommand(ViewModel viewModel, Client client, Date date) : base(viewModel, client, date)
        {

        }

        public override bool CanExecute(object parameter)
        {
            /* Команду нельзя активировать, предварительно не выбрав пользователя (хотя при старте программы выделяется последний клиент списка),
             * или когда замер уже назначен, т.е. для смены даты необходимо сначала удалить замер, а затем переназначить его на другую дату, выбрав ее в календаре.
             * Также нельзя назначить замер в прошлое. К сожалению, машину времени еще не изобрели :(((
             */

            if (_viewModel.SelectedClient == null || _viewModel.SelectedClient.MeasureDate != string.Empty ||
                (_viewModel.CalendarDate < DateTime.Today))
                return false;
            else
                return true;
        }

        public override void Execute(object parameter)
        {

            /* Диспетчер выбирает дату замера в календаре, выбирает клиента в DataGrid, и нажимает на "Назначить замер", в результате чего срабатывает данный метод, который предварительно записывает замер
             * в файл MeasureDates.json, после чего происходит подсчет количества выбранной диспетчером даты на город, в котором производится замер. У каждого города есть коллекция недели, в которой
             * прописано определенное кол-во замеров на день недели. Если подсчитанное кол-во выбранной даты на город больше, чем это позволяет город, то диспетчеру вылетает ошибка в виде messagebox'a.
             * В противном случае происходит сохранение замера в MeasureDates.json, а также присвоение даты замера в DataGrid (и в файл Clients.json в поле MeasureDate).
            */

            // клиенту присваивается дата замера, выбранная в календаре

            if (_viewModel.SelectedClient.City == "Москва")
            {
                _viewModel.SelectedClient.MeasureDate = _viewModel.CalendarDate.ToShortDateString();
                _viewModel.SelectedClient.MeasureTime = _viewModel.SelectedInterval.IntervalValue;
            }
            else
                _viewModel.SelectedClient.MeasureDate = _viewModel.CalendarDate.ToShortDateString();

            var newMeasure = new Date()
            {
                ClientID = _viewModel.SelectedClient.Id,
                CityName = _viewModel.SelectedClient.City,
                MeasureDate = _viewModel.CalendarDate.ToShortDateString(),
                MeasureDayOfWeek = _viewModel.CalendarDate.DayOfWeek,
                Interval = _viewModel.SelectedInterval.IntervalValue
            };

            _date.AddNewMeasureToCollection(_viewModel.MeasureDates, newMeasure); // Планируется новый замер                         

            if (_date.GetMeasureRemaining(default, default, _viewModel.MeasureDates, _viewModel.Cities, _viewModel.Intervals, _viewModel.SelectedClient.City, _viewModel.SelectedInterval, _viewModel.CalendarDate) >= 0)
            {
                if (_viewModel.SelectedClient.City == "Москва")
                    MessageBox.Show($"Slots left for {_viewModel.SelectedClient.City} on {_viewModel.CalendarDate.ToShortDateString()} - {_viewModel.SelectedInterval.IntervalValue} : {_date.GetMeasureRemaining(default, default, _viewModel.MeasureDates, _viewModel.Cities, _viewModel.Intervals, _viewModel.SelectedClient.City, _viewModel.SelectedInterval, _viewModel.CalendarDate)}", "Succeed!", MessageBoxButton.OK, MessageBoxImage.Information);
                else
                    MessageBox.Show($"Slots left for {_viewModel.SelectedClient.City} on {_viewModel.CalendarDate.ToShortDateString()}: {_date.GetMeasureRemaining(default, default, _viewModel.MeasureDates, _viewModel.Cities, _viewModel.Intervals, _viewModel.SelectedClient.City, _viewModel.SelectedInterval, _viewModel.CalendarDate)}", "Succeed!", MessageBoxButton.OK, MessageBoxImage.Information);

                _date.SaveMeasuresData(_viewModel.MeasureDates, _viewModel.datesPath);
                _client.SaveClientsData(_viewModel.Clients, _viewModel.clientsPath);
                _client.LoadClientsData(_viewModel.Clients, _viewModel.clientsPath);
                _viewModel.UpdateClientsData(_viewModel.Clients, _viewModel.clientsPath);
            }
            else
            {
                if (_viewModel.SelectedClient.City == "Москва")
                    MessageBox.Show($"No slots for {_viewModel.SelectedClient.City} on {_viewModel.CalendarDate.ToShortDateString()} - {_viewModel.SelectedInterval.IntervalValue} left", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                else
                    MessageBox.Show($"No slots for {_viewModel.SelectedClient.City} on {_viewModel.CalendarDate.ToShortDateString()} left", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);

                _viewModel.MeasureDates.Remove(newMeasure);
                _viewModel.SelectedClient.MeasureDate = string.Empty;
                _viewModel.SelectedClient.MeasureTime = string.Empty;
                return;
            }
        }
    }
}
