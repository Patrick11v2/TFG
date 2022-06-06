using LaLiga.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
