using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Biblioteca.Persistencia
{
    public class BackupManager
    {
        public static void RealizarBackup(Cartuchera<Util> cartuchera)
        {
            string archivo = $"cartuchera{cartuchera.Id_Cartuchera}_{DateTime.Now.ToString("HHmmss")}_backup.json";
            string carpeta = "backup";
            string ruta = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string rutaCompleta = Path.Combine(ruta,carpeta, archivo);



            string jsonString = JsonSerializer.Serialize(cartuchera);
            File.WriteAllText(rutaCompleta, jsonString);
        }




    }
}
