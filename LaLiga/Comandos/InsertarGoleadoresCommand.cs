using LaLiga.Models;
using LaLiga.Services.DataSet;
using LaLiga.ViewModels;
using LaLiga.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace LaLiga.Comandos
{
    class InsertarGoleadoresCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            ResultadosView vista = (ResultadosView)parameter;
            ObservableCollection<AnotadorModel> listaGoleadores2 =new ObservableCollection<AnotadorModel>();
            ObservableCollection<AnotadorModel> listaGoleadores1 = new ObservableCollection<AnotadorModel>();
            listaGoleadores1 = resultadosViewModel.ListaGoleadoresLocal;
            listaGoleadores2 = resultadosViewModel.ListaGoleadoresVisitante;
            ObservableCollection<PartidoModel> listaPartidos = DataSetHandler.getAllPartidos();
            PartidoModel Cpartido = ((ResultadosViewModel)vista.DataContext).CurrentPartido;
            bool insertarOK = false;

            foreach (PartidoModel partido in listaPartidos)
            {
                if (partido.EquipoLocal.ID_CLUB == Cpartido.EquipoLocal.ID_CLUB && partido.EquipoVisitante.ID_CLUB == Cpartido.EquipoVisitante.ID_CLUB && partido.Id_jornada == Cpartido.Id_jornada && partido.LigaPartido.ID_LIGA == Cpartido.LigaPartido.ID_LIGA)
                {
                    foreach (AnotadorModel anotador in listaGoleadores1)
                    {
                        anotador.Partido= partido;
                        insertarOK = DataSetHandler.insertarAnotador(anotador);
                    }
                    foreach (AnotadorModel anotador1 in listaGoleadores2)
                    {
                        anotador1.Partido = partido;
                        insertarOK = DataSetHandler.insertarAnotador(anotador1);
                    }
                    if (insertarOK)
                    {
                        MessageBox.Show("Goleadores insertados correctamente");
                    }
                    else
                    {
                        MessageBox.Show("No se ha podido insertar los goleadores correctamente");
                    }
                }
               
            }


        }
        private ResultadosViewModel resultadosViewModel { get; set; }
        public InsertarGoleadoresCommand(ResultadosViewModel ResultadosViewModel) { this.resultadosViewModel = ResultadosViewModel; }
    }
}
