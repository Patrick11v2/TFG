using LaLiga.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LaLiga.Comandos
{
     class UpdateViewCommand : ICommand 
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Console.WriteLine(parameter.ToString());    
            string vista = parameter.ToString();
            if(vista.Equals("Ligas"))
            {
               MainViewModel.SelectedViewModel = new LigasViewModel();
                
            }
            else if (vista.Equals("Equipos"))
            {
                MainViewModel.SelectedViewModel = new EquiposViewModel();
               
            }
            else if (vista.Equals("Jugadores"))
            {
                MainViewModel.SelectedViewModel = new JugadoresViewModel();
            }
            else if (vista.Equals("Clasificacion"))
            {
                MainViewModel.SelectedViewModel = new ClasificacionViewModel();
            }
            else if (vista.Equals("Resultados"))
            {
                MainViewModel.SelectedViewModel = new ResultadosViewModel();
            }
        }

        public MainViewModel MainViewModel { get; set; }
        public UpdateViewCommand(MainViewModel mainViewModel)
        {
            MainViewModel = mainViewModel;
            MainViewModel.SelectedViewModel = new LigasViewModel();
        }
    }
}
