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
            string carpeta = "_backup";
            string ruta = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            
            // si la carpeta no existe, la crea
            if(!Directory.Exists(Path.Combine(ruta,carpeta)))
            {
                Directory.CreateDirectory(Path.Combine(ruta,carpeta));
            }

            string jsonString = JsonSerializer.Serialize(cartuchera);
            string rutaCompleta = Path.Combine(ruta, carpeta, archivo);
            File.WriteAllText(rutaCompleta, jsonString);
        }




    }
}
