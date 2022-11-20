using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Biblioteca
{
    public enum EColorLapiz
    {
        Rojo = 1, Verde = 2, Azul = 3, Blanco=4, Negro =5, Gris=6
    }
    public class Lapiz : Util, ISerializa
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

        bool ISerializa.Json(object obj)
        {
            throw new NotImplementedException();
        }

        bool ISerializa.Xml(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
