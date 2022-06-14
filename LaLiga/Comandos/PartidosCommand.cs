using LaLiga.Models;
using LaLiga.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LaLiga.Comandos
{
    class PartidosCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter != null)
            {
                PartidoModel partido = (PartidoModel)parameter;
                resultadosViewModel.CurrentPartido = (PartidoModel)partido.Clone();

            }
        }
        private ResultadosViewModel resultadosViewModel { get; set; }
        public PartidosCommand (ResultadosViewModel ResultadosViewModel) { resultadosViewModel = ResultadosViewModel; }
    }
}
