using LaLiga.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LaLiga
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
            HabilitarControles("Ligas");
        }

        private void Btn_Click(Object sender, RoutedEventArgs e)
        {
            HabilitarControles(((Button)sender).Content.ToString());
        }

        private void HabilitarControles(string v)
        {
            switch (v)
            {
                case "Ligas":
                    BtnLigas.IsEnabled = false;
                    BtnEquipos.IsEnabled = true;
                    BtnJugadores.IsEnabled = true;
                    BtnClasificacion.IsEnabled = true;
                    BtnResultados.IsEnabled = true;

                    break;
                case "Equipos":
                    BtnLigas.IsEnabled = true;
                    BtnEquipos.IsEnabled = false;
                    BtnJugadores.IsEnabled = true;
                    BtnClasificacion.IsEnabled = true;
                    BtnResultados.IsEnabled = true;

                    break;
                case "Jugadores":
                    BtnLigas.IsEnabled = true;
                    BtnEquipos.IsEnabled = true;
                    BtnJugadores.IsEnabled = false;
                    BtnClasificacion.IsEnabled = true;
                    BtnResultados.IsEnabled = true;
                    break;
                case "Clasificación":

                    BtnLigas.IsEnabled = true;
                    BtnEquipos.IsEnabled = true;
                    BtnJugadores.IsEnabled = true;
                    BtnClasificacion.IsEnabled = false;
                    BtnResultados.IsEnabled = true;
                    break;
                case "Resultados":
                    BtnLigas.IsEnabled = true;
                    BtnEquipos.IsEnabled = true;
                    BtnJugadores.IsEnabled = true;
                    BtnClasificacion.IsEnabled = true;
                    BtnResultados.IsEnabled = false;
                    break;
            }
        }
    }
}
