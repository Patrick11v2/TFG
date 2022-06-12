using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaLiga.Models
{
    class JugadorModel : INotifyPropertyChanged, ICloneable
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

        private int id_jugador;
        public int ID_jugador
        {
            get { return id_jugador; }
            set
            {
                id_jugador = value; OnPropertyChanged(nameof(ID_jugador));
            }
        }
        private EquipoModel equipo;
        public EquipoModel Equipo
        {
            get { return equipo; }
            set { equipo = value; OnPropertyChanged(nameof(Equipo)); }
        }

        private string nJugador;
        public string NJugador
        {
            get { return nJugador; }
            set { nJugador = value; OnPropertyChanged(nameof(NJugador)); }
        }
        private string aJugador;
        public string AJugador { get { return aJugador; } set { aJugador = value;OnPropertyChanged(nameof(AJugador)); } }

        private string posicion;
        public string Posicion { get { return posicion; } set { posicion = value; OnPropertyChanged( nameof(Posicion)); } }

        private int tAmarillas;
        public int TAmarillas { get { return tAmarillas; } set { tAmarillas = value; OnPropertyChanged(nameof(TAmarillas)); } }

        private int tRojas;
        public int TRojas { get { return tRojas; } set { tRojas = value; OnPropertyChanged(nameof(TRojas)); } }

        private int goles;
        public int Goles { get { return goles; } set { goles = value; OnPropertyChanged(nameof(Goles)); } }

        private int numero;
        public int Numero { get { return numero; } set { numero = value; OnPropertyChanged(nameof(Numero)); } }


        public JugadorModel()
        {

        }

       public override string ToString()
        {
            return nJugador + " " + aJugador;
        }

        public JugadorModel(int id_jugador, EquipoModel equipo, string nJugador, string aJugador, string posicion, int tAmarillas, int tRojas, int goles, int numero)
        {
            this.id_jugador = id_jugador;
            this.equipo = equipo;
            this.nJugador = nJugador;
            this.aJugador = aJugador;
            this.posicion = posicion;
            this.tAmarillas = tAmarillas;
            this.tRojas = tRojas;
            this.goles = goles;
            this.numero = numero;
        }
    }
}
