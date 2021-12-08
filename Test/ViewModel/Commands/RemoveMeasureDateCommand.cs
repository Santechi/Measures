using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

using Test.Model;

namespace Test.ViewModel.Commands
{
    public class RemoveMeasureDateCommand : BaseCommand
    {
        public RemoveMeasureDateCommand(ViewModel viewModel, Client client, Date date) : base(viewModel, client, date)
        {

        }

        public override bool CanExecute(object parameter)
        {
            /* Команду нельзя использовать, если не выделен клиент в DataGrid, 
             * а также нельзя удалить несуществующий замер
             */

            if (_viewModel.SelectedClient == null || _viewModel.SelectedClient.MeasureDate == string.Empty)
                return false;
            else
                return true;
        }

        public override void Execute(object parameter)
        {
            /* При нажатии на кнопку "Удалить замер" у выбранного клиента в DataGrid дата замера заменятеся на пустоту,
             * а также клиент удаляется из файла MeasureDates.json посредством выборки его по Id  
            */

            _viewModel.SelectedClient.MeasureDate = string.Empty;
            _viewModel.SelectedClient.MeasureTime = string.Empty;

            _viewModel.MeasureDates.Remove(_viewModel.MeasureDates.FirstOrDefault(x => x.ClientID.Equals(_viewModel.SelectedClient.Id)));

            _date.SaveMeasuresData(_viewModel.MeasureDates, _viewModel.datesPath);
            _client.SaveClientsData(_viewModel.Clients, _viewModel.clientsPath);
            _client.LoadClientsData(_viewModel.Clients, _viewModel.clientsPath);
            _viewModel.UpdateClientsData(_viewModel.Clients, _viewModel.clientsPath);
        }
    }
}
