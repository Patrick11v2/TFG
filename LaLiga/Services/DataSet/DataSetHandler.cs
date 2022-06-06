using LaLiga.Models;
using LaLiga.Services.DataSet.LigaDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaLiga.Services.DataSet
{
     class DataSetHandler
    {
        private static LIGASTableAdapter LIGASAdapter = new LIGASTableAdapter();
        private static CLUBESTableAdapter CLUBESTAdapter = new CLUBESTableAdapter();
        private static JUGADORESTableAdapter JUGADORESTAdapter = new JUGADORESTableAdapter();
        private static PARTIDOSTableAdapter PARTIDOSTAdapter = new PARTIDOSTableAdapter(); 
        private static AMONESTADOSTableAdapter AMONESTADOSTAdapter = new AMONESTADOSTableAdapter();
        private static ANOTADORESTableAdapter  ANOTADORESAdapter = new ANOTADORESTableAdapter();











        public static ObservableCollection<LigaModel> getAllLigas()
        {
            DataTable LIGAS = LIGASAdapter.GetData();
            ObservableCollection<LigaModel> listaLigas = new ObservableCollection<LigaModel>();

            foreach (DataRow row in LIGAS.Rows)
            {
                LigaModel myLiga = new LigaModel();
                myLiga.ID_LIGA = (int)row["Id_Liga"];
                myLiga.Nombre = row["NombreLiga"].ToString();
                myLiga.Temporada = row["Temporada"].ToString();
                myLiga.Equipos = (int)row["NEquipos"];
                listaLigas.Add(myLiga); 
            }
            return listaLigas;
        }

        public static bool insertarLiga(LigaModel liga)
        {
            try
            {
                LIGASAdapter.Insert(liga.Nombre, liga.Temporada, liga.Equipos);
                return true ;
            }
            catch
            {
                return false;
            }
        }

    }
}
