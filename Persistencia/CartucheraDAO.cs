using Biblioteca;
using System;
using System.Data.SqlClient;

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

            return cartuchera;
        }




    }
}
