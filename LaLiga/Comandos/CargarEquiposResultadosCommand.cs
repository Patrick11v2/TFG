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
    class CargarEquiposResultadosCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            ResultadosView vista = (ResultadosView)parameter;
            try
            {
                if (((ResultadosViewModel)vista.DataContext).CurrentLiga != null)
                {

                    LigaModel model = ((ResultadosViewModel)vista.DataContext).CurrentLiga;
                    ObservableCollection<EquipoModel> listaEquiposLiga;
                    resultadosViewModel.ListaEquipos = new ObservableCollection<EquipoModel>();

                    if (model != null)
                    {
                        listaEquiposLiga = DataSetHandler.getAllEquipos();
                        foreach (EquipoModel equipo in listaEquiposLiga)
                        {
                            if (model.ID_LIGA == equipo.ID_ligas)
                            {
                                resultadosViewModel.ListaEquipos.Add(equipo);
                            }


                        }






                    }
                }
                else { }
            }
            catch { }
        }

        private ResultadosViewModel resultadosViewModel { get; set; }

        public CargarEquiposResultadosCommand (ResultadosViewModel ResultadosViewModel) { this.resultadosViewModel = ResultadosViewModel; }
    }
}
