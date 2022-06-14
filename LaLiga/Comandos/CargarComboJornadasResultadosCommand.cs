using LaLiga.Models;
using LaLiga.Services.DataSet;
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
    class CargarComboJornadasResultadosCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            try { 
            ResultadosView vista = (ResultadosView)parameter;
            if (((ResultadosViewModel)vista.DataContext).CurrentLiga != null)
            {
                LigaModel model = ((ResultadosViewModel)vista.DataContext).CurrentLiga;
                    resultadosViewModel.ListaJornadas = new ObservableCollection<int>();

                    if (model != null)
                {
                    resultadosViewModel.ListaJornadas = DataSetHandler.getJornadas(model);
                }
            }
            }
            catch { }
        }
        private ResultadosViewModel resultadosViewModel { get; set; }

        public CargarComboJornadasResultadosCommand (ResultadosViewModel ResultadosViewModel) { this.resultadosViewModel = ResultadosViewModel; }
    }
}
