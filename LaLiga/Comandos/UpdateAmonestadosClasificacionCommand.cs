using LaLiga.Models;
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
     class UpdateAmonestadosClasificacionCommand :ICommand
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
            clasificacionViewModel.ListaAmonestados = DataSetHandler.getAmonestadosLiga(model);
            }
            catch { }
        }
        private ClasificacionViewModel clasificacionViewModel { get; set; }

        public UpdateAmonestadosClasificacionCommand (ClasificacionViewModel ClasificacionViewModel) { clasificacionViewModel = ClasificacionViewModel; }
    }
}
