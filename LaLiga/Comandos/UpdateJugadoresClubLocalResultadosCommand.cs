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
    class UpdateJugadoresClubLocalResultadosCommand : ICommand
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
                ResultadosView vista = (ResultadosView)parameter;
                EquipoModel model = ((ResultadosViewModel)vista.DataContext).CurrentPartido.EquipoLocal;
                ObservableCollection<JugadorModel> listaJugadoresl = new ObservableCollection<JugadorModel>();
                resultadosViewModel.ListaJugadoresLocal = new ObservableCollection<JugadorModel>();
                vista.TextLocal.Text = model.Nombre;


                listaJugadoresl = DataSetHandler.getAllJugadores();
                foreach (JugadorModel jugador in listaJugadoresl)
                {
                    if (model.ID_CLUB == jugador.Equipo.ID_CLUB)
                    {
                        resultadosViewModel.ListaJugadoresLocal.Add(jugador);
                    }


                }

            }
            catch { }

        }

        private ResultadosViewModel resultadosViewModel { get; set; }

        public UpdateJugadoresClubLocalResultadosCommand(ResultadosViewModel ResultadosViewModel) { this.resultadosViewModel = ResultadosViewModel; }
    }
}
