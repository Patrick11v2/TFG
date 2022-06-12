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
    class GuardarEquipoCommand : ICommand
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
            bool insertarOK = DataSetHandler.insertarEquipo(equiposViewModel.CurrentEquipo);
            if (!insertarOK)
            {
                MessageBox.Show("No se pudo insertar el equipo");
            }
            else
            {
                ((EquiposViewModel)vista.DataContext).UpdateEquiposCommand.Execute("equipo");
                vista.EquiposListView.SelectedIndex = 0;

                MessageBox.Show("El equipo se ha registrado correctamente");
                equiposViewModel.CurrentEquipo = new EquipoModel();
            }

        }

        private EquiposViewModel equiposViewModel { get; set; }

        public GuardarEquipoCommand(EquiposViewModel EquiposViewModel)
        {
            equiposViewModel = EquiposViewModel;
        }
    }
}
