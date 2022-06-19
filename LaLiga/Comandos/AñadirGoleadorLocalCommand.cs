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
    class AñadirGoleadorLocalCommand : ICommand
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
            AnotadorModel anotador = ((ResultadosViewModel)vista.DataContext).CurrentGoleadorLocal;
            bool jrepetido = false;
            foreach(AnotadorModel anotadorModel in listaGoleadoresLocal1)
            {
                if(anotadorModel.Jugador.ID_jugador == anotador.Jugador.ID_jugador)
                {   jrepetido=true;
                    
                    break;
                }
                else {  }
            }
            if(jrepetido == false)
            {
                listaGoleadoresLocal1.Add(anotador);
                resultadosViewModel.ListaGoleadoresLocal = listaGoleadoresLocal1;
                resultadosViewModel.CurrentGoleadorLocal = new AnotadorModel();
            }
            else { MessageBox.Show("Este jugador ya esta como anotador"); }
            resultadosViewModel.UpdateGolesResultadosCommand.Execute(vista);
            vista.GolesGoleadorLocal = new System.Windows.Controls.ComboBox();
            vista.GolesGoleadorLocal.SelectedIndex = -1;
            
        }
        private ResultadosViewModel resultadosViewModel { get; set; }

        public AñadirGoleadorLocalCommand(ResultadosViewModel ResultadosViewModel) { this.resultadosViewModel = ResultadosViewModel; }
    }
}
