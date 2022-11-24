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
            DateTime dt = DateTime.Now;
            string dateString = $"{dt.Hour:#2}{dt.Minute:#2}{dt.Second:#2}";
            string archivo = $"cartuchera{cartuchera.Id_Cartuchera}_{dateString}_backup.json";
            string ruta = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string rutaCompleta = Path.Combine(ruta, archivo);



            string jsonString = JsonSerializer.Serialize(cartuchera);
            File.WriteAllText(rutaCompleta, jsonString);
        }




    }
}
