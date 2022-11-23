using Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Biblioteca
{
    public enum EColorLapiz
    {
        Rojo = 0, Verde = 1, Azul = 2, Blanco=3, Negro =4, Gris=5
    }
    public class Lapiz : Util, ISerializa, IDeserializa
    {
        private EColorLapiz color;
        private bool esMecanico;

        public Lapiz() :base()
        {}
        public Lapiz(int id, string marca, decimal precio, EColorLapiz color, bool esMecanico) : base(id,marca,precio)
        {
            this.color = color;
            this.esMecanico = esMecanico;
            // defino tipo
            this.tipo = ETipoDeUtil.Lapiz;
        }


        public EColorLapiz Color
        {
            get { return color; }
            set { color = value; }
        }

        public bool EsMecanico
        {
            get { return esMecanico; }
            set { esMecanico = value; }
        }

        public override string ToString()
        {
            return $"{this.Id}, {this.Marca}, {this.Precio}, {this.Color}, {this.EsMecanico}";
        }

        void ISerializa.Json()
        {
            string archivo = $"lapiz_{this.Id}_{this.Marca}.json";
            string ruta = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string rutaCompleta = Path.Combine(ruta, archivo);

            
            
            string jsonString = JsonSerializer.Serialize(this);
            File.WriteAllText(rutaCompleta, jsonString);    
            
        }

        object IDeserializa.Json()
        {
            string archivo = $"lapiz.json";
            string ruta = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string rutaCompleta = Path.Combine(ruta, archivo);



            string jsonString = File.ReadAllText(rutaCompleta);
            Lapiz lapiz = JsonSerializer.Deserialize<Lapiz>(jsonString);

            return lapiz;
        }

        object IDeserializa.Json(string path)
        {
            string archivo = $"lapiz.json";
            string ruta = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string rutaCompleta = Path.Combine(ruta, archivo);



            string jsonString = File.ReadAllText(rutaCompleta);
            Lapiz lapiz = JsonSerializer.Deserialize<Lapiz>(jsonString);

            return lapiz;
        }

        void ISerializa.Xml()
        {
            string archivo = $"lapiz_{this.Id}_{this.Marca}.xml";
            string ruta = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string rutaCompleta = Path.Combine(ruta, archivo);

            using (StreamWriter writer = new StreamWriter(rutaCompleta))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Lapiz));
                xmlSerializer.Serialize(writer, this);
            }
        }

        //object IDeserializa.Xml()
        //{
        //    string archivo = "lapiz.xml";
        //    string ruta = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        //    string rutaCompleta = Path.Combine(ruta, archivo);

        //    using( StreamReader reader = new StreamReader(rutaCompleta))
        //    {
        //        XmlSerializer xmlSerializer = new XmlSerializer(typeof(Lapiz));
        //        Lapiz lapiz = xmlSerializer.Deserialize(reader) as Lapiz;
        //        return lapiz;
        //    }
        //}

        object IDeserializa.Xml()
        {
            string archivo = "lapiz.xml";
            string ruta = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string rutaCompleta = Path.Combine(ruta, archivo);

            using (StreamReader reader = new StreamReader(rutaCompleta))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Lapiz));
                Lapiz lapiz = xmlSerializer.Deserialize(reader) as Lapiz;
                return lapiz;
            }
        }

        object IDeserializa.Xml(string path)
        {
            using (StreamReader reader = new StreamReader(path))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Lapiz));
                Lapiz lapiz = xmlSerializer.Deserialize(reader) as Lapiz;
                return lapiz;
            }
        }
    }
}
