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
    class EliminarJugadorCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            JugadoresView vista = (JugadoresView)parameter;
            bool borradoOK = DataSetHandler.borrarJugador(jugadoresViewModel.CurrentJugador);
            if (!borradoOK)
            {
                MessageBox.Show("No se pudo eliminar el jugador");
            }
            else
            {
                ((JugadoresViewModel)vista.DataContext).UpdateJugadoresClubCommand.Execute(vista);
                vista.JugadoresListView.SelectedIndex = 0;
                MessageBox.Show("El jugador se ha eliminado correctamente");

            }
        }
        private JugadoresViewModel jugadoresViewModel { get; set; }

        public EliminarJugadorCommand(JugadoresViewModel JugadoresViewModel)
        {
            this.jugadoresViewModel = JugadoresViewModel;
        }
    }
}
