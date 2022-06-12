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
    class EditarEquipoCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            EquiposView vista = (EquiposView)parameter;
            LigaModel model = ((EquiposViewModel)vista.DataContext).CurrentLiga;
            equiposViewModel.CurrentEquipo.ID_ligas = model.ID_LIGA;
            bool editadoOK = DataSetHandler.editarEquipo(equiposViewModel.CurrentEquipo);
            if (!editadoOK)
            {
                MessageBox.Show("No se pudo editar la liga");
            }
            else
            {
                ((EquiposViewModel)vista.DataContext).UpdateEquiposCommand.Execute("equipo");
                vista.EquiposListView.SelectedIndex = 0;
                MessageBox.Show("La liga se ha editado correctamente");

            }

        }

        private EquiposViewModel equiposViewModel{set; get;}

        public EditarEquipoCommand(EquiposViewModel EquiposViewModel) { equiposViewModel = EquiposViewModel;}
    }
}
