using LaLiga.Models;
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
    class AñadirAmonestadoLocalCommand : ICommand

    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            ResultadosView vista = (ResultadosView)parameter;
            ObservableCollection<AmonestadoModel> listaAmonestadosLocal1 = resultadosViewModel.ListaAmonestadosLocal;
            AmonestadoModel amonestado = ((ResultadosViewModel)vista.DataContext).CurrentAmonestadoLocal;
            bool jrepetido = false;
            foreach (AmonestadoModel amonestadoModel in listaAmonestadosLocal1)
            {
                if (amonestadoModel.Jugador.ID_jugador == amonestado.Jugador.ID_jugador)
                {
                    jrepetido = true;

                    break;
                }
                else { }
            }
            if (jrepetido == false)
            {
                listaAmonestadosLocal1.Add(amonestado);
                resultadosViewModel.ListaAmonestadosLocal = listaAmonestadosLocal1;
                resultadosViewModel.CurrentAmonestadoLocal = new AmonestadoModel();
            }
            else { MessageBox.Show("Este jugador ya esta como amonestado"); }
            resultadosViewModel.UpdateGolesResultadosCommand.Execute(vista);
            vista.TAAmonestadoLocal.SelectedIndex = -1;
            vista.TRAmonestadoLocal.SelectedIndex = -1;

        }
        private ResultadosViewModel resultadosViewModel { get; set; }
        public AñadirAmonestadoLocalCommand(ResultadosViewModel ResultadosViewModel) { this.resultadosViewModel = ResultadosViewModel; }
    }
}
