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
    class EliminarGoleadorLocalCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            ResultadosView vista = (ResultadosView)parameter;
            ObservableCollection<AnotadorModel> listaGoleadoresLocal1 = resultadosViewModel.ListaGoleadoresLocal;
            AnotadorModel anotador = (AnotadorModel)vista.ListaGoleadoresLocal.SelectedItem;
            try {
            foreach (AnotadorModel anotadorModel in listaGoleadoresLocal1)
            {
                if (anotadorModel.Jugador.ID_jugador == anotador.Jugador.ID_jugador)
                {
                    listaGoleadoresLocal1.Remove(anotador);
                    resultadosViewModel.ListaGoleadoresLocal = listaGoleadoresLocal1;
                    resultadosViewModel.CurrentGoleadorLocal = new AnotadorModel();

                    break;
                }
                else { }
                }
            }
            catch { }


            resultadosViewModel.UpdateGolesResultadosCommand.Execute(vista);
        }
        private ResultadosViewModel resultadosViewModel { get; set; }
        public EliminarGoleadorLocalCommand(ResultadosViewModel ResultadosViewModel) { this.resultadosViewModel = ResultadosViewModel; }
    }
}
