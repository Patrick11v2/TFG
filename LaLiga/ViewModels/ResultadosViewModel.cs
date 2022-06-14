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
     class ResultadosViewModel : ViewModelBase
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
        private ObservableCollection<int> listaJornadas;
        public ObservableCollection<int> ListaJornadas
        {
            get => listaJornadas is null ? listaJornadas =new ObservableCollection<int>()  : listaJornadas;
            set
            {
                listaJornadas=value;
                OnPropertyChanged(nameof (ListaJornadas));
            }
        }
        private int currentIdJornada;
        public int CurrentIdJornada { get { return currentIdJornada; }
            set { currentIdJornada = value; OnPropertyChanged(nameof(CurrentIdJornada)); }  
        }
        public ICommand CargarComboLigasResultadosCommand { get; set; }
        public ICommand CargarComboJornadasResultadosCommand { set; get; }

        public ResultadosViewModel()
        {
            CargarComboLigasResultadosCommand = new CargarComboLigasResultadosCommand(this);
            CargarComboJornadasResultadosCommand = new CargarComboJornadasResultadosCommand(this);
        }
    }
}
