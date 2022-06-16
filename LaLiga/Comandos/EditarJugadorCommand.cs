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
    class EditarJugadorCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            JugadoresView vista = (JugadoresView)parameter;
           
            
            
            bool editadoOK = DataSetHandler.editarJugador(jugadoresViewModel.CurrentJugador);
            if (!editadoOK)
            {
                MessageBox.Show("No se pudo editar el jugador");
            }
            else
            {
                ((JugadoresViewModel)vista.DataContext).UpdateJugadoresClubCommand.Execute(vista);
                vista.JugadoresListView.SelectedIndex = 0;
                
                
                MessageBox.Show("La jugador se ha editado correctamente");

            }
        }

        private JugadoresViewModel jugadoresViewModel { get; set; }
        private EquiposViewModel equiposViewModel { get; set; }

        public EditarJugadorCommand (JugadoresViewModel JugadoresViewModel) { jugadoresViewModel = JugadoresViewModel; }
    }
}
