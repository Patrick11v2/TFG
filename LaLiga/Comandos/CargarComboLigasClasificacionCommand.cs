using LaLiga.Services.DataSet;
using LaLiga.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LaLiga.Comandos
{
    class CargarComboLigasClasificacionCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
           clasificacionViewModel.ListaLigas = DataSetHandler.getAllLigas();
        }
        private ClasificacionViewModel clasificacionViewModel { get; set; }

        public CargarComboLigasClasificacionCommand(ClasificacionViewModel ClasificacionViewModel) { this.clasificacionViewModel = ClasificacionViewModel; }
    }
}
