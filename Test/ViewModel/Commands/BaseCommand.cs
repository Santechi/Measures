using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using Test.Model;

namespace Test.ViewModel.Commands
{
    public abstract class BaseCommand : ICommand
    {
        protected ViewModel _viewModel;
        protected Client _client;
        protected Date _date;

        public BaseCommand(ViewModel viewModel, Client client, Date date)
        {
            _viewModel = viewModel;
            _client = client;
            _date = date;

        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public abstract bool CanExecute(object parameter);

        public abstract void Execute(object parameter);
    }
}
