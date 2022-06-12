using LaLiga.Models;
using LaLiga.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LaLiga.Comandos
{
    class EquiposCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter != null)
            {
                EquipoModel equipo = (EquipoModel)parameter;
                equiposViewModel.CurrentEquipo = (EquipoModel)equipo.Clone();

            }
        }

        private EquiposViewModel equiposViewModel { get; set; }

        public EquiposCommand (EquiposViewModel EquiposViewModel)
        {
            equiposViewModel = EquiposViewModel;
        }

    }
}
