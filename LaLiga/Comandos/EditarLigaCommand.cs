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
    class EditarLigaCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            LigasView vista = (LigasView)parameter;
            bool editadoOK = DataSetHandler.editarLiga(ligasViewModel.CurrentLiga);
            if (!editadoOK)
            {
                MessageBox.Show("No se pudo editar la liga");
            }
            else
            {
                ((LigasViewModel)vista.DataContext).UpdateLigasCommand.Execute("liga");
                vista.LigasListView.SelectedIndex = 0;
                MessageBox.Show("La liga se ha editado correctamente");

            }
        }
        private LigasViewModel ligasViewModel { get; set; }

        public EditarLigaCommand(LigasViewModel LigasViewModel)
        {
            ligasViewModel = LigasViewModel;
        }
    }
}
