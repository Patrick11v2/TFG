using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaLiga.Models
{
    class PartidoModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(String propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private int id_partido;
        public int IdPartido { get {return id_partido; } set { id_partido = value; OnPropertyChanged(nameof(IdPartido)); } }

        private EquipoModel equipoLocal;
        public EquipoModel EquipoLocal { get { return equipoLocal; } set { equipoLocal = value; OnPropertyChanged(nameof(EquipoLocal)); } }

        private EquipoModel equipoVisitante;
        public EquipoModel EquipoVisitante { get { return equipoVisitante; } set { equipoVisitante = value; OnPropertyChanged(nameof(EquipoVisitante)); } }

        private int gLocal;
        public int GLocal { get { return gLocal; } set { gLocal = value;OnPropertyChanged(nameof(GLocal)); } }

        private int gVisitante;
        public int GVisitante { get { return gVisitante; } set { gVisitante = value; OnPropertyChanged(nameof(GVisitante)); } }

        private int tRLocal;
        public int TRLocal { get { return tRLocal; } set { tRLocal = value; OnPropertyChanged(nameof(TRLocal)); } }

        private int tALocal;
        public int TALocal { get { return tALocal; } set { tALocal = value; OnPropertyChanged(nameof(TALocal)); } }

        private int tRVisitante;
        public int TRVisitante { get { return tRVisitante; } set { tRVisitante = value;OnPropertyChanged(nameof(TRVisitante)); } }

        private int tAVisitante;
        public int TAVisitante { get { return tAVisitante; } set { tAVisitante = value; OnPropertyChanged(nameof(TAVisitante)); } }

        private int id_jornada;
        public int Id_jornada { get { return id_jornada; } set { id_jornada = value; OnPropertyChanged(nameof(Id_jornada)); } }

        private LigaModel ligaPartido;
        public LigaModel LigaPartido { get { return ligaPartido; } set { ligaPartido = value; OnPropertyChanged(nameof(LigaPartido)); } }

        public PartidoModel() { }

        public PartidoModel(int id_partido, EquipoModel equipoLocal, EquipoModel equipoVisitante, int gLocal, int gVisitante, int tRLocal, int tALocal, int tRVisitante, int tAVisitante, int id_jornada, LigaModel ligaPartido)
        {
            this.id_partido = id_partido;
            this.equipoLocal = equipoLocal;
            this.equipoVisitante = equipoVisitante;
            this.gLocal = gLocal;
            this.gVisitante = gVisitante;
            this.tRLocal = tRLocal;
            this.tALocal = tALocal;
            this.tRVisitante = tRVisitante;
            this.tAVisitante = tAVisitante;
            this.id_jornada = id_jornada;
            this.ligaPartido = ligaPartido;
        }
    }
}
