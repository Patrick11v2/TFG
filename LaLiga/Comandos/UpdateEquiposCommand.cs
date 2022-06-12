using LaLiga.Services.DataSet;
using LaLiga.ViewModels;
using LaLiga.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LaLiga.Comandos
{
    class UpdateEquiposCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            EquiposView vista = (EquiposView)parameter;
            
               ((EquiposViewModel)vista.DataContext).ListaEquipos = DataSetHandler.getAllEquipos();
           
        }

        

        public UpdateEquiposCommand( ) { }
    }
}
