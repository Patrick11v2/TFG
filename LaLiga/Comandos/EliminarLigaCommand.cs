using LaLiga.Models;
using LaLiga.Services.DataSet;
using LaLiga.ViewModels;
using LaLiga.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace LaLiga.Comandos
{
    class EliminarLigaCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            LigasView vista = (LigasView)parameter;
            bool borradoOK = DataSetHandler.borrarLiga(ligasViewModel.CurrentLiga);
            if (!borradoOK)
            {
                MessageBox.Show("No se pudo eliminar la liga");
            }
            else
            {
                ((LigasViewModel)vista.DataContext).UpdateLigasCommand.Execute("liga");
                vista.LigasListView.SelectedIndex = 0;
                MessageBox.Show("La liga se ha eliminado correctamente");
               
            }
        }

        private LigasViewModel ligasViewModel { get; set; }

        public EliminarLigaCommand (LigasViewModel LigasViewModel)
        {
            ligasViewModel = LigasViewModel;
        }

    }
}
