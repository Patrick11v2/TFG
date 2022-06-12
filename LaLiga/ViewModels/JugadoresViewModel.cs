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
     class JugadoresViewModel : ViewModelBase 
    {

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
        private ObservableCollection<JugadorModel> listaJugadores;
        public ObservableCollection<JugadorModel> ListaJugadores
        {
            get => listaJugadores is null ? listaJugadores = new ObservableCollection<JugadorModel>() : listaJugadores;
            set
            {
                listaJugadores = value;
                OnPropertyChanged(nameof(ListaJugadores));
            }
        }
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
        private EquipoModel currentEquipo;
        public EquipoModel CurrentEquipo
        {
            get => currentEquipo is null ? currentEquipo = new EquipoModel() : currentEquipo;
            set
            {
                currentEquipo = value;
                OnPropertyChanged();
            }
        }
        private EquipoModel currentEquipoLista;
        public EquipoModel CurrentEquipoLista
        {
            get => currentEquipoLista is null ? currentEquipoLista = new EquipoModel() : currentEquipoLista;
            set
            {
                currentEquipoLista = value;
                OnPropertyChanged();
            }
        }
        private JugadorModel currentJugador;
        public JugadorModel CurrentJugador
        {
            get => currentJugador is null ? currentJugador = new JugadorModel() : currentJugador;
            set
            {
                currentJugador= value;
                OnPropertyChanged();
            }
        }


        public ICommand CargarComboEquiposJugadoresCommand { get; set; }

        public ICommand CargarComboLigasJugadoresCommand { get; set; }

        public ICommand UpdateJugadoresClubCommand { set; get; }

        public ICommand JugadoresCommand { set; get; }

        public ICommand GuardarJugadorCommand { set; get; }

        public ICommand EliminarJugadorCommand { set; get; }
        public ICommand EditarJugadorCommand { get; set; }  
        public ICommand UpdateEquiposCommand { set; get; }

        public JugadoresViewModel()
        {
            CargarComboEquiposJugadoresCommand = new CargarComboEquiposJugadoresCommand(this);
            CargarComboLigasJugadoresCommand = new CargarComboLigasJugadoresCommand(this);
            UpdateJugadoresClubCommand = new UpdateJugadoresClubCommand(this);
            JugadoresCommand = new JugadoresCommand(this);
            GuardarJugadorCommand =new GuardarJugadorCommand(this);
            EliminarJugadorCommand =new EliminarJugadorCommand(this);
            EditarJugadorCommand=new EditarJugadorCommand(this);
            UpdateEquiposCommand = new UpdateEquiposCommand();
        }
    }


}
