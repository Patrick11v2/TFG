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
    class CargarComboLigasJugadoresCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            try
            {
                jugadoresViewModel.ListaLigas = DataSetHandler.getAllLigas();
            }
            catch { }
        }

        private JugadoresViewModel jugadoresViewModel { get; set; }

        public CargarComboLigasJugadoresCommand(JugadoresViewModel JugadoresViewModel) { this.jugadoresViewModel = JugadoresViewModel; }
    }
}
