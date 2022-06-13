using LaLiga.Models;
using LaLiga.Services.DataSet;
using LaLiga.ViewModels;
using LaLiga.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LaLiga.Comandos
{
    class UpdateGoleadoresClasificacionCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            ClasificacionView vista = (ClasificacionView)parameter;
            try { 
            LigaModel model = ((ClasificacionViewModel)vista.DataContext).CurrentLiga;
           clasificacionViewModel.ListaGoleadores = DataSetHandler.getGoleadoresLiga(model);
            }
            catch { }
        }
        private ClasificacionViewModel clasificacionViewModel { get; set; }

        public UpdateGoleadoresClasificacionCommand (ClasificacionViewModel ClasificacionViewModel) { clasificacionViewModel = ClasificacionViewModel; }

    }
}
