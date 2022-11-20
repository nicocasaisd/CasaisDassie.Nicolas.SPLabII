using Biblioteca;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    public static class UtilesDAO
    {
        private static string cadenaConexion;
        private static SqlCommand comando;
        private static SqlConnection conexion;

        static UtilesDAO()
        {
            // Constructor estático
            cadenaConexion = "Server=.;Database=CARTUCHERA_DB;Trusted_Connection=True;";
            conexion = new SqlConnection(cadenaConexion);
            comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.Connection = conexion;
        }

        public static List<Lapiz> LeerLapices(int id_cartuchera)
        {
            List<Lapiz> listaLapices = new List<Lapiz>();
            SqlDataReader lector;

            try
            {
                conexion.Open();
                comando.CommandText = $"SELECT * FROM LAPICES WHERE ID_CARTUCHERA={id_cartuchera};";
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    int id = (int)lector["ID"];
                    string marca = lector["MARCA"].ToString();
                    decimal precio = (decimal)lector["PRECIO"];
                    EColorLapiz color = (EColorLapiz)lector["COLOR"];
                    bool esMecanico = (bool)lector["ES_MECANICO"];

                    Lapiz lapiz = new Lapiz(id, marca, precio, color, esMecanico);
                    listaLapices.Add(lapiz);
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

            return listaLapices;
        }

        public static List<Goma> LeerGomas(int id_cartuchera)
        {
            List<Goma> listaGomas = new List<Goma>();
            SqlDataReader lector;

            try
            {
                conexion.Open();
                comando.CommandText = $"SELECT * FROM GOMAS WHERE ID_CARTUCHERA={id_cartuchera};";
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    int id = (int)lector["ID"];
                    string marca = lector["MARCA"].ToString();
                    decimal precio = (decimal)lector["PRECIO"];
                    bool esBorraTinta = (bool)lector["ES_BORRATINTA"];

                    Goma goma = new Goma(id, marca, precio, esBorraTinta);
                    listaGomas.Add(goma);
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

            return listaGomas;
        }

        public static List<Sacapunta> LeerSacapuntas(int id_cartuchera)
        {
            List<Sacapunta> listaSacapuntas = new List<Sacapunta>();
            SqlDataReader lector;

            try
            {
                conexion.Open();
                comando.CommandText = $"SELECT * FROM SACAPUNTAS WHERE ID_CARTUCHERA={id_cartuchera};";
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    int id = (int)lector["ID"];
                    string marca = lector["MARCA"].ToString();
                    decimal precio = (decimal)lector["PRECIO"];
                    EMaterialSacapunta material = (EMaterialSacapunta)lector["MATERIAL"];

                    Sacapunta sacapunta = new Sacapunta(id, marca, precio, material);
                    listaSacapuntas.Add(sacapunta);
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

            return listaSacapuntas;
        }

        public static void GuardarUtil(int id_cartuchera, Util util)
        {

            try
            {
                conexion.Open();
                if(util is Lapiz)
                {
                    Lapiz lapiz = (Lapiz)util;
                    comando.CommandText = $"INSERT INTO LAPICES\r\nVALUES({id_cartuchera},@marca,@precio,@colorInt,@esMecanico);";
                    comando.Parameters.AddWithValue("@marca", lapiz.Marca);
                    comando.Parameters.AddWithValue("@precio", lapiz.Precio);
                    comando.Parameters.AddWithValue("@colorInt", (int)lapiz.Color);
                    comando.Parameters.AddWithValue("@esMecanico", lapiz.EsMecanico);
                }
                else if(util is Goma)
                {
                    Goma goma = (Goma)util;
                    comando.CommandText = $"INSERT INTO GOMAS\r\nVALUES({id_cartuchera},@marca,@precio,@esBorraTinta);";
                    comando.Parameters.AddWithValue("@marca", goma.Marca);
                    comando.Parameters.AddWithValue("@precio", goma.Precio);
                    comando.Parameters.AddWithValue("@esBorraTinta", goma.EsBorraTinta);
                }
                else if(util is Sacapunta)
                {
                    Sacapunta sacapunta = (Sacapunta)util;
                    comando.CommandText = $"INSERT INTO SACAPUNTAS\r\nVALUES({id_cartuchera},@marca,@precio,@material);";
                    comando.Parameters.AddWithValue("@marca", sacapunta.Marca);
                    comando.Parameters.AddWithValue("@precio", sacapunta.Precio);
                    comando.Parameters.AddWithValue("@material", sacapunta.Material);
                }
                

                comando.ExecuteNonQuery();
                comando.Parameters.Clear();

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

        }

        public static void ModificarUtil(Util util)
        {

            try
            {
                conexion.Open();
                if (util is Lapiz)
                {
                    Lapiz lapiz = (Lapiz)util;
                    comando.CommandText = $"UPDATE LAPICES\r\nSET MARCA='@marca', PRECIO=@precio, COLOR=@colorInt, ES_MECANICO=@esMecanico \r\nWHERE ID={util.Id};";
                    comando.Parameters.AddWithValue("@marca", lapiz.Marca);
                    comando.Parameters.AddWithValue("@precio", lapiz.Precio);
                    comando.Parameters.AddWithValue("@colorInt", (int)lapiz.Color);
                    comando.Parameters.AddWithValue("@esMecanico", lapiz.EsMecanico);
                }
                else if (util is Goma)
                {
                    Goma goma = (Goma)util;
                    comando.CommandText = $"UPDATE GOMAS\r\nSET MARCA='@marca', PRECIO=@precio, ES_BORRATINTA=@esBorraTinta \r\nWHERE ID={util.Id};";
                    comando.Parameters.AddWithValue("@marca", goma.Marca);
                    comando.Parameters.AddWithValue("@precio", goma.Precio);
                    comando.Parameters.AddWithValue("@esBorraTinta", goma.EsBorraTinta);
                }
                else if (util is Sacapunta)
                {
                    Sacapunta sacapunta = (Sacapunta)util;
                    comando.CommandText = $"UPDATE SACAPUNTAS\r\nSET MARCA='@marca', PRECIO=@precio, MATERIAL=@material \r\nWHERE ID={util.Id};";
                    comando.Parameters.AddWithValue("@marca", sacapunta.Marca);
                    comando.Parameters.AddWithValue("@precio", sacapunta.Precio);
                    comando.Parameters.AddWithValue("@material", sacapunta.Material);
                }


                comando.ExecuteNonQuery();
                comando.Parameters.Clear();

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

        }



    }
}
