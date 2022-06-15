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
    class EliminarAmonestadoLocalCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            ResultadosView vista = (ResultadosView)parameter;
            ObservableCollection<AmonestadoModel> listaAmonestadosLocal = resultadosViewModel.ListaAmonestadosLocal;
            AmonestadoModel amonestado = (AmonestadoModel)vista.ListaAmonestadosLocal.SelectedItem;
            try { 
            foreach (AmonestadoModel amonestadoModel in listaAmonestadosLocal)
            {
                if (amonestadoModel.Jugador.ID_jugador == amonestado.Jugador.ID_jugador)
                {
                    listaAmonestadosLocal.Remove(amonestado);
                    resultadosViewModel.ListaAmonestadosLocal = listaAmonestadosLocal;
                    resultadosViewModel.CurrentAmonestadoLocal = new AmonestadoModel();
                    break;
                }
                else { }
            }
            }
            catch { }
            vista.TAAmonestadoLocal.SelectedIndex = -1;
            vista.TRAmonestadoLocal.SelectedIndex = -1;

        }
        private ResultadosViewModel resultadosViewModel { get; set; }
        public EliminarAmonestadoLocalCommand(ResultadosViewModel ResultadosViewModel) { this.resultadosViewModel = ResultadosViewModel; }
    }
}
