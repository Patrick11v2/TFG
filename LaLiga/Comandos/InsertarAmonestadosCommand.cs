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
using System.Windows;
using System.Windows.Input;

namespace LaLiga.Comandos
{
    class InsertarAmonestadosCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            ResultadosView vista = (ResultadosView)parameter;
            ObservableCollection<AmonestadoModel> listaAmonestadosLocal1 = new ObservableCollection<AmonestadoModel>();
             listaAmonestadosLocal1 = resultadosViewModel.ListaAmonestadosLocal;
            ObservableCollection<AmonestadoModel> listaAmonestadosVisitante1 = new ObservableCollection<AmonestadoModel>();
             listaAmonestadosVisitante1 = resultadosViewModel.ListaAmonestadosVisitante;
            ObservableCollection<PartidoModel> listaPartidos = DataSetHandler.getAllPartidos();
            PartidoModel Cpartido = ((ResultadosViewModel)vista.DataContext).CurrentPartido;
            bool insertarOK = false;
           
            foreach (PartidoModel partido in listaPartidos)
            { 
                if(partido.EquipoLocal.ID_CLUB == Cpartido.EquipoLocal.ID_CLUB && partido.EquipoVisitante.ID_CLUB == Cpartido.EquipoVisitante.ID_CLUB && partido.Id_jornada == Cpartido.Id_jornada && partido.LigaPartido.ID_LIGA == Cpartido.LigaPartido.ID_LIGA)
                {
                    foreach(AmonestadoModel amonestado in listaAmonestadosLocal1)
                    {
                        amonestado.Partido = partido;
                         insertarOK  = DataSetHandler.insertarAmonestado(amonestado);
                    }
                    foreach(AmonestadoModel amonestado1 in listaAmonestadosVisitante1)
                    {
                        amonestado1.Partido= partido;
                         insertarOK = DataSetHandler.insertarAmonestado(amonestado1);
                    }
                    if (insertarOK)
                    {
                        MessageBox.Show("Amonestados insertados correctamente");
                    }
                    else
                    {
                        MessageBox.Show("No se ha podido insertar los amonestados correctamente");
                    }
                }
              
            }
           

        }
        private ResultadosViewModel resultadosViewModel { get; set; }
        public InsertarAmonestadosCommand(ResultadosViewModel ResultadosViewModel) { this.resultadosViewModel = ResultadosViewModel; }
    }
}
