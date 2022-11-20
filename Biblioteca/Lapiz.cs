﻿using Interfaces;
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
        Rojo = 1, Verde = 2, Azul = 3, Blanco=4, Negro =5, Gris=6
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
            string archivo = "lapiz.json";
            string ruta = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string rutaCompleta = Path.Combine(ruta, archivo);

            
            
            string jsonString = JsonSerializer.Serialize(this);
            File.WriteAllText(rutaCompleta, jsonString);    
            
        }

        object IDeserializa.Json()
        {
            string archivo = "lapiz.json";
            string ruta = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string rutaCompleta = Path.Combine(ruta, archivo);



            string jsonString = File.ReadAllText(rutaCompleta);
            Lapiz lapiz = JsonSerializer.Deserialize<Lapiz>(jsonString);

            return lapiz;
        }

        void ISerializa.Xml()
        {
            string archivo = "lapiz.xml";
            string ruta = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string rutaCompleta = Path.Combine(ruta, archivo);

            using (StreamWriter writer = new StreamWriter(rutaCompleta))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Lapiz));
                xmlSerializer.Serialize(writer, this);
            }
        }

        object IDeserializa.Xml()
        {
            string archivo = "lapiz.xml";
            string ruta = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string rutaCompleta = Path.Combine(ruta, archivo);

            using( StreamReader reader = new StreamReader(rutaCompleta))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Lapiz));
                Lapiz lapiz = xmlSerializer.Deserialize(reader) as Lapiz;
                return lapiz;
            }
        }
    }
}
