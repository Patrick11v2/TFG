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
     class AñadirGoleadorVisitanteCommand : ICommand 
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
            AnotadorModel anotador = ((ResultadosViewModel)vista.DataContext).CurrentGoleadorVisitante;
            bool jrepetido = false;
            foreach (AnotadorModel anotadorModel in listaGoleadoresVisitante1)
            {
                if (anotadorModel.Jugador.ID_jugador == anotador.Jugador.ID_jugador)
                {
                    jrepetido = true;

                    break;
                }
                else { }
            }
            if (jrepetido == false)
            {
                listaGoleadoresVisitante1.Add(anotador);
                resultadosViewModel.ListaGoleadoresVisitante = listaGoleadoresVisitante1;
                resultadosViewModel.CurrentGoleadorVisitante = new AnotadorModel();
            }
            else { MessageBox.Show("Este jugador ya esta como anotador"); }
            resultadosViewModel.UpdateGolesResultadosCommand.Execute(vista);
            vista.GolesGoleadorVisitante.SelectedIndex = -1;

        }
        private ResultadosViewModel resultadosViewModel { get; set; }

        public AñadirGoleadorVisitanteCommand(ResultadosViewModel ResultadosViewModel) { this.resultadosViewModel = ResultadosViewModel; }
    }
}

