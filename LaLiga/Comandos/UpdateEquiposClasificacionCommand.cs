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
    class UpdateEquiposClasificacionCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            try { 
            ClasificacionView vista = (ClasificacionView)parameter;
            LigaModel model = ((ClasificacionViewModel)vista.DataContext).CurrentLiga;
            ObservableCollection<EquipoModel> listaEquiposClasificacion;
            clasificacionViewModel.ListaEquipos = new ObservableCollection<EquipoModel>();
            if (model != null)
            {
                listaEquiposClasificacion = DataSetHandler.getAllEquipos();
                foreach (EquipoModel equipo in listaEquiposClasificacion)
                {
                    if (model.ID_LIGA == equipo.ID_ligas)
                    {
                        equipo.Puntos = (equipo.Vctorias * 3) + (equipo.Empates);
                        clasificacionViewModel.ListaEquipos.Add(equipo);
                    }


                }






            }
            }
            catch { }


        }
        private ClasificacionViewModel clasificacionViewModel { get; set; }

        public UpdateEquiposClasificacionCommand (ClasificacionViewModel ClasificacionViewModel) { this.clasificacionViewModel = ClasificacionViewModel; }

    }
}
