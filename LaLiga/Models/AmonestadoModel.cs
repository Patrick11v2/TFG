using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaLiga.Models
{
    class AmonestadoModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(String propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }
        private JugadorModel jugador;
        public JugadorModel Jugador { get { return jugador; } set { jugador = value; OnPropertyChanged(nameof(Jugador)); } }

        private PartidoModel partido;
        public PartidoModel Partido { get { return partido; } set { partido = value; OnPropertyChanged(nameof(Partido)); } }

        private int tAmarilla;
        public int TAmarilla { get { return tAmarilla; } set { tAmarilla = value; OnPropertyChanged(nameof(TAmarilla)); } }

        private int tRoja;
        public int TRoja { get { return tRoja; } set { tRoja = value; OnPropertyChanged(nameof(TRoja)); } }

        public AmonestadoModel() { }

        public AmonestadoModel(JugadorModel jugador, PartidoModel partido, int tAmarilla, int tRoja)
        {
            this.jugador = jugador;
            this.partido = partido;
            this.tAmarilla = tAmarilla;
            this.tRoja = tRoja;
        }
    }
}
