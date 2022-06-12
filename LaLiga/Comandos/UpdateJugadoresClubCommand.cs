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
using System.Windows.Forms;
using System.Windows.Input;

namespace LaLiga.Comandos
{
    class UpdateJugadoresClubCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {

            try { 
                JugadoresView vista = (JugadoresView)parameter;
                EquipoModel model = ((JugadoresViewModel)vista.DataContext).CurrentEquipoLista;
                ObservableCollection<JugadorModel> listaJugadoresl =new ObservableCollection<JugadorModel>();
            jugadoresViewModel.ListaJugadores = new ObservableCollection<JugadorModel>();
                

                
                    listaJugadoresl = DataSetHandler.getAllJugadores();
                    foreach (JugadorModel jugador in listaJugadoresl)
                    {
                        if (model.ID_CLUB == jugador.Equipo.ID_CLUB)
                        {
                            jugadoresViewModel.ListaJugadores.Add(jugador);
                        }


                    }

            }
            catch { }







        }

        private JugadoresViewModel jugadoresViewModel { get; set; }

        public UpdateJugadoresClubCommand(JugadoresViewModel JugadoresViewModel)
        {
            this.jugadoresViewModel = JugadoresViewModel;
        }
    }

   
}
