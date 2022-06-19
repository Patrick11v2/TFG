using LaLiga.Models;
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
    class AñadirAmonestadoVisitanteCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            ResultadosView vista = (ResultadosView)parameter;
            ObservableCollection<AmonestadoModel> listaAmonestadosVisitante1 = resultadosViewModel.ListaAmonestadosVisitante;
            AmonestadoModel amonestado = ((ResultadosViewModel)vista.DataContext).CurrentAmonestadoVisitante;
            bool jrepetido = false;
            try { 
            foreach (AmonestadoModel amonestadoModel in listaAmonestadosVisitante1)
            {
                if (amonestadoModel.Jugador.ID_jugador == amonestado.Jugador.ID_jugador)
                {
                    jrepetido = true;

                    break;
                }
                else { }
            }
            if (jrepetido == false)
            {
                listaAmonestadosVisitante1.Add(amonestado);
                resultadosViewModel.ListaAmonestadosVisitante = listaAmonestadosVisitante1;
                resultadosViewModel.CurrentAmonestadoVisitante = new AmonestadoModel();
            }
            else { MessageBox.Show("Este jugador ya esta como amonestado"); }
            resultadosViewModel.UpdateGolesResultadosCommand.Execute(vista);
            vista.TAAmonestadoVisitante = new System.Windows.Controls.ComboBox();
            vista.TRAmonestadoVisitante = new System.Windows.Controls.ComboBox();
            vista.TAAmonestadoVisitante.SelectedIndex = -1;
            vista.TRAmonestadoVisitante.SelectedIndex = -1;
            }
            catch { }

        }
        private ResultadosViewModel resultadosViewModel { get; set; }
        public AñadirAmonestadoVisitanteCommand(ResultadosViewModel ResultadosViewModel) { this.resultadosViewModel = ResultadosViewModel; }
    }
}
