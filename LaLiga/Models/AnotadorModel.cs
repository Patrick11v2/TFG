using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaLiga.Models
{
    class AnotadorModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(String propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        private JugadorModel jugador;
        public JugadorModel Jugador { get { return jugador; } set { jugador = value; OnPropertyChanged(nameof(Jugador)); } }

        private int golesPartido;
        public int GolesPartido { get { return golesPartido; } set { golesPartido = value; OnPropertyChanged(nameof(GolesPartido)); } }

        private PartidoModel partido;
        public PartidoModel Partido { get { return partido; } set { partido = value; OnPropertyChanged(nameof(Partido)); } }

        public AnotadorModel() { }

        public AnotadorModel(JugadorModel jugador, int golesPartido, PartidoModel partido)
        {
            this.jugador = jugador;
            this.golesPartido = golesPartido;
            this.partido = partido;
        }
    }
}
