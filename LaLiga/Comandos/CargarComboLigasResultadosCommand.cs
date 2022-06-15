using LaLiga.Services.DataSet;
using LaLiga.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LaLiga.Comandos
{
    class CargarComboLigasResultadosCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            int n = 1;
            while(n<= 10)
            {
                resultadosViewModel.Goles.Add(n);
                n++;
            }

            resultadosViewModel.Amarillas.Add(1);
            resultadosViewModel.Amarillas.Add(2);

            resultadosViewModel.Rojas.Add(1);
            resultadosViewModel.ListaLigas = DataSetHandler.getAllLigas();
        }

        private ResultadosViewModel resultadosViewModel { get; set; }

        public CargarComboLigasResultadosCommand (ResultadosViewModel ResultadosViewModel) { this.resultadosViewModel = ResultadosViewModel; }
    }
}
