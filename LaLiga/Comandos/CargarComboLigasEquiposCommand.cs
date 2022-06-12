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
    class CargarComboLigasEquiposCommand : ICommand

    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter.Equals("equipo"))
            {
                equiposViewModel.ListaLigas = DataSetHandler.getAllLigas();

            }
        }
        private EquiposViewModel equiposViewModel { get; set; }

        public CargarComboLigasEquiposCommand (EquiposViewModel EquiposViewModel) { equiposViewModel = EquiposViewModel; }
}
}
