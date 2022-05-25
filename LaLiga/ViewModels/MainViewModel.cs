using LaLiga.Comandos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LaLiga.ViewModels
{
   class MainViewModel : ViewModelBase
    {
        private ViewModelBase selectedViewModel { get; set; }

        public ViewModelBase SelectedViewModel
        {
            get { return selectedViewModel; }
            set
            { 
            selectedViewModel = value; 
            OnPropertyChanged(nameof(SelectedViewModel));
            }
        }

        public ICommand UpdateViewCommand { set; get; }

        public MainViewModel()
        {
            SelectedViewModel = new LigasViewModel();

            UpdateViewCommand = new UpdateViewCommand(this);

        }
    }
}
