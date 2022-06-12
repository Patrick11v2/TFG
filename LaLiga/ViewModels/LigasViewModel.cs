using LaLiga.Comandos;
using LaLiga.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LaLiga.ViewModels
{
     class LigasViewModel : ViewModelBase
    {
        private ObservableCollection<LigaModel> listaLigas;
        public ObservableCollection<LigaModel> ListaLigas
        {
            get => listaLigas is null ? listaLigas = new ObservableCollection<LigaModel>() : listaLigas;
            set
            {
                listaLigas = value;
                OnPropertyChanged(nameof(ListaLigas));
            }
        }
        private LigaModel currentLiga;
        public LigaModel CurrentLiga
        {
            get => currentLiga is null ? currentLiga = new LigaModel() : currentLiga;
            set
            {
                currentLiga = value;
                OnPropertyChanged();
            }
        }

        private LigaModel selectedLiga { set; get; }
        public LigaModel SelectedLiga
        {
            get => selectedLiga is null ? selectedLiga = new LigaModel() : selectedLiga;
            set
            {
                selectedLiga = value;
                OnPropertyChanged(nameof(selectedLiga));
            }
        }
        public ICommand GuardarLigaCommad { get; set; }
        public ICommand UpdateLigasCommand { get; set; }

        public ICommand EliminarLigaCommand { get; set; }
        public ICommand EditarLigaCommand { get; set; }

        public ICommand LigasCommand { get; set; }
        public LigasViewModel()
        {
            EditarLigaCommand = new EditarLigaCommand(this);
            GuardarLigaCommad = new GuardarLigaCommad(this);
            UpdateLigasCommand = new UpdateLigasCommand(this);
            LigasCommand = new LigasCommand(this);
            EliminarLigaCommand = new EliminarLigaCommand(this);
        }
    }
}
