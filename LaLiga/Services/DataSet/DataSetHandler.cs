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
    { //DECLARAMOS LOS TABLEADAPTER
        private static LIGASTableAdapter LIGASAdapter = new LIGASTableAdapter();
        private static CLUBESTableAdapter CLUBESTAdapter = new CLUBESTableAdapter();
        private static JUGADORESTableAdapter JUGADORESTAdapter = new JUGADORESTableAdapter();



        private static PARTIDOSTableAdapter PARTIDOSTAdapter = new PARTIDOSTableAdapter();
        private static AMONESTADOSTableAdapter AMONESTADOSTAdapter = new AMONESTADOSTableAdapter();
        private static ANOTADORESTableAdapter ANOTADORESAdapter = new ANOTADORESTableAdapter();

        //METODO PARA OBTENER TODAS LAS LIGAS
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
        //METODO PARA OBTENER LAS JORNADAS DE UN LIGA, DEPENDIENDO DE SU NUMERO DE EQUIPOS
        public static ObservableCollection<int> getJornadas(LigaModel liga)
        {
            DataTable LIGAS = LIGASAdapter.GetData();
            ObservableCollection<int> listaJornadas = new ObservableCollection<int>();
            
            foreach (DataRow row in LIGAS.Rows)
            {
                if((int)row["Id_Liga"] == liga.ID_LIGA)
                {
                    int n = 1;
                    if(liga.Equipos %2 == 0) { 
                    while(n <= (liga.Equipos - 1) * 2)
                    {
                        listaJornadas.Add(n);
                        n++;
                    }
                    }
                    else
                    {
                        while (n <=(liga.Equipos * 2))
                        {
                            listaJornadas.Add(n);
                            n++;
                        }
                    }
                }

            }
            return listaJornadas;

        }
        //METODO PARA OBTENER TODOS LOS EQUIPOS ACTUALIZANDO NJUGADORES SI TUVIESE
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
        //METODO PARA OBTENER TODOS LOS JUGADORES
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
        //METODO PARA OBTENER JUGADORES ORDENADOS POR GOLES
        public static ObservableCollection<JugadorModel> getAllJugadoresByGoles()
        {
            DataTable JUGADORES = JUGADORESTAdapter.GetDataByGoles();
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
        //METODO PARA OBTENER JUGADORES ORDENADOS POR TARJETAS
        public static ObservableCollection<JugadorModel> getAllJugadoresByTarjetas()
        {
            DataTable JUGADORES = JUGADORESTAdapter.GetDataByTarjetas();
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

        //METODO PARA OBTENER TODOS LOS PARTIDOS
        public static ObservableCollection<PartidoModel> getAllPartidos()
        {
            DataTable PARTIDOS = PARTIDOSTAdapter.GetData();
            ObservableCollection<PartidoModel> listaPartidos = new ObservableCollection<PartidoModel>();
            ObservableCollection<EquipoModel> listaEquipos = getAllEquipos();
            ObservableCollection<LigaModel> listaLigas = getAllLigas();
           

            foreach(DataRow row in PARTIDOS.Rows)
            {
                PartidoModel myPartido = new PartidoModel();
                myPartido.IdPartido = (int)row["Id_Partido"];
                foreach(EquipoModel equipo in listaEquipos)
                {
                    if(equipo.ID_CLUB == (int)row["Id_ELocal"])
                    {
                        myPartido.EquipoLocal = equipo;
                    }
                }
                foreach (EquipoModel equipo in listaEquipos)
                {
                    if (equipo.ID_CLUB == (int)row["Id_EVisitante"])
                    {
                        myPartido.EquipoVisitante = equipo;
                    }
                }
                myPartido.GLocal = (int)row["GLocal"];
                myPartido.GVisitante = (int)row["GVisitante"];
                myPartido.TRLocal = (int)row["TRLocal"];
                myPartido.TALocal = (int)row["TALocal"];
                myPartido.TRVisitante = (int)row["TRVisitante"];
                myPartido.TAVisitante = (int)row["TAVisitante"];
                myPartido.Id_jornada = (int)row["Id_Jornada"];
                foreach(LigaModel liga in listaLigas)
                {
                    if(liga.ID_LIGA == (int)row["Id_Liga2"])
                    {
                        myPartido.LigaPartido = liga;
                    }
                }
                listaPartidos.Add(myPartido);

            }
            return listaPartidos;

        }
        //METODO PARA OBTENER LOS ANOTADORES
        public static ObservableCollection<AnotadorModel> getAllAnotadores()
        {
            DataTable ANOTADORES = ANOTADORESAdapter.GetData();
            ObservableCollection<AnotadorModel> listaAnotadores = new ObservableCollection<AnotadorModel>();
            ObservableCollection<PartidoModel> listaPartidos = getAllPartidos();
            ObservableCollection<JugadorModel> listaJugadores = getAllJugadores();

            foreach(DataRow row in ANOTADORES.Rows)
            {
                AnotadorModel myAnotador = new AnotadorModel();
                foreach(JugadorModel jugador in listaJugadores)
                {
                    if(jugador.ID_jugador == (int)row["Id_Jugador1"])
                    {
                        myAnotador.Jugador=jugador;
                    }
                }
                myAnotador.GolesPartido = (int)row["Goles"];
                foreach(PartidoModel partido in listaPartidos)
                {
                    if(partido.IdPartido == (int)row["Id_Partido1"])
                    {
                        myAnotador.Partido=partido;
                    }
                }
                listaAnotadores.Add(myAnotador);
            }
            return listaAnotadores;

        }
        //METODO PARA OBTENER LOS GOLEADORES POR LIGA
        public static ObservableCollection<JugadorModel> getGoleadoresLiga(LigaModel currentLiga)
        {
           
            ObservableCollection<JugadorModel> listaGoleadoresLiga = new ObservableCollection<JugadorModel>();
           
            ObservableCollection<JugadorModel> listaJugadores = getAllJugadoresByGoles();

          
                foreach(JugadorModel jugador in listaJugadores)
                {
                    if(jugador.Goles > 0 && jugador.Equipo.ID_ligas == currentLiga.ID_LIGA) 
                    {
                    listaGoleadoresLiga.Add(jugador);
                    }
                }

            return listaGoleadoresLiga;
        }
        //METODO PARA OBTENER LOS AMONESTADOS POR LIGA
        public static ObservableCollection<JugadorModel> getAmonestadosLiga(LigaModel currentLiga)
        {

            ObservableCollection<JugadorModel> listaAmonestadosLiga = new ObservableCollection<JugadorModel>();

            ObservableCollection<JugadorModel> listaJugadores = getAllJugadoresByTarjetas();


            foreach (JugadorModel jugador in listaJugadores)
            {
                if ((jugador.TAmarillas > 0 || jugador.TRojas >0) && (jugador.Equipo.ID_ligas == currentLiga.ID_LIGA))
                {
                    listaAmonestadosLiga.Add(jugador);
                }
            }

            return listaAmonestadosLiga;
        }
        //METODO PARA OBTENER TODOS LOS AMONESTADOS
        public static ObservableCollection<AmonestadoModel> getAllAmonestados()
        {

            DataTable AMONESTADOS = AMONESTADOSTAdapter.GetData();
            ObservableCollection<AmonestadoModel> listaAmonestados = new ObservableCollection<AmonestadoModel>();
            ObservableCollection<PartidoModel> listaPartidos = getAllPartidos();
            ObservableCollection<JugadorModel> listaJugadores = getAllJugadores();
            foreach(DataRow row in AMONESTADOS.Rows)
            {
                AmonestadoModel myAmonestado = new AmonestadoModel();
                foreach(JugadorModel jugador in listaJugadores)
                {
                    if(jugador.ID_jugador == (int)row["Id_Jugador1"])
                    {
                        myAmonestado.Jugador = jugador;
                    }
                }
                myAmonestado.TAmarilla = (int)row["TA"];
                myAmonestado.TRoja = (int)row["TR"];
                foreach(PartidoModel partido in listaPartidos)
                {
                    if(partido.IdPartido == (int)row["Id_Partido1"])
                    {
                        myAmonestado.Partido = partido;
                    }
                }
                listaAmonestados.Add(myAmonestado);
            }
            return listaAmonestados;
        }

        //METODO PARA INSERTAR LIGAS
        public static bool insertarLiga(LigaModel liga)
        {
            DataTable LIGAS = LIGASAdapter.GetData();
            try
            {
                foreach (DataRow row in LIGAS.Rows)
                {
                    if (row["NombreLiga"].ToString() == liga.Nombre.ToString() || (int)row["NEquipos"] > 20 || (int)row["NEquipos"] <3)
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
        //METODO PARA INSERTAR PARTIDO, DONDE SE ACTUALIZAN LOS CLUBES IMPLICADOS DEPENDIENDO DEL RESULTADO DEL PARTIDO
        public static bool insertarPartido(PartidoModel partido)
        {
            DataTable PARTIDOS = PARTIDOSTAdapter.GetData();
            DataTable EQUIPOS = CLUBESTAdapter.GetData();
            int np = 0;
          foreach(DataRow row1 in PARTIDOS.Rows)
            {
                try { 
                    if((int)row1["Id_Liga2"] == partido.LigaPartido.ID_LIGA &&  (int)row1["Id_ELocal"]==partido.EquipoLocal.ID_CLUB && (int)row1["Id_EVisitante"] == partido.EquipoVisitante.ID_CLUB && partido.Id_jornada ==(int)row1["Id_Jornada"])
                    {
                        return false;
                    }else if((partido.EquipoLocal.ID_CLUB == (int)row1["Id_ELocal"] && (int)row1["Id_Liga2"] == partido.LigaPartido.ID_LIGA && partido.Id_jornada == (int)row1["Id_Jornada"]) || (partido.EquipoLocal.ID_CLUB == (int)row1["Id_EVisitante"] && (int)row1["Id_Liga2"] == partido.LigaPartido.ID_LIGA && partido.Id_jornada == (int)row1["Id_Jornada"])  ){
                    return false;
                    }else if ((partido.EquipoVisitante.ID_CLUB == (int)row1["Id_ELocal"] && (int)row1["Id_Liga2"] == partido.LigaPartido.ID_LIGA && partido.Id_jornada == (int)row1["Id_Jornada"]) || (partido.EquipoVisitante.ID_CLUB == (int)row1["Id_EVisitante"] && (int)row1["Id_Liga2"] == partido.LigaPartido.ID_LIGA && partido.Id_jornada == (int)row1["Id_Jornada"])){
                    return false;
                    }
                   if (partido.Id_jornada == (int)row1["Id_Jornada"] && partido.LigaPartido.ID_LIGA == (int)row1["Id_Liga2"])
                    {
                        np++;
                    }
                }
                catch { }
                }
            if((partido.LigaPartido.Equipos %2) == 0)
                {
                    if(np >= (partido.LigaPartido.Equipos / 2))
                    {
                        return false;
                    }
                }
                else
                {
                    if(np>= ((partido.LigaPartido.Equipos-1) / 2))
                    {
                        return false;
                    }
            }
            try { 
                PARTIDOSTAdapter.Insert(partido.EquipoLocal.ID_CLUB, partido.EquipoVisitante.ID_CLUB, partido.GLocal, partido.GVisitante, partido.TRLocal, partido.TALocal, partido.TRVisitante, partido.TAVisitante,
                    partido.Id_jornada, partido.LigaPartido.ID_LIGA);
            }
            catch { }
            if (partido.GLocal > partido.GVisitante)
           
                {
                    foreach (DataRow row in EQUIPOS.Rows)
                    {
                        if ((int)row["Id_Club"] == partido.EquipoLocal.ID_CLUB)
                        {
                            EquipoModel myEquipo = new EquipoModel();
                            myEquipo.ID_CLUB = (int)row["Id_Club"];
                            myEquipo.Nombre = row["NombreClub"].ToString();
                            myEquipo.ID_ligas = (int)row["Id_Liga1"];
                            myEquipo.GolesC = (int)row["GContra"];
                            myEquipo.GolesF = (int)row["GFavor"];
                            myEquipo.TAmarillas = (int)row["TAmarillas"];
                            myEquipo.TRojas = (int)row["TRojas"];
                            myEquipo.Vctorias = (int)row["Victorias"];
                            partido.EquipoLocal.GolesF = myEquipo.GolesF + partido.GLocal;
                            partido.EquipoLocal.GolesC = myEquipo.GolesC+ partido.GVisitante;
                            partido.EquipoLocal.TAmarillas = myEquipo.TAmarillas + partido.TALocal;
                            partido.EquipoLocal.TRojas = myEquipo.TRojas + partido.TRLocal;
                            partido.EquipoLocal.Vctorias = myEquipo.Vctorias+ 1;
                        

                        CLUBESTAdapter.UpdateEquiposResultados(partido.EquipoLocal.GolesF, partido.EquipoLocal.GolesC, partido.EquipoLocal.Vctorias,myEquipo.Derrotas, myEquipo.Empates, partido.EquipoLocal.TAmarillas
                                , partido.EquipoLocal.TRojas, myEquipo.ID_CLUB);
                          
                     
                        break;
                        }
                    }
                    foreach (DataRow row in EQUIPOS.Rows)
                    {
                        if ((int)row["Id_Club"] == partido.EquipoVisitante.ID_CLUB)
                        {
                            EquipoModel myEquipo = new EquipoModel();
                            myEquipo.ID_CLUB = (int)row["Id_Club"];
                            myEquipo.Nombre = row["NombreClub"].ToString();
                            myEquipo.ID_ligas = (int)row["Id_Liga1"];
                            myEquipo.GolesC = (int)row["GContra"];
                            myEquipo.GolesF = (int)row["GFavor"];
                            myEquipo.TAmarillas = (int)row["TAmarillas"];
                            myEquipo.TRojas = (int)row["TRojas"];
                            myEquipo.Derrotas = (int)row["Derrotas"];
                            partido.EquipoVisitante.GolesF = myEquipo.GolesF + partido.GVisitante;
                            partido.EquipoVisitante.GolesC = myEquipo.GolesC+ partido.GLocal;
                            partido.EquipoVisitante.TAmarillas = myEquipo.TAmarillas + partido.TAVisitante;
                            partido.EquipoVisitante.TRojas = myEquipo.TRojas + partido.TRVisitante;
                            partido.EquipoVisitante.Derrotas = myEquipo.Derrotas + 1;

                        CLUBESTAdapter.UpdateEquiposResultados(partido.EquipoVisitante.GolesF, partido.EquipoVisitante.GolesC,myEquipo.Vctorias, partido.EquipoVisitante.Derrotas, myEquipo.Empates, partido.EquipoVisitante.TAmarillas
                                 , partido.EquipoVisitante.TRojas, myEquipo.ID_CLUB);
                      
                        break;
                        }
                    }
                MessageBox.Show("Gana Local");
                }
                 else if (partido.GLocal == partido.GVisitante)

                {
                    foreach (DataRow row in EQUIPOS.Rows)
                    {
                    bool canUpdate = false;
                    EquipoModel myEquipo = new EquipoModel();
                    if ((int)row["Id_Club"] == partido.EquipoLocal.ID_CLUB)
                        {
                            
                            myEquipo.ID_CLUB = (int)row["Id_Club"];
                            myEquipo.Nombre = row["NombreClub"].ToString();
                            myEquipo.ID_ligas = (int)row["Id_Liga1"];
                            myEquipo.GolesC = (int)row["GContra"];
                            myEquipo.GolesF = (int)row["GFavor"];
                            myEquipo.TAmarillas = (int)row["TAmarillas"];
                            myEquipo.TRojas = (int)row["TRojas"];
                            myEquipo.Empates = (int)row["Empates"];
                            partido.EquipoLocal.GolesF = myEquipo.GolesF + partido.GLocal;
                            partido.EquipoLocal.GolesC = myEquipo.GolesC + partido.GVisitante;
                            partido.EquipoLocal.TAmarillas = myEquipo.TAmarillas + partido.TALocal;
                            partido.EquipoLocal.TRojas = myEquipo.TRojas + partido.TRLocal;
                            partido.EquipoLocal.Empates = myEquipo.Empates + 1;


                        CLUBESTAdapter.UpdateEquiposResultados(partido.EquipoLocal.GolesF, partido.EquipoLocal.GolesC, myEquipo.Vctorias, myEquipo.Derrotas, partido.EquipoLocal.Empates, partido.EquipoLocal.TAmarillas
                                   , partido.EquipoLocal.TRojas, myEquipo.ID_CLUB);
                        break;


                    }
               
                    }
                    foreach (DataRow row in EQUIPOS.Rows)
                    {
                        if ((int)row["Id_Club"] == partido.EquipoVisitante.ID_CLUB)
                        {
                            EquipoModel myEquipo = new EquipoModel();
                            myEquipo.ID_CLUB = (int)row["Id_Club"];
                            myEquipo.Nombre = row["NombreClub"].ToString();
                            myEquipo.ID_ligas = (int)row["Id_Liga1"];
                            myEquipo.GolesC = (int)row["GContra"];
                            myEquipo.GolesF = (int)row["GFavor"];
                            myEquipo.TAmarillas = (int)row["TAmarillas"];
                            myEquipo.TRojas = (int)row["TRojas"];
                            myEquipo.Empates = (int)row["Empates"];
                            partido.EquipoVisitante.GolesF = myEquipo.GolesF + partido.GVisitante;
                            partido.EquipoVisitante.GolesC = myEquipo.GolesC + partido.GLocal;
                            partido.EquipoVisitante.TAmarillas = myEquipo.TAmarillas + partido.TAVisitante;
                            partido.EquipoVisitante.TRojas = myEquipo.TRojas + partido.TRVisitante;
                            partido.EquipoVisitante.Empates = partido.EquipoVisitante.Empates  + 1;

                        CLUBESTAdapter.UpdateEquiposResultados(partido.EquipoVisitante.GolesF, partido.EquipoVisitante.GolesC, myEquipo.Vctorias, myEquipo.Derrotas, partido.EquipoVisitante.Empates, partido.EquipoVisitante.TAmarillas
                                    , partido.EquipoVisitante.TRojas, myEquipo.ID_CLUB);
                        break;
                        }
                    }
                MessageBox.Show("Empate");
                 }
               else if(partido.GLocal < partido.GVisitante)
                {
                    foreach (DataRow row in EQUIPOS.Rows)
                    {
                        if ((int)row["Id_Club"] == partido.EquipoLocal.ID_CLUB)
                        {
                            EquipoModel myEquipo = new EquipoModel();
                            myEquipo.ID_CLUB = (int)row["Id_Club"];
                            myEquipo.Nombre = row["NombreClub"].ToString();
                            myEquipo.ID_ligas = (int)row["Id_Liga1"];
                            myEquipo.GolesC = (int)row["GContra"];
                            myEquipo.GolesF = (int)row["GFavor"];
                            myEquipo.TAmarillas = (int)row["TAmarillas"];
                            myEquipo.TRojas = (int)row["TRojas"];
                            myEquipo.Derrotas = (int)row["Derrotas"];
                            partido.EquipoLocal.GolesF = myEquipo.GolesF + partido.GLocal;
                            partido.EquipoLocal.GolesC = myEquipo.GolesC + partido.GVisitante;
                            partido.EquipoLocal.TAmarillas = myEquipo.TAmarillas + partido.TALocal;
                            partido.EquipoLocal.TRojas = myEquipo.TRojas + partido.TRLocal;
                            partido.EquipoLocal.Derrotas = myEquipo.Derrotas + 1;

                        CLUBESTAdapter.UpdateEquiposResultados(partido.EquipoLocal.GolesF, partido.EquipoLocal.GolesC, myEquipo.Vctorias, partido.EquipoLocal.Derrotas, myEquipo.Empates, partido.EquipoLocal.TAmarillas
                              , partido.EquipoLocal.TRojas, myEquipo.ID_CLUB);
                        break;
                        }
                    }
                    foreach (DataRow row in EQUIPOS.Rows)
                    {
                        if ((int)row["Id_Club"] == partido.EquipoVisitante.ID_CLUB)
                        {
                            EquipoModel myEquipo = new EquipoModel();
                            myEquipo.ID_CLUB = (int)row["Id_Club"];
                            myEquipo.Nombre = row["NombreClub"].ToString();
                            myEquipo.ID_ligas = (int)row["Id_Liga1"];
                            myEquipo.GolesC = (int)row["GContra"];
                            myEquipo.GolesF = (int)row["GFavor"];
                            myEquipo.TAmarillas = (int)row["TAmarillas"];
                            myEquipo.TRojas = (int)row["TRojas"];
                            myEquipo.Vctorias = (int)row["Victorias"];
                            partido.EquipoVisitante.GolesF = myEquipo.GolesF + partido.GVisitante;
                            partido.EquipoVisitante.GolesC = myEquipo.GolesC + partido.GLocal;
                            partido.EquipoVisitante.TAmarillas = myEquipo.TAmarillas + partido.TAVisitante;
                            partido.EquipoVisitante.TRojas = myEquipo.TRojas + partido.TRVisitante;
                            partido.EquipoVisitante.Vctorias = myEquipo.Vctorias + 1;

                        CLUBESTAdapter.UpdateEquiposResultados(partido.EquipoVisitante.GolesF, partido.EquipoVisitante.GolesC, partido.EquipoVisitante.Vctorias, myEquipo.Derrotas, myEquipo.Empates, partido.EquipoVisitante.TAmarillas
                            , partido.EquipoVisitante.TRojas, myEquipo.ID_CLUB);
                        break;
                        }
                    }
                MessageBox.Show("Gana Visitante");
            }
            else
            {
                MessageBox.Show("No update");
            }

                return true;       
      

        }
        
        //METODO PARA INSERTAR EQUIPO CON VALIDACIONES
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
        //METODO PARA INSERTAR ANOTADOR CON VALIDACIONES
        public static bool insertarAnotador(AnotadorModel anotador)
        {
            DataTable PARTIDOS = PARTIDOSTAdapter.GetData();
            
            DataTable ANOTADORES = ANOTADORESAdapter.GetData();
           
            DataTable JUGADORES = JUGADORESTAdapter.GetData();
            try
            {
                foreach(DataRow row in PARTIDOS.Rows)
                {
                    if(anotador.Partido.IdPartido == (int)row["Id_Partido"])
                    {
                        foreach(DataRow row1 in ANOTADORES.Rows)
                        {
                            if(anotador.Partido.IdPartido == (int)row1["Id_Partido1"] && anotador.Jugador.ID_jugador == (int)row1["Id_Jugador1"])
                            {
                                return false;
                            }
                        }
                        ANOTADORESAdapter.Insert(anotador.Jugador.ID_jugador, anotador.GolesPartido, anotador.Partido.IdPartido);

                        foreach(DataRow row2 in JUGADORES.Rows)
                        {
                            if(anotador.Jugador.ID_jugador == (int)row2["Id_Jugador"])
                            {
                                JugadorModel myJugador = new JugadorModel();
                                myJugador.ID_jugador = (int)row2["Id_Jugador"];
                                myJugador.NJugador = row2["NJugador"].ToString();
                                myJugador.AJugador = row2["AJugador"].ToString();
                                myJugador.Posicion = row2["Posicion"].ToString();
                                myJugador.TAmarillas = (int)row2["TAmarillas"];
                                myJugador.TRojas = (int)row2["TRojas"];
                                myJugador.Goles = (int)row2["Goles"];
                                myJugador.Numero = (int)row2["Numero"];
                                int equipo = (int)row2["Id_Club1"];
                                int goles = myJugador.Goles + anotador.GolesPartido;
                                JUGADORESTAdapter.UpdateQuery( myJugador.TAmarillas, myJugador.TRojas, goles, 
                                    myJugador.ID_jugador);
                            }
                        }

                        return true;

                    }
                    
                }
                return false;
            }
            catch { return false; }
        }
        //METODO PARA INSERTAR AMONESTADO CON VALIDACIONES
        public static bool insertarAmonestado (AmonestadoModel amonestado)
        {
            DataTable PARTIDOS = PARTIDOSTAdapter.GetData();
            DataTable AMONESTADOS = AMONESTADOSTAdapter.GetData();
            DataTable JUGADORES = JUGADORESTAdapter.GetData();
           
                foreach (DataRow row in PARTIDOS.Rows)
                {
                    if (amonestado.Partido.IdPartido == (int)row["Id_Partido"])
                    {
                        foreach (DataRow row1 in AMONESTADOS.Rows)
                        {
                            if (amonestado.Partido.IdPartido == (int)row1["Id_Partido1"] && amonestado.Jugador.ID_jugador == (int)row1["Id_Jugador1"])
                            {
                                MessageBox.Show("Hay coincidencia"); 
                                return false;
                            }
                        }
                        AMONESTADOSTAdapter.Insert(amonestado.Jugador.ID_jugador, amonestado.TAmarilla,amonestado.TRoja,amonestado.Partido.IdPartido);

                        foreach (DataRow row2 in JUGADORES.Rows)
                        {
                            if (amonestado.Jugador.ID_jugador == (int)row2["Id_Jugador"])
                            {
                                JugadorModel myJugador = new JugadorModel();
                                myJugador.ID_jugador = (int)row2["Id_Jugador"];
                                myJugador.NJugador = row2["NJugador"].ToString();
                                myJugador.AJugador = row2["AJugador"].ToString();
                                myJugador.Posicion = row2["Posicion"].ToString();
                                myJugador.TAmarillas = (int)row2["TAmarillas"];
                                myJugador.TRojas = (int)row2["TRojas"];
                                myJugador.Goles = (int)row2["Goles"];
                                int equipo = (int)row2["Id_Club1"];
                            int ta = myJugador.TAmarillas + amonestado.TAmarilla;
                            int tr = myJugador.TRojas + amonestado.TRoja;
                                myJugador.Numero = (int)row2["Numero"];
                            JUGADORESTAdapter.UpdateQuery(ta, tr, myJugador.Goles,
                                 myJugador.ID_jugador);
                        }
                        }

                        return true;

                }
                else
                {

                }
               
                }
                return false;
           
        }

        //METODO PARA INSERTAR JUGADOR CON VALIDACIONES
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

        //METODO PARA BORRAR LIGA
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
       //METODO PARA BORRAR PARTIDO ACTUALIZANDO LOS CLUBES IMPLICADOS
        public static bool borrarPartido(PartidoModel partido)
        {
            DataTable PARTIDOS = PARTIDOSTAdapter.GetData();
            DataTable EQUIPOS = CLUBESTAdapter.GetData();
            try
            {
                foreach(DataRow row in PARTIDOS.Rows)
                {
                    if (partido.EquipoLocal.ID_CLUB == (int)row["Id_ELocal"] && partido.EquipoVisitante.ID_CLUB == (int)row["Id_EVisitante"] && partido.Id_jornada == (int)row["Id_Jornada"] && partido.LigaPartido.ID_LIGA == (int)row["Id_Liga2"])
                    {
                        partido.IdPartido = (int)row["Id_Partido"];
                        PARTIDOSTAdapter.Delete(partido.IdPartido, partido.EquipoLocal.ID_CLUB, partido.EquipoVisitante.ID_CLUB, partido.GLocal, partido.GVisitante, partido.TRLocal,
                            partido.TALocal, partido.TRVisitante, partido.TAVisitante, partido.Id_jornada, partido.LigaPartido.ID_LIGA);
                        if (partido.GLocal > partido.GVisitante)
                        {
                            foreach (DataRow row1 in EQUIPOS.Rows)
                            {
                                if ((int)row1["Id_Club"] == partido.EquipoLocal.ID_CLUB)
                                {
                                    EquipoModel myEquipo = new EquipoModel();
                                    myEquipo.ID_CLUB = (int)row1["Id_Club"];
                                    myEquipo.Nombre = row1["NombreClub"].ToString();
                                    myEquipo.ID_ligas = (int)row1["Id_Liga1"];
                                    partido.EquipoLocal.GolesF = partido.EquipoLocal.GolesF - partido.GLocal;
                                    partido.EquipoLocal.GolesC = partido.EquipoLocal.GolesC - partido.GVisitante;
                                    partido.EquipoLocal.TAmarillas = partido.EquipoLocal.TAmarillas - partido.TALocal;
                                    partido.EquipoLocal.TRojas = partido.EquipoLocal.TRojas - partido.TRLocal;
                                    partido.EquipoLocal.Vctorias = partido.EquipoLocal.Vctorias - 1;

                                    CLUBESTAdapter.Update(myEquipo.Nombre, partido.EquipoLocal.GolesF, partido.EquipoLocal.GolesC, myEquipo.NJugadores, partido.EquipoLocal.Vctorias, myEquipo.Derrotas, myEquipo.Empates
                                        , partido.EquipoLocal.TAmarillas, partido.EquipoLocal.TRojas, myEquipo.ID_ligas, myEquipo.ID_CLUB, myEquipo.Nombre, myEquipo.GolesF, myEquipo.GolesC, myEquipo.NJugadores
                                        , myEquipo.Vctorias, myEquipo.Derrotas, myEquipo.Empates, myEquipo.TAmarillas, myEquipo.TRojas, myEquipo.ID_ligas);
                                }
                            }
                            foreach (DataRow row1 in EQUIPOS.Rows)
                            {
                                if ((int)row1["Id_Club"] == partido.EquipoVisitante.ID_CLUB)
                                {
                                    EquipoModel myEquipo = new EquipoModel();
                                    myEquipo.ID_CLUB = (int)row1["Id_Club"];
                                    myEquipo.Nombre = row1["NombreClub"].ToString();
                                    myEquipo.ID_ligas = (int)row1["Id_Liga1"];
                                    partido.EquipoVisitante.GolesF = partido.EquipoVisitante.GolesF - partido.GVisitante;
                                    partido.EquipoVisitante.GolesC = partido.EquipoVisitante.GolesC - partido.GLocal;
                                    partido.EquipoVisitante.TAmarillas = partido.EquipoVisitante.TAmarillas - partido.TAVisitante;
                                    partido.EquipoVisitante.TRojas = partido.EquipoVisitante.TRojas - partido.TRVisitante;
                                    partido.EquipoVisitante.Vctorias = partido.EquipoVisitante.Derrotas - 1;

                                    CLUBESTAdapter.Update(myEquipo.Nombre, partido.EquipoVisitante.GolesF, partido.EquipoVisitante.GolesC, myEquipo.NJugadores, myEquipo.Vctorias, partido.EquipoVisitante.Derrotas, myEquipo.Empates
                                        , partido.EquipoVisitante.TAmarillas, partido.EquipoVisitante.TRojas, myEquipo.ID_ligas, myEquipo.ID_CLUB, myEquipo.Nombre, myEquipo.GolesF, myEquipo.GolesC, myEquipo.NJugadores
                                        , myEquipo.Vctorias, myEquipo.Derrotas, myEquipo.Empates, myEquipo.TAmarillas, myEquipo.TRojas, myEquipo.ID_ligas);
                                }
                            }
                        }
                        if (partido.GLocal == partido.GVisitante)

                        {
                            foreach (DataRow row1 in EQUIPOS.Rows)
                            {
                                if ((int)row1["Id_Club"] == partido.EquipoLocal.ID_CLUB)
                                {
                                    EquipoModel myEquipo = new EquipoModel();
                                    myEquipo.ID_CLUB = (int)row1["Id_Club"];
                                    myEquipo.Nombre = row1["NombreClub"].ToString();
                                    myEquipo.ID_ligas = (int)row1["Id_Liga1"];
                                    partido.EquipoLocal.GolesF = partido.EquipoLocal.GolesF - partido.GLocal;
                                    partido.EquipoLocal.GolesC = partido.EquipoLocal.GolesC - partido.GVisitante;
                                    partido.EquipoLocal.TAmarillas = partido.EquipoLocal.TAmarillas - partido.TALocal;
                                    partido.EquipoLocal.TRojas = partido.EquipoLocal.TRojas - partido.TRLocal;
                                    partido.EquipoLocal.Vctorias = partido.EquipoLocal.Empates - 1;

                                    CLUBESTAdapter.Update(myEquipo.Nombre, partido.EquipoLocal.GolesF, partido.EquipoLocal.GolesC, myEquipo.NJugadores, myEquipo.Vctorias, myEquipo.Derrotas, partido.EquipoLocal.Empates
                                        , partido.EquipoLocal.TAmarillas, partido.EquipoLocal.TRojas, myEquipo.ID_ligas, myEquipo.ID_CLUB, myEquipo.Nombre, myEquipo.GolesF, myEquipo.GolesC, myEquipo.NJugadores
                                        , myEquipo.Vctorias, myEquipo.Derrotas, myEquipo.Empates, myEquipo.TAmarillas, myEquipo.TRojas, myEquipo.ID_ligas);
                                }
                            }
                            foreach (DataRow row1 in EQUIPOS.Rows)
                            {
                                if ((int)row1["Id_Club"] == partido.EquipoVisitante.ID_CLUB)
                                {
                                    EquipoModel myEquipo = new EquipoModel();
                                    myEquipo.ID_CLUB = (int)row1["Id_Club"];
                                    myEquipo.Nombre = row1["NombreClub"].ToString();
                                    myEquipo.ID_ligas = (int)row1["Id_Liga1"];
                                    partido.EquipoVisitante.GolesF = partido.EquipoVisitante.GolesF -partido.GVisitante;
                                    partido.EquipoVisitante.GolesC = partido.EquipoVisitante.GolesC - partido.GLocal;
                                    partido.EquipoVisitante.TAmarillas = partido.EquipoVisitante.TAmarillas - partido.TAVisitante;
                                    partido.EquipoVisitante.TRojas = partido.EquipoVisitante.TRojas - partido.TRVisitante;
                                    partido.EquipoVisitante.Vctorias = partido.EquipoVisitante.Empates - 1;

                                    CLUBESTAdapter.Update(myEquipo.Nombre, partido.EquipoVisitante.GolesF, partido.EquipoVisitante.GolesC, myEquipo.NJugadores, myEquipo.Vctorias, myEquipo.Derrotas, partido.EquipoVisitante.Empates
                                        , partido.EquipoVisitante.TAmarillas, partido.EquipoVisitante.TRojas, myEquipo.ID_ligas, myEquipo.ID_CLUB, myEquipo.Nombre, myEquipo.GolesF, myEquipo.GolesC, myEquipo.NJugadores
                                        , myEquipo.Vctorias, myEquipo.Derrotas, myEquipo.Empates, myEquipo.TAmarillas, myEquipo.TRojas, myEquipo.ID_ligas);
                                }
                            }
                        }
                        if (partido.GLocal < partido.GVisitante)
                        {
                            foreach (DataRow row1 in EQUIPOS.Rows)
                            {
                                if ((int)row1["Id_Club"] == partido.EquipoLocal.ID_CLUB)
                                {
                                    EquipoModel myEquipo = new EquipoModel();
                                    myEquipo.ID_CLUB = (int)row1["Id_Club"];
                                    myEquipo.Nombre = row1["NombreClub"].ToString();
                                    myEquipo.ID_ligas = (int)row1["Id_Liga1"];
                                    partido.EquipoLocal.GolesF = partido.EquipoLocal.GolesF - partido.GLocal;
                                    partido.EquipoLocal.GolesC = partido.EquipoLocal.GolesC - partido.GVisitante;
                                    partido.EquipoLocal.TAmarillas = partido.EquipoLocal.TAmarillas - partido.TALocal;
                                    partido.EquipoLocal.TRojas = partido.EquipoLocal.TRojas - partido.TRLocal;
                                    partido.EquipoLocal.Vctorias = partido.EquipoLocal.Derrotas - 1;

                                    CLUBESTAdapter.Update(myEquipo.Nombre, partido.EquipoLocal.GolesF, partido.EquipoLocal.GolesC, myEquipo.NJugadores, myEquipo.Vctorias, partido.EquipoLocal.Derrotas, myEquipo.Empates
                                        , partido.EquipoLocal.TAmarillas, partido.EquipoLocal.TRojas, myEquipo.ID_ligas, myEquipo.ID_CLUB, myEquipo.Nombre, myEquipo.GolesF, myEquipo.GolesC, myEquipo.NJugadores
                                        , myEquipo.Vctorias, myEquipo.Derrotas, myEquipo.Empates, myEquipo.TAmarillas, myEquipo.TRojas, myEquipo.ID_ligas);
                                }
                            }
                            foreach (DataRow row1 in EQUIPOS.Rows)
                            {
                                if ((int)row1["Id_Club"] == partido.EquipoVisitante.ID_CLUB)
                                {
                                    EquipoModel myEquipo = new EquipoModel();
                                    myEquipo.ID_CLUB = (int)row1["Id_Club"];
                                    myEquipo.Nombre = row1["NombreClub"].ToString();
                                    myEquipo.ID_ligas = (int)row1["Id_Liga1"];
                                    partido.EquipoVisitante.GolesF = partido.EquipoVisitante.GolesF - partido.GVisitante;
                                    partido.EquipoVisitante.GolesC = partido.EquipoVisitante.GolesC - partido.GLocal;
                                    partido.EquipoVisitante.TAmarillas = partido.EquipoVisitante.TAmarillas - partido.TAVisitante;
                                    partido.EquipoVisitante.TRojas = partido.EquipoVisitante.TRojas - partido.TRVisitante;
                                    partido.EquipoVisitante.Vctorias = partido.EquipoVisitante.Vctorias - 1;

                                    CLUBESTAdapter.Update(myEquipo.Nombre, partido.EquipoVisitante.GolesF, partido.EquipoVisitante.GolesC, myEquipo.NJugadores, partido.EquipoVisitante.Vctorias, myEquipo.Derrotas, myEquipo.Empates
                                        , partido.EquipoVisitante.TAmarillas, partido.EquipoVisitante.TRojas, myEquipo.ID_ligas, myEquipo.ID_CLUB, myEquipo.Nombre, myEquipo.GolesF, myEquipo.GolesC, myEquipo.NJugadores
                                        , myEquipo.Vctorias, myEquipo.Derrotas, myEquipo.Empates, myEquipo.TAmarillas, myEquipo.TRojas, myEquipo.ID_ligas);
                                }
                            }
                        }
                        return true;
                    }
                }
                return false;
            }
            catch { return false; }
        }
        //METODO PARA BORRAR EQUIPO
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
        //METODO PARA BORRAR JUGADOR, ACTUALIZANDO EL CLUB AFECTADO
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
        //METODO PARA EDITAR LIGA 
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
        //METODO PARA EDITAR EQUIPO CON VALIDACIONES
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
        //METODO PARA EDITAR JUGADOR CON VALIDACIONES Y ACTUALIZANDO LOS CLUBES AFECTADOS
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

