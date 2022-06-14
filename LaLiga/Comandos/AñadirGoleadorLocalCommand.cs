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
            bool jrepetido = false;
            foreach(AnotadorModel anotadorModel in listaGoleadoresLocal1)
            {
                if(anotadorModel.Jugador.ID_jugador == ((ResultadosViewModel)vista.DataContext).CurrentGoleadorLocal.Jugador.ID_jugador)
                {   jrepetido=true;
                    
                    break;
                }
            }
            if(jrepetido == false)
            {
                resultadosViewModel.ListaGoleadoresLocal.Add(((ResultadosViewModel)vista.DataContext).CurrentGoleadorLocal);
            }else { MessageBox.Show("Este jugador ya esta como anotador"); }

        }
        private ResultadosViewModel resultadosViewModel { get; set; }

        public AñadirGoleadorLocalCommand(ResultadosViewModel ResultadosViewModel) { this.resultadosViewModel = ResultadosViewModel; }
    }
}
