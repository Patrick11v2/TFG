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
            ObservableCollection<PartidoModel> listaPartidos = DataSetHandler.getAllPartidos();
            ObservableCollection<EquipoModel> listaEquipos = DataSetHandler.getAllEquipos();    
            bool pel = false;
            int nc = 0;
            if(listaPartidos != null) { 
            foreach(PartidoModel partido in listaPartidos)
            {
                if(partido.LigaPartido.ID_LIGA == ((LigasViewModel)vista.DataContext).CurrentLiga.ID_LIGA) {
                    MessageBox.Show("No se pudo editar la liga");
                        pel = true;
                    break;
                }
              
                
            }
            foreach(EquipoModel equipo in listaEquipos)
                {
                    if(equipo.ID_ligas == ((LigasViewModel)vista.DataContext).CurrentLiga.ID_LIGA)
                    {
                        nc++;
                    }
                }
            }
            if (pel == false && nc <= ((LigasViewModel)vista.DataContext).CurrentLiga.Equipos)
            {
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
            else { MessageBox.Show("No se pudo editar la liga"); }
           

        }
        private LigasViewModel ligasViewModel { get; set; }

        public EditarLigaCommand(LigasViewModel LigasViewModel)
        {
            ligasViewModel = LigasViewModel;
        }
    }
}
