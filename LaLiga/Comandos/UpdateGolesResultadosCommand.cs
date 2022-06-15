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
    class UpdateGolesResultadosCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            ResultadosView vista = (ResultadosView)parameter;
            ObservableCollection<AnotadorModel> listaGoleadoresLocales = ((ResultadosViewModel)vista.DataContext).ListaGoleadoresLocal;
            ObservableCollection<AnotadorModel> listaGoleadoresVisitantes = ((ResultadosViewModel)vista.DataContext).ListaGoleadoresVisitante;
            int golesL = 0;
            int golesV = 0;
            foreach (AnotadorModel anotador in listaGoleadoresLocales)
            {
                golesL =golesL +anotador.GolesPartido; 
            }
            foreach(AnotadorModel anotador in listaGoleadoresVisitantes)
            {
                golesV = golesV +anotador.GolesPartido;
            }
            vista.GolesLocal.Text= golesL.ToString();
            vista.GolesVisitante.Text= golesV.ToString();   
        }
        private ResultadosViewModel resultadosViewModel { get; set; }

        public UpdateGolesResultadosCommand(ResultadosViewModel resultadosViewModel) { this.resultadosViewModel = resultadosViewModel; }
    }
}
