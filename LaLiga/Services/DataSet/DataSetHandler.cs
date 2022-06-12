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
using System.Windows;

namespace LaLiga.Services.DataSet
{
    class DataSetHandler
    {
        private static LIGASTableAdapter LIGASAdapter = new LIGASTableAdapter();
        private static CLUBESTableAdapter CLUBESTAdapter = new CLUBESTableAdapter();
        private static JUGADORESTableAdapter JUGADORESTAdapter = new JUGADORESTableAdapter();



        private static PARTIDOSTableAdapter PARTIDOSTAdapter = new PARTIDOSTableAdapter();
        private static AMONESTADOSTableAdapter AMONESTADOSTAdapter = new AMONESTADOSTableAdapter();
        private static ANOTADORESTableAdapter ANOTADORESAdapter = new ANOTADORESTableAdapter();


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
        public static ObservableCollection<EquipoModel> getAllEquipos()
        {
            DataTable EQUIPOS = CLUBESTAdapter.GetData();
            DataTable JUGADORES = JUGADORESTAdapter.GetData();
            ObservableCollection<EquipoModel> listaEquipos = new ObservableCollection<EquipoModel>();

            foreach (DataRow row in EQUIPOS.Rows)
            {
                EquipoModel myEquipo = new EquipoModel();
                myEquipo.ID_CLUB = (int)row["Id_Club"];
                myEquipo.Nombre = row["NombreClub"].ToString();
                myEquipo.GolesF = (int)row["GFavor"];
                myEquipo.GolesC = (int)row["GContra"];
                myEquipo.NJugadores = (int)row["NJugadores"];
                myEquipo.Vctorias = (int)row["Victorias"];
                myEquipo.Derrotas = (int)row["Derrotas"];
                myEquipo.Empates = (int)row["Empates"];
                myEquipo.TAmarillas = (int)row["TAmarillas"];
                myEquipo.TRojas = (int)row["TRojas"];
                myEquipo.ID_ligas = (int)row["Id_Liga1"];
                listaEquipos.Add(myEquipo);
            }
            foreach (EquipoModel equipo1 in listaEquipos)
            {
                int NJ = 0;

                foreach (DataRow row1 in JUGADORES.Rows)
                {
                    if ((int)row1["Id_Club1"] == equipo1.ID_CLUB)
                    {
                        NJ++;
                    }

                }
                equipo1.NJugadores = NJ;
                foreach (DataRow row2 in EQUIPOS.Rows)
                {
                    if ((int)row2["Id_Club"] == equipo1.ID_CLUB)
                    {
                        EquipoModel myEquipo = new EquipoModel();
                        myEquipo.ID_CLUB = (int)row2["Id_Club"];
                        myEquipo.Nombre = row2["NombreClub"].ToString();
                        myEquipo.ID_ligas = (int)row2["Id_Liga1"];
                        myEquipo.NJugadores = (int)row2["NJugadores"];


                        CLUBESTAdapter.Update(equipo1.Nombre, myEquipo.GolesF, myEquipo.GolesC, equipo1.NJugadores, myEquipo.Vctorias, myEquipo.Derrotas, myEquipo.Empates
                            , myEquipo.TAmarillas, myEquipo.TRojas, equipo1.ID_ligas, myEquipo.ID_CLUB, myEquipo.Nombre, myEquipo.GolesF, myEquipo.GolesC, myEquipo.NJugadores
                            , myEquipo.Vctorias, myEquipo.Derrotas, myEquipo.Empates, myEquipo.TAmarillas, myEquipo.TRojas, myEquipo.ID_ligas);
                    }
                }

            }
            return listaEquipos;
        }
        public static ObservableCollection<JugadorModel> getAllJugadores()
        {
            DataTable JUGADORES = JUGADORESTAdapter.GetData();
            ObservableCollection<JugadorModel> listaJugadores = new ObservableCollection<JugadorModel>();
            ObservableCollection<EquipoModel> listaEquipos = getAllEquipos();

            foreach (DataRow row in JUGADORES.Rows)
            {
                JugadorModel myJugador = new JugadorModel();
                myJugador.ID_jugador = (int)row["Id_Jugador"];
                myJugador.NJugador = row["NJugador"].ToString();
                myJugador.AJugador = row["AJugador"].ToString();
                myJugador.Posicion = row["Posicion"].ToString();
                myJugador.TAmarillas = (int)row["TAmarillas"];
                myJugador.TRojas = (int)row["TRojas"];
                myJugador.Goles = (int)row["Goles"];
                myJugador.Numero = (int)row["Numero"];
                foreach (EquipoModel equipo in listaEquipos)
                {
                    if (equipo.ID_CLUB == (int)row["Id_Club1"])
                    {
                        myJugador.Equipo = equipo;
                    }

                }


                listaJugadores.Add(myJugador);
            }
            return listaJugadores;
        }

        public static bool insertarLiga(LigaModel liga)
        {
            DataTable LIGAS = LIGASAdapter.GetData();
            try
            {
                foreach (DataRow row in LIGAS.Rows)
                {
                    if (row["NombreLiga"].ToString() == liga.Nombre.ToString() || (int)row["NEquipos"] > 20)
                    {
                        return false;
                    }

                }

                LIGASAdapter.Insert(liga.Nombre, liga.Temporada, liga.Equipos);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool insertarEquipo(EquipoModel equipo)
        {
            DataTable LIGAS = LIGASAdapter.GetData();
            DataTable EQUIPOS = CLUBESTAdapter.GetData();
            int NE = 0;
            try
            {
                foreach (DataRow row in EQUIPOS.Rows)
                {
                    if (row["NombreClub"].ToString() == equipo.Nombre.ToString())
                    {
                        return false;
                    }

                }
                foreach (DataRow row in EQUIPOS.Rows)
                {
                    if ((int)row["Id_Liga1"] == equipo.ID_ligas)
                    {
                        NE++;
                    }
                    foreach (DataRow row1 in LIGAS.Rows)
                    {
                        if (equipo.ID_ligas == (int)row1["Id_Liga"])
                        {
                            if (NE >= (int)row1["NEquipos"])
                            {
                                
                                return false;
                            }

                        }
                    }
                }


                CLUBESTAdapter.Insert(equipo.Nombre, equipo.GolesF, equipo.GolesC, equipo.NJugadores, equipo.Vctorias, equipo.Derrotas, equipo.Empates, equipo.TAmarillas, equipo.TRojas, equipo.ID_ligas);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool insertarJugador(JugadorModel jugador)
        {
            DataTable JUGADORES = JUGADORESTAdapter.GetData();
            DataTable EQUIPOS = CLUBESTAdapter.GetData();
            try
            {
                foreach (DataRow row in JUGADORES.Rows)
                {
                    if ((int)row["Numero"] == jugador.Numero && (int)row["Id_Club1"] == jugador.Equipo.ID_CLUB || jugador.Numero > 99)
                    {
                        return false;
                    }

                }
                foreach (DataRow row in EQUIPOS.Rows)
                {
                    if ((int)row["Id_Club"] == jugador.Equipo.ID_CLUB)
                    {
                        EquipoModel myEquipo = new EquipoModel();
                        myEquipo.ID_CLUB = (int)row["Id_Club"];
                        myEquipo.Nombre = row["NombreClub"].ToString();
                        myEquipo.ID_ligas = (int)row["Id_Liga1"];
                        myEquipo.NJugadores = (int)row["NJugadores"];
                        jugador.Equipo.NJugadores = myEquipo.NJugadores + 1;

                        CLUBESTAdapter.Update(myEquipo.Nombre, myEquipo.GolesF, myEquipo.GolesC, jugador.Equipo.NJugadores, myEquipo.Vctorias, myEquipo.Derrotas, myEquipo.Empates
                            , myEquipo.TAmarillas, myEquipo.TRojas, myEquipo.ID_ligas, myEquipo.ID_CLUB, myEquipo.Nombre, myEquipo.GolesF, myEquipo.GolesC, myEquipo.NJugadores
                            , myEquipo.Vctorias, myEquipo.Derrotas, myEquipo.Empates, myEquipo.TAmarillas, myEquipo.TRojas, myEquipo.ID_ligas);
                    }
                }

                JUGADORESTAdapter.Insert(jugador.NJugador, jugador.AJugador, jugador.Posicion, jugador.TAmarillas, jugador.TRojas, jugador.Goles, jugador.Numero, jugador.Equipo.ID_CLUB);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool borrarLiga(LigaModel liga)
        {
            try
            {
                LIGASAdapter.Delete(liga.ID_LIGA, liga.Nombre, liga.Temporada, liga.Equipos);

                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool borrarEquipo(EquipoModel equipo)
        {
            try
            {
                CLUBESTAdapter.Delete(equipo.ID_CLUB, equipo.Nombre, equipo.GolesF, equipo.GolesC, equipo.NJugadores, equipo.Vctorias, equipo.Derrotas, equipo.Empates, equipo.TAmarillas, equipo.TRojas, equipo.ID_ligas);

                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool borrarJugador(JugadorModel jugador)
        {
            DataTable EQUIPOS = CLUBESTAdapter.GetData();
            try
            {
                foreach (DataRow row in EQUIPOS.Rows)
                {
                    if ((int)row["Id_Club"] == jugador.Equipo.ID_CLUB)
                    {
                        EquipoModel myEquipo = new EquipoModel();
                        myEquipo.ID_CLUB = (int)row["Id_Club"];
                        myEquipo.Nombre = row["NombreClub"].ToString();
                        myEquipo.ID_ligas = (int)row["Id_Liga1"];
                        myEquipo.NJugadores = (int)row["NJugadores"];
                        jugador.Equipo.NJugadores = myEquipo.NJugadores - 1;

                        CLUBESTAdapter.Update(myEquipo.Nombre, myEquipo.GolesF, myEquipo.GolesC, jugador.Equipo.NJugadores, myEquipo.Vctorias, myEquipo.Derrotas, myEquipo.Empates
                            , myEquipo.TAmarillas, myEquipo.TRojas, myEquipo.ID_ligas, myEquipo.ID_CLUB, myEquipo.Nombre, myEquipo.GolesF, myEquipo.GolesC, myEquipo.NJugadores
                            , myEquipo.Vctorias, myEquipo.Derrotas, myEquipo.Empates, myEquipo.TAmarillas, myEquipo.TRojas, myEquipo.ID_ligas);
                    }
                }
                JUGADORESTAdapter.Delete(jugador.ID_jugador, jugador.NJugador, jugador.AJugador, jugador.Posicion, jugador.TAmarillas, jugador.TRojas, jugador.Goles, jugador.Numero, jugador.Equipo.ID_CLUB);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool editarLiga(LigaModel liga)
        {
            DataTable LIGAS = LIGASAdapter.GetData();
            try
            {

                foreach (DataRow row in LIGAS.Rows)
                {
                    if ((int)row["Id_Liga"] == liga.ID_LIGA)
                    {
                        LigaModel myLiga = new LigaModel();
                        myLiga.ID_LIGA = (int)row["Id_Liga"];
                        myLiga.Nombre = row["NombreLiga"].ToString();
                        myLiga.Temporada = row["Temporada"].ToString();
                        myLiga.Equipos = (int)row["NEquipos"];

                        LIGASAdapter.Update(liga.Nombre, liga.Temporada, liga.Equipos, myLiga.ID_LIGA, myLiga.Nombre, myLiga.Temporada, myLiga.Equipos);
                    }
                }


                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool editarEquipo(EquipoModel equipo)
        {
            DataTable EQUIPOS = CLUBESTAdapter.GetData();
            DataTable LIGAS = LIGASAdapter.GetData();
            int NE = 0;
            try
            {

                foreach (DataRow row in EQUIPOS.Rows)
                {
                    if ((int)row["Id_Liga1"] == equipo.ID_ligas)
                    {
                        NE++;
                    }
                    foreach (DataRow row1 in LIGAS.Rows)
                    {
                        if (equipo.ID_ligas == (int)row1["Id_Liga"])
                        {
                            if (NE >= (int)row1["NEquipos"])
                            {

                                return false;
                            }

                        }
                    }
                }

                foreach (DataRow row in EQUIPOS.Rows)
                {
                    if ((int)row["Id_Club"] == equipo.ID_CLUB)
                    {
                        EquipoModel myEquipo = new EquipoModel();
                        myEquipo.ID_CLUB = (int)row["Id_Club"];
                        myEquipo.Nombre = row["NombreClub"].ToString();
                        myEquipo.ID_ligas = (int)row["Id_Liga1"];

                        CLUBESTAdapter.Update(equipo.Nombre, myEquipo.GolesF, myEquipo.GolesC, myEquipo.NJugadores, myEquipo.Vctorias, myEquipo.Derrotas, myEquipo.Empates
                            , myEquipo.TAmarillas, myEquipo.TRojas, equipo.ID_ligas, myEquipo.ID_CLUB, myEquipo.Nombre, myEquipo.GolesF, myEquipo.GolesC, myEquipo.NJugadores
                            , myEquipo.Vctorias, myEquipo.Derrotas, myEquipo.Empates, myEquipo.TAmarillas, myEquipo.TRojas, myEquipo.ID_ligas);
                    }
                }


                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool editarJugador(JugadorModel jugador)
        {
            DataTable EQUIPOS = CLUBESTAdapter.GetData();
            DataTable JUGADORES = JUGADORESTAdapter.GetData();
            ObservableCollection<EquipoModel> listaEquipos = getAllEquipos();






            foreach (DataRow row in JUGADORES.Rows)
            {
                
                if ((int)row["Id_Jugador"] == jugador.ID_jugador)
                {
                    JugadorModel myJugador = new JugadorModel();
                    myJugador.ID_jugador = (int)row["Id_Jugador"];
                    myJugador.NJugador = row["NJugador"].ToString();
                    myJugador.AJugador = row["AJugador"].ToString();
                    myJugador.Posicion = row["Posicion"].ToString();
                    myJugador.TAmarillas = (int)row["TAmarillas"];
                    myJugador.TRojas = (int)row["TRojas"];
                    myJugador.Goles = (int)row["Goles"];
                    myJugador.Numero = (int)row["Numero"];
                    foreach (EquipoModel equipo in listaEquipos)
                    {
                        if (equipo.ID_CLUB == (int)row["Id_Club1"])
                        {
                            myJugador.Equipo = equipo;
                        }

                    }
                    ObservableCollection<EquipoModel> listaEquiposS = getAllEquipos();
                    foreach (EquipoModel equipo1 in listaEquiposS)
                    {
                        int NJ = 0;

                        foreach (DataRow row1 in JUGADORES.Rows)
                        {
                            if ((int)row1["Id_Club1"] == equipo1.ID_CLUB)
                            {
                                NJ++;
                            }

                        }
                        equipo1.NJugadores = NJ;
                        foreach (DataRow row2 in EQUIPOS.Rows)
                        {
                            if ((int)row2["Id_Club"] == equipo1.ID_CLUB)
                            {
                                EquipoModel myEquipo = new EquipoModel();
                                myEquipo.ID_CLUB = (int)row2["Id_Club"];
                                myEquipo.Nombre = row2["NombreClub"].ToString();
                                myEquipo.ID_ligas = (int)row2["Id_Liga1"];
                                myEquipo.NJugadores = (int)row2["NJugadores"];


                                CLUBESTAdapter.Update(equipo1.Nombre, myEquipo.GolesF, myEquipo.GolesC, equipo1.NJugadores, myEquipo.Vctorias, myEquipo.Derrotas, myEquipo.Empates
                                    , myEquipo.TAmarillas, myEquipo.TRojas, equipo1.ID_ligas, myEquipo.ID_CLUB, myEquipo.Nombre, myEquipo.GolesF, myEquipo.GolesC, myEquipo.NJugadores
                                    , myEquipo.Vctorias, myEquipo.Derrotas, myEquipo.Empates, myEquipo.TAmarillas, myEquipo.TRojas, myEquipo.ID_ligas);
                            }
                        }

                    }
                    JUGADORESTAdapter.Update(jugador.NJugador, jugador.AJugador, jugador.Posicion, myJugador.TAmarillas, myJugador.TRojas, myJugador.Goles, jugador.Numero
                            , jugador.Equipo.ID_CLUB, myJugador.ID_jugador, myJugador.NJugador, myJugador.AJugador, myJugador.Posicion, myJugador.TAmarillas, myJugador.TRojas
                            , myJugador.Goles, myJugador.Numero, myJugador.Equipo.ID_CLUB);
                    
                    

                    
                    return true;
                }


               
            }
            return false;
        }
    }
}

