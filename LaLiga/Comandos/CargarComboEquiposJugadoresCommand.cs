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
    class CargarComboEquiposJugadoresCommand : ICommand
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
                JugadoresView vista = (JugadoresView)parameter;
            LigaModel model = ((JugadoresViewModel)vista.DataContext).CurrentLiga;
            ObservableCollection<EquipoModel> listaEquiposLiga;
            jugadoresViewModel.ListaEquipos = new ObservableCollection<EquipoModel>() ;
          
                if (model != null)
                {
                    listaEquiposLiga = DataSetHandler.getAllEquipos();
                    foreach (EquipoModel equipo in listaEquiposLiga)
                    {
                        if (model.ID_LIGA == equipo.ID_ligas)
                        {
                            jugadoresViewModel.ListaEquipos.Add(equipo);
                        }


                    }






                }
            }
            catch { }
        }

        private JugadoresViewModel jugadoresViewModel { get; set; }

        public CargarComboEquiposJugadoresCommand(JugadoresViewModel JugadoresViewModel) { this.jugadoresViewModel = JugadoresViewModel; }
    }
}
