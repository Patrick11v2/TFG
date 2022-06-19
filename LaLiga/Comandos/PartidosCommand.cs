using LaLiga.Models;
using LaLiga.ViewModels;
using LaLiga.Views;
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
            {   ResultadosView vista = (ResultadosView)parameter;
                try { 
                PartidoModel partido = vista.ListaPartidos.SelectedItem as PartidoModel;
                resultadosViewModel.CurrentPartido = (PartidoModel)partido.Clone();
                }
                catch { }



            }
        }
        private ResultadosViewModel resultadosViewModel { get; set; }
        public PartidosCommand (ResultadosViewModel ResultadosViewModel) { resultadosViewModel = ResultadosViewModel; }
    }
}
