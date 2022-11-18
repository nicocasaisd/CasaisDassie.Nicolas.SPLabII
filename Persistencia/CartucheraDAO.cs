using Biblioteca;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Net;

namespace Persistencia
{
    public static class CartucheraDAO
    {
        public static string cadenaConexion;
        public static SqlCommand comando;
        public static SqlConnection conexion;

        static CartucheraDAO()
        {
            // Constructor estático
            cadenaConexion = "Server=.;Database=CARTUCHERA_DB;Trusted_Connection=True;";
            conexion = new SqlConnection(cadenaConexion);
            comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.Connection = conexion;
        }

        public static Cartuchera<Util> Leer()
        {
            Cartuchera<Util> cartuchera = new Cartuchera<Util>();
            SqlDataReader lector;

            try
            {
                conexion.Open();
                comando.CommandText = "SELECT * FROM CARTUCHERAS";
                lector = comando.ExecuteReader();

                while(lector.Read())
                {
                    int id = (int) lector["ID_CARTUCHERA"];
                    int capacidad = (int)lector["CAPACIDAD"];

                    cartuchera = new Cartuchera<Util>(id, capacidad);
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if(conexion.State == System.Data.ConnectionState.Open)
                {
                    conexion.Close();
                }
            }

            return cartuchera;
        }

        public static List<Lapiz> LeerLapices(int id_cartuchera)
        {
            List<Lapiz> listaLapices = new List<Lapiz>();
            SqlDataReader lector;

            comando.CommandText = $"SELECT * FROM LAPICES WHERE ID_CARTUCHERA={id_cartuchera};";
            lector = comando.ExecuteReader();

            while(lector.Read())
            {
                int id = (int) lector["ID"];
                string marca = lector["MARCA"].ToString();
                decimal precio = (decimal) lector["PRECIO"];
                ColorLapiz color = (ColorLapiz)lector["COLOR"];
                bool esMecanico = (bool)lector["ES_MECANICO"];

                Lapiz lapiz = new Lapiz(id, marca, precio, color, esMecanico);
                listaLapices.Add(lapiz);
            }


            return listaLapices;
        }



    }
}
