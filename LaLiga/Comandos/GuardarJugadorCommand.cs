using LaLiga.Models;
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
    class GuardarJugadorCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            JugadoresView vista = (JugadoresView)parameter;
           
            
            bool insertarOK = DataSetHandler.insertarJugador(jugadoresViewModel.CurrentJugador);
            if (!insertarOK)
            {
                MessageBox.Show("No se pudo insertar el jugador");
            }
            else
            {
                ((JugadoresViewModel)vista.DataContext).UpdateJugadoresClubCommand.Execute(vista);
                vista.JugadoresListView.SelectedIndex = 0;

                MessageBox.Show("El jugador se ha registrado correctamente");
                jugadoresViewModel.CurrentJugador = new JugadorModel();
            }

        }

        private JugadoresViewModel jugadoresViewModel { get; set; }

        public GuardarJugadorCommand (JugadoresViewModel JugadoresViewModel)
        {
            this.jugadoresViewModel = JugadoresViewModel;
        }
    }
}
