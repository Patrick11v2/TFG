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
    class ClasificacionViewModel : ViewModelBase
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
        private ObservableCollection<EquipoModel> listaEquipos;
        public ObservableCollection<EquipoModel> ListaEquipos
        {
            get => listaEquipos is null ? listaEquipos = new ObservableCollection<EquipoModel>() : listaEquipos;
            set
            {
                listaEquipos = value;
                OnPropertyChanged(nameof(ListaEquipos));
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

        private ObservableCollection<JugadorModel> listaGoleadores;
        public ObservableCollection<JugadorModel> ListaGoleadores
        {
            get => listaGoleadores is null ? listaGoleadores = new ObservableCollection<JugadorModel>() : listaGoleadores;
            set { listaGoleadores = value; OnPropertyChanged(nameof(ListaGoleadores)); }
        }
        private ObservableCollection<JugadorModel> listaAmonestados;
        public ObservableCollection<JugadorModel> ListaAmonestados
        {
            get => listaAmonestados is null ? listaAmonestados = new ObservableCollection<JugadorModel>() : listaAmonestados;
            set { listaAmonestados = value; OnPropertyChanged(nameof(ListaAmonestados)); }
        }


        public ICommand CargarComboLigasClasificacionCommand { get; set; }
        public ICommand UpdateEquiposClasificacionCommand { set; get; }
        public ICommand UpdateAmonestadosClasificacionCommand { set; get; }

        public ICommand UpdateGoleadoresClasificacionCommand { set; get; }

        public ClasificacionViewModel()
        {
            CargarComboLigasClasificacionCommand = new CargarComboLigasClasificacionCommand(this);
            UpdateEquiposClasificacionCommand = new UpdateEquiposClasificacionCommand(this);
            UpdateGoleadoresClasificacionCommand = new UpdateGoleadoresClasificacionCommand(this);

            UpdateAmonestadosClasificacionCommand = new UpdateAmonestadosClasificacionCommand(this);
        }
    }
}
