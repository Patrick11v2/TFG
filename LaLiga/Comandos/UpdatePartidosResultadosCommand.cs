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
    class UpdatePartidosResultadosCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            ResultadosView vista = (ResultadosView)parameter;
            try {
                int jornada = ((ResultadosViewModel)vista.DataContext).CurrentIdJornada;
                ObservableCollection<PartidoModel> listaPartidosPorJornada;
                resultadosViewModel.ListaPartidosJornadas = new ObservableCollection<PartidoModel>();

                if(jornada != 0)
                {
                    listaPartidosPorJornada = DataSetHandler.getAllPartidos();
                    foreach (PartidoModel partido in listaPartidosPorJornada)
                    {
                        if(partido.Id_jornada == jornada && partido.LigaPartido.ID_LIGA == ((ResultadosViewModel)vista.DataContext).CurrentLiga.ID_LIGA )
                        {
                            resultadosViewModel.ListaPartidosJornadas.Add(partido);
                        }
                    }
                }

            }
            catch { }
        }
        private ResultadosViewModel resultadosViewModel { get; set; }

        public UpdatePartidosResultadosCommand(ResultadosViewModel ResultadosViewModel) { this.resultadosViewModel = ResultadosViewModel; }
    }
}
