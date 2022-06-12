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
    class JugadoresCommand : ICommand
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
                JugadorModel jugador = (JugadorModel)parameter;
                jugadoresViewModel.CurrentJugador = (JugadorModel)jugador.Clone();

            }
        }
        private JugadoresViewModel jugadoresViewModel { get; set; }

        public JugadoresCommand(JugadoresViewModel JugadoresViewModel)
        {
            this.jugadoresViewModel = JugadoresViewModel;
        }
    }
}
