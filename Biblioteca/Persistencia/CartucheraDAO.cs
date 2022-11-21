using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Persistencia
{
    public static class CartucheraDAO
    {
        private static string cadenaConexion;
        private static SqlCommand comando;
        private static SqlConnection conexion;

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

                while (lector.Read())
                {
                    int id = (int)lector["ID_CARTUCHERA"];
                    int capacidad = (int)lector["CAPACIDAD"];

                    cartuchera = new Cartuchera<Util>(id, capacidad);
                    CargarLapicesEnCartuchera(cartuchera);
                    CargarGomasEnCartuchera(cartuchera);
                    CargarSacapuntasEnCartuchera(cartuchera);
                }

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (conexion.State == System.Data.ConnectionState.Open)
                {
                    conexion.Close();
                }
            }

            return cartuchera;
        }



        private static void CargarLapicesEnCartuchera(Cartuchera<Util> cartuchera)
        {
            foreach (Util item in UtilesDAO.LeerLapices(cartuchera.Id_Cartuchera))
            {
                cartuchera.ListaElementos.Add(item);
            }
        }

        private static void CargarGomasEnCartuchera(Cartuchera<Util> cartuchera)
        {
            foreach (Util item in UtilesDAO.LeerGomas(cartuchera.Id_Cartuchera))
            {
                cartuchera.ListaElementos.Add(item);
            }
            
        }

        private static void CargarSacapuntasEnCartuchera(Cartuchera<Util> cartuchera)
        {
            foreach (Util item in UtilesDAO.LeerSacapuntas(cartuchera.Id_Cartuchera))
            {
                cartuchera.ListaElementos.Add(item);
            }
        }


    }
}
