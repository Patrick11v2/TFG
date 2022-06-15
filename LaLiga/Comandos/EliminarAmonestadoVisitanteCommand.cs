using LaLiga.Models;
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
     class EliminarAmonestadoVisitanteCommand :ICommand 
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            ResultadosView vista = (ResultadosView)parameter;
            ObservableCollection<AmonestadoModel> listaAmonestadosVisitante1 = resultadosViewModel.ListaAmonestadosVisitante;
            AmonestadoModel amonestado = (AmonestadoModel)vista.ListaAmonestadosVisitante.SelectedItem;
            try { 
            foreach (AmonestadoModel amonestadoModel in listaAmonestadosVisitante1)
            {
                if (amonestadoModel.Jugador.ID_jugador == amonestado.Jugador.ID_jugador)
                {
                    listaAmonestadosVisitante1.Remove(amonestado);
                    resultadosViewModel.ListaAmonestadosVisitante = listaAmonestadosVisitante1;
                    resultadosViewModel.CurrentAmonestadoVisitante = new AmonestadoModel();
                    break;
                }
                else { }
            }
            }
            catch { }
            vista.TAAmonestadoVisitante.SelectedIndex = -1;
            vista.TRAmonestadoVisitante.SelectedIndex = -1;

        }
        private ResultadosViewModel resultadosViewModel { get; set; }
        public EliminarAmonestadoVisitanteCommand(ResultadosViewModel ResultadosViewModel) { this.resultadosViewModel = ResultadosViewModel; }
    }
}
