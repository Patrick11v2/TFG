using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaLiga.Models
{
    class LigaModel : INotifyPropertyChanged, ICloneable
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(String propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public object Clone()
        {
            return MemberwiseClone();
        }

        private int id_liga;
        public int ID_LIGA
        {
            get { return id_liga; }
            set { id_liga = value; OnPropertyChanged(nameof(ID_LIGA)); }
        }
        private string nombre;
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; OnPropertyChanged(nameof(Nombre)); }
        }


             private string temporada;
        public string Temporada
        {
            get { return temporada; }
            set { temporada = value; OnPropertyChanged(nameof(Temporada)); }
        }
        private int equipos;
        public int Equipos
        {
            get { return equipos; }
            set { equipos = value; OnPropertyChanged(nameof(Equipos)); }
        }

        public LigaModel()
        {

        }
        public override string ToString()
        {
            return nombre+ " [ ID " + id_liga + " ] ";        }

        public LigaModel(int id_liga, string nombre, string temporada, int equipos)
        {
            this.id_liga = id_liga;
            this.nombre = nombre;
            this.temporada = temporada;
            this.equipos = equipos;
        }
    }
}
