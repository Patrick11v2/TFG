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
    class LigasCommand : ICommand
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
                LigaModel liga = (LigaModel)parameter;
                ligasViewModel.CurrentLiga = (LigaModel)liga.Clone();
                
            }
        }
        private LigasViewModel ligasViewModel { get; set; }

        public LigasCommand(LigasViewModel LigasViewModel)
        {
            ligasViewModel = LigasViewModel;
        }
    }
    
}
