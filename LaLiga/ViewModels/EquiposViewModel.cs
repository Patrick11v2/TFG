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
     class EquiposViewModel : ViewModelBase
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

        private EquipoModel selectedEquipo { set; get; }
        public EquipoModel SelectedEquipo
        {
            get => selectedEquipo is null ? selectedEquipo = new EquipoModel() : selectedEquipo;
            set
            {
                selectedEquipo = value;
                OnPropertyChanged(nameof(SelectedEquipo));
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

        public ICommand UpdateEquiposCommand { get; set; }
        public ICommand CargarComboLigasEquiposCommand{ get; set; }

        public ICommand EquiposCommand { get; set; }

        public ICommand EliminarEquipoCommand { get; set; }

        public ICommand GuardarEquipoCommand { get; set; }

        public ICommand EditarEquipoCommand { set; get; }
        public EquiposViewModel()
        {
            UpdateEquiposCommand = new UpdateEquiposCommand();
            CargarComboLigasEquiposCommand = new CargarComboLigasEquiposCommand(this);
            EquiposCommand = new EquiposCommand(this);
            GuardarEquipoCommand = new GuardarEquipoCommand(this);
            EliminarEquipoCommand = new EliminarEquipoCommand(this);
            EditarEquipoCommand = new EditarEquipoCommand(this);
        }
    }
}
