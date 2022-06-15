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
        private ObservableCollection<JugadorModel> listaJugadoresLocal;
        public ObservableCollection<JugadorModel> ListaJugadoresLocal
        {
            get => listaJugadoresLocal is null ? listaJugadoresLocal = new ObservableCollection<JugadorModel>() : listaJugadoresLocal;
            set
            {
                listaJugadoresLocal = value;
                OnPropertyChanged(nameof(ListaJugadoresLocal));
            }
        }
        private ObservableCollection<JugadorModel> listaJugadoresVisitante;
        public ObservableCollection<JugadorModel> ListaJugadoresVisitante
        {
            get => listaJugadoresVisitante is null ? listaJugadoresVisitante = new ObservableCollection<JugadorModel>() : listaJugadoresVisitante;
            set
            {
                listaJugadoresVisitante = value;
                OnPropertyChanged(nameof(ListaJugadoresVisitante));
            }
        }
        private LigaModel currentLiga;
        public LigaModel CurrentLiga
        {
            get => currentLiga is null ? currentLiga = new LigaModel() : currentLiga;
            set
            {
                currentLiga = value;
                OnPropertyChanged(nameof(CurrentLiga));
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
        private ObservableCollection<AnotadorModel> listaGoleadoresLocal;
        public ObservableCollection<AnotadorModel> ListaGoleadoresLocal
        {
            get => listaGoleadoresLocal is null ? listaGoleadoresLocal = new ObservableCollection<AnotadorModel>() : listaGoleadoresLocal;
            set
            {
                listaGoleadoresLocal = value;
                OnPropertyChanged(nameof(ListaGoleadoresLocal));
            }
        }
        private ObservableCollection<AnotadorModel> listaGoleadoresVisitante;
        public ObservableCollection<AnotadorModel> ListaGoleadoresVisitante
        {
            get => listaGoleadoresVisitante is null ? listaGoleadoresVisitante = new ObservableCollection<AnotadorModel>() : listaGoleadoresVisitante;
            set
            {
                listaGoleadoresVisitante = value;
                OnPropertyChanged(nameof(ListaGoleadoresVisitante));
            }
        }
        private ObservableCollection<AmonestadoModel> listaAmonestadosVisitante;
        public ObservableCollection<AmonestadoModel> ListaAmonestadosVisitante
        {
            get => listaAmonestadosVisitante is null ? listaAmonestadosVisitante = new ObservableCollection<AmonestadoModel>() : listaAmonestadosVisitante;
            set
            {
                listaAmonestadosVisitante = value;
                OnPropertyChanged(nameof(ListaAmonestadosVisitante));
            }
        }
        private ObservableCollection<AmonestadoModel> listaAmonestadosLocal;
        public ObservableCollection<AmonestadoModel> ListaAmonestadosLocal
        {
            get => listaAmonestadosLocal is null ? listaAmonestadosLocal = new ObservableCollection<AmonestadoModel>() : listaAmonestadosLocal;
            set
            {
                listaAmonestadosLocal = value;
                OnPropertyChanged(nameof(ListaAmonestadosLocal));
            }
        }

        private int currentIdJornada;

        public int CurrentIdJornada { get { return currentIdJornada; }
            set { currentIdJornada = value; OnPropertyChanged(nameof(CurrentIdJornada)); }  
        }

        private ObservableCollection<PartidoModel> listaPartidosJornadas;
        public ObservableCollection<PartidoModel > ListaPartidosJornadas { 
            get => listaPartidosJornadas is null ? listaPartidosJornadas= new ObservableCollection<PartidoModel>() : listaPartidosJornadas;
            set { listaPartidosJornadas = value;
                OnPropertyChanged(nameof(ListaPartidosJornadas));
            }
        }
        private PartidoModel currentPartido;
        public PartidoModel CurrentPartido
        {
            get => currentPartido is null ? currentPartido = new PartidoModel() : currentPartido;
            set
            {
                currentPartido = value;
                OnPropertyChanged(nameof(CurrentPartido));
            }
        }
        private AnotadorModel currentGoleadorLocal;
        public AnotadorModel CurrentGoleadorLocal
        {
            get => currentGoleadorLocal is null ? currentGoleadorLocal = new AnotadorModel() : currentGoleadorLocal;
            set
            {
                currentGoleadorLocal = value;
                OnPropertyChanged(nameof(CurrentGoleadorLocal));
            }
        }
        private ObservableCollection<int> goles;
        public ObservableCollection<int> Goles
        {
            get => goles is null ? goles = new ObservableCollection<int>() : goles;
            set
            {
                goles = value;
                OnPropertyChanged(nameof(Goles));
            }
        }
        private ObservableCollection<int> amarillas;
        public ObservableCollection<int> Amarillas
        {
            get => amarillas is null ? amarillas = new ObservableCollection<int>() : amarillas;
            set
            {
                amarillas = value;
                OnPropertyChanged(nameof(Amarillas));
            }
        }
        private ObservableCollection<int> rojas;
        public ObservableCollection<int> Rojas
        {
            get => rojas is null ? rojas = new ObservableCollection<int>() : rojas;
            set
            {
                rojas = value;
                OnPropertyChanged(nameof(Rojas));
            }


        }
        private AnotadorModel currentGoleadorVisitante;
        public AnotadorModel CurrentGoleadorVisitante
        {
            get => currentGoleadorVisitante is null ? currentGoleadorVisitante = new AnotadorModel() : currentGoleadorVisitante;
            set
            {
                currentGoleadorVisitante = value;
                OnPropertyChanged(nameof(CurrentGoleadorVisitante));
            }
        }
        private AmonestadoModel currentAmonestadoLocal;
        public AmonestadoModel CurrentAmonestadoLocal
        {
            get => currentAmonestadoLocal is null ? currentAmonestadoLocal = new AmonestadoModel() : currentAmonestadoLocal;
            set
            {
                currentAmonestadoLocal = value;
                OnPropertyChanged(nameof(CurrentAmonestadoLocal));
            }
        }
        private AmonestadoModel currentAmonestadoVisitante;
        public AmonestadoModel CurrentAmonestadoVisitante
        {
            get => currentAmonestadoVisitante is null ? currentAmonestadoVisitante = new AmonestadoModel() : currentAmonestadoVisitante;
            set
            {
                currentAmonestadoVisitante = value;
                OnPropertyChanged(nameof(CurrentAmonestadoVisitante));
            }
        }

        public ICommand CargarComboLigasResultadosCommand { get; set; }
        public ICommand CargarComboJornadasResultadosCommand { set; get; }
        public ICommand UpdatePartidosResultadosCommand { get; set; }
        public ICommand CargarEquiposResultadosCommand { set; get; }
        public ICommand PartidosCommand { get; set; }
        public ICommand UpdateJugadoresClubVisitanteResultadosCommand { set; get; }
        public ICommand UpdateJugadoresClubLocalResultadosCommand { set; get; }
        public ICommand AñadirGoleadorLocalCommand { get; set; }
        public ICommand UpdateGolesResultadosCommand { set; get; }
        public ICommand EliminarGoleadorLocalCommand { set; get; }
        public ICommand AñadirAmonestadoLocalCommand { set; get; }
        public ICommand EliminarAmonestadoLocalCommand { get; set; }
        public ICommand AñadirGoleadorVisitanteCommand { get; set; }
        public ICommand EliminarGoleadorVisitanteCommand { set; get; }
        public ICommand AñadirAmonestadoVisitanteCommand { set; get; }
        public ICommand EliminarAmonestadoVisitanteCommand { get; set; }
        public ICommand InsertarAmonestadosCommand { get; set; }

        public ICommand CrearPartidoCommand { get; set; }
        public ICommand InsertarGoleadoresCommand { get; set; }

        public ResultadosViewModel()
        {
            AñadirGoleadorLocalCommand = new AñadirGoleadorLocalCommand(this);
            CargarComboLigasResultadosCommand = new CargarComboLigasResultadosCommand(this);
            CargarComboJornadasResultadosCommand = new CargarComboJornadasResultadosCommand(this);
            UpdatePartidosResultadosCommand = new UpdatePartidosResultadosCommand(this);
            CargarEquiposResultadosCommand = new CargarEquiposResultadosCommand(this);
            PartidosCommand = new PartidosCommand(this);
            UpdateJugadoresClubLocalResultadosCommand = new UpdateJugadoresClubLocalResultadosCommand(this);
            UpdateJugadoresClubVisitanteResultadosCommand = new UpdateJugadoresClubVisitanteResultadosCommand(this);
            UpdateGolesResultadosCommand = new UpdateGolesResultadosCommand(this);
            EliminarGoleadorLocalCommand = new EliminarGoleadorLocalCommand(this);
            AñadirAmonestadoLocalCommand = new AñadirAmonestadoLocalCommand(this);
            EliminarAmonestadoLocalCommand = new EliminarAmonestadoLocalCommand(this);
            EliminarAmonestadoVisitanteCommand = new EliminarAmonestadoVisitanteCommand(this);
            AñadirAmonestadoVisitanteCommand = new AñadirAmonestadoVisitanteCommand(this);
            EliminarGoleadorVisitanteCommand = new EliminarGoleadorVisitanteCommand(this);
            AñadirGoleadorVisitanteCommand = new AñadirGoleadorVisitanteCommand(this);
            InsertarGoleadoresCommand = new InsertarGoleadoresCommand(this);
            InsertarAmonestadosCommand = new InsertarAmonestadosCommand(this);
            CrearPartidoCommand = new CrearPartidoCommand(this);


        }
    }
}
