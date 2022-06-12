using LaLiga.Services.DataSet;
using LaLiga.ViewModels;
using LaLiga.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace LaLiga.Comandos
{
    class EliminarEquipoCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            EquiposView vista = (EquiposView)parameter;
            bool borradoOK = DataSetHandler.borrarEquipo(equiposViewModel.CurrentEquipo);
            if (!borradoOK)
            {
                MessageBox.Show("No se pudo eliminar el equipo");
            }
            else
            {
                ((EquiposViewModel)vista.DataContext).UpdateEquiposCommand.Execute(vista);
                vista.EquiposListView.SelectedIndex = 0;
                MessageBox.Show("El equipo se ha eliminado correctamente");

            }

        }

        private EquiposViewModel equiposViewModel { get; set; }

        public EliminarEquipoCommand(EquiposViewModel EquiposViewModel)
        {
            equiposViewModel = EquiposViewModel;
        }
    }
}
