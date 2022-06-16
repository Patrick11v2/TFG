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
    class CrearPartidoCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            ResultadosView vista = (ResultadosView)parameter;
            PartidoModel partido = ((ResultadosViewModel)vista.DataContext).CurrentPartido;
            partido.Id_jornada = ((ResultadosViewModel)vista.DataContext).CurrentIdJornada;
            partido.LigaPartido = ((ResultadosViewModel)vista.DataContext).CurrentLiga;
            ObservableCollection<AnotadorModel> listaGoleadoresLocales = ((ResultadosViewModel)vista.DataContext).ListaGoleadoresLocal;
            ObservableCollection<AnotadorModel> listaGoleadoresVisitantes = ((ResultadosViewModel)vista.DataContext).ListaGoleadoresVisitante;
            int golesL = 0;
            int golesV = 0;
            foreach (AnotadorModel anotador in listaGoleadoresLocales)
            {
                golesL = golesL + anotador.GolesPartido;
            }
            foreach (AnotadorModel anotador in listaGoleadoresVisitantes)
            {
                golesV = golesV + anotador.GolesPartido;
            }
            ObservableCollection<AmonestadoModel> listaAmonestadosLocal = ((ResultadosViewModel)vista.DataContext).ListaAmonestadosLocal;
            ObservableCollection<AmonestadoModel> listaAmonestadoVisitante = ((ResultadosViewModel)vista.DataContext).ListaAmonestadosVisitante;
            int taLocal = 0;
            int trLocal = 0;
            int taVisitante = 0;
            int trVisitante = 0;
            foreach (AmonestadoModel amonestado in listaAmonestadosLocal)
            {
                taLocal = taLocal + amonestado.TAmarilla;
                trLocal = trLocal + amonestado.TRoja;

            }
            foreach (AmonestadoModel amonestado1 in listaAmonestadoVisitante)
            {
                taVisitante = taVisitante + amonestado1.TAmarilla;
                trVisitante = trVisitante + amonestado1.TRoja;

            }
            partido.GLocal = golesL;
            partido.GVisitante = golesV;
            partido.TALocal = taLocal;
            partido.TRLocal = trLocal;
            partido.TAVisitante = taVisitante;
            partido.TRVisitante = trVisitante;
            bool insertarOk = DataSetHandler.insertarPartido(partido);
            if (insertarOk) {
                MessageBoxResult confirmacion = MessageBox.Show("¿Estás seguro de que quieres crear el partido? No se podrá eliminar ni modificar.", "Confirmación", MessageBoxButton.YesNo);
                switch (confirmacion)
                {
                    case MessageBoxResult.Yes:
                        resultadosViewModel.InsertarGoleadoresCommand.Execute(parameter);
                        resultadosViewModel.InsertarAmonestadosCommand.Execute(parameter);
                        resultadosViewModel.UpdatePartidosResultadosCommand.Execute(parameter);
                        break;

                    case MessageBoxResult.No:

                        bool borradoOK = DataSetHandler.borrarPartido(partido);
                        break;

                }
            }
            else { MessageBox.Show("No se ha podido crear el partido"); }
            

        }
        private ResultadosViewModel resultadosViewModel { get; set; }
       

        public CrearPartidoCommand(ResultadosViewModel resultadosViewModel) { this.resultadosViewModel = resultadosViewModel; }
    }
}
