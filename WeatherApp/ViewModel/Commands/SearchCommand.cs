using System;
using System.Windows.Input;

namespace WeatherApp.ViewModel.Commands
{
    internal class SearchCommand : ICommand
    {
        public WeatherViewModel WeatherViewModel { get; set; }

        public SearchCommand(WeatherViewModel vm)
        {
            WeatherViewModel = vm;
        }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public bool CanExecute(object parameter)
        {
            string query = parameter as string;

            return string.IsNullOrWhiteSpace(query) == false;
        }

        public void Execute(object parameter)
        {
            WeatherViewModel.MakeQuery();
        }
    }
}