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
    class GuardarLigaCommad : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {   LigasView vista = (LigasView)parameter;
            bool insertarOK = DataSetHandler.insertarLiga(ligaViewModel.CurrentLiga);
            if (!insertarOK)
            {
                MessageBox.Show("No se pudo insertar la liga");
            }
            else
            {
                ((LigasViewModel)vista.DataContext).UpdateLigasCommand.Execute("liga");
                vista.LigasListView.SelectedIndex = 0;
                
                
                MessageBox.Show("La liga se ha registrado correctamente");
                ligaViewModel.CurrentLiga = new LigaModel();

            }
        }


        private LigasViewModel ligaViewModel { get; set; }

        public GuardarLigaCommad(LigasViewModel LigasViewModel)
        {
           ligaViewModel=LigasViewModel;
        }
    }
}
