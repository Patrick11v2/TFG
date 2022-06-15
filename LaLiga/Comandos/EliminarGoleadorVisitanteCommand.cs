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
    class EliminarGoleadorVisitanteCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            ResultadosView vista = (ResultadosView)parameter;
            ObservableCollection<AnotadorModel> listaGoleadoresVisitante1 = resultadosViewModel.ListaGoleadoresVisitante;
            AnotadorModel anotador = (AnotadorModel)vista.ListaGoleadoresVisitante.SelectedItem;
            try { 
            foreach (AnotadorModel anotadorModel in listaGoleadoresVisitante1)
            {
                if (anotadorModel.Jugador.ID_jugador == anotador.Jugador.ID_jugador)
                {
                    listaGoleadoresVisitante1.Remove(anotador);
                    resultadosViewModel.ListaGoleadoresVisitante = listaGoleadoresVisitante1;
                    resultadosViewModel.CurrentGoleadorVisitante = new AnotadorModel();

                    break;
                }
                else { }
            }
            }
            catch { }

            resultadosViewModel.UpdateGolesResultadosCommand.Execute(vista);
        }
        private ResultadosViewModel resultadosViewModel { get; set; }
        public EliminarGoleadorVisitanteCommand(ResultadosViewModel ResultadosViewModel) { this.resultadosViewModel = ResultadosViewModel; }
    }
}
