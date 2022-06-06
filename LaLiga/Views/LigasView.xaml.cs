using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace LaLiga.Views
{
    /// <summary>
    /// Lógica de interacción para LigaView.xaml
    /// </summary>
    public partial class LigasView : UserControl, INotifyPropertyChanged
    {

    

          protected void OnPropertyChanged(string propertyName = null)
           {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
           }
    
        

        public event PropertyChangedEventHandler PropertyChanged;

        public LigasView()
        {
            InitializeComponent();
        }

        private void LigasListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }

    
}
