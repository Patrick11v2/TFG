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
    internal class UpdateLigasCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter.Equals("liga"))
            {
                ligasViewModel.ListaLigas = DataSetHandler.getAllLigas();
            }
        }
        private LigasViewModel ligasViewModel { get; set; }
        public UpdateLigasCommand(LigasViewModel ligasViewModel) { this.ligasViewModel = ligasViewModel; }  
    }
}
