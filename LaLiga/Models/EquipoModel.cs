using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaLiga.Models
{
    class EquipoModel : INotifyPropertyChanged, ICloneable
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

        private int id_club;
        public int ID_CLUB
        {
            get { return id_club; }
            set { id_club = value; OnPropertyChanged(nameof(ID_CLUB)); }
        }

        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; OnPropertyChanged(nameof(Nombre)); }
        }

        private int golesF;

        public int GolesF
        {
            get { return golesF; }
            set { golesF = value; OnPropertyChanged(nameof(GolesF)); }
        }

        private int golesC;
        public int GolesC
        {
            get { return golesC; }
            set { golesC = value; OnPropertyChanged(nameof(GolesC)); }
        }

        private int nJugadores;
        public int NJugadores
        {
            get { return nJugadores; }
            set { nJugadores = value; OnPropertyChanged(nameof(NJugadores)); }
        }

        private int victorias;
        public int Vctorias
        {
            get { return victorias; }
            set { victorias = value; OnPropertyChanged(nameof(Vctorias)); }
        }

        private int derrotas;
        public int Derrotas
        {
            get { return derrotas; }
            set { derrotas = value; OnPropertyChanged(nameof(Derrotas)); }
        }

        private int empates;
        public int Empates
        {
            get { return empates; }
            set { empates = value; OnPropertyChanged(nameof(Empates)); }
        }

        private int tAmarillas;
        public int TAmarillas
        {
            get { return tAmarillas; }
            set { tAmarillas = value; OnPropertyChanged(nameof(TAmarillas)); }
        }

        private int tRojas;
        public int TRojas
        {
            get { return tRojas; }
            set { tRojas = value; OnPropertyChanged(nameof(TRojas)); }
        }
        private int id_ligas;
        public int ID_ligas
        {
            get { return id_ligas; }
            set { id_ligas = value; OnPropertyChanged(nameof(ID_ligas)); }
        }
        private int puntos;
        public int Puntos { get { return puntos; } set { puntos = value; OnPropertyChanged(nameof(Puntos)); } }

        public EquipoModel()
        {

        }

        public override string ToString()
        {
            return nombre;
        }

        public EquipoModel(int id_club, string nombre, int golesF, int golesC, int nJugadores, int victorias, int derrotas, int empates, int tAmarillas, int tRojas, int id_ligas, int puntos)
        {
            this.id_club = id_club;
            this.nombre = nombre;
            this.golesF = golesF;
            this.golesC = golesC;
            this.nJugadores = nJugadores;
            this.victorias = victorias;
            this.derrotas = derrotas;
            this.empates = empates;
            this.tAmarillas = tAmarillas;
            this.tRojas = tRojas;
            this.id_ligas = id_ligas;
            this.puntos = puntos;
        }
    }
}
