﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public enum ColorLapiz
    {
        Rojo = 1, Verde = 2, Azul = 3, Blanco=4, Negro =5, Gris=6
    }
    public class Lapiz : Util
    {
        private ColorLapiz color;
        private bool esMecanico;

        public Lapiz(int id, string nombre, decimal precio, ColorLapiz color, bool esMecanico) : base(id,nombre,precio)
        {
            this.color = color;
            this.esMecanico = esMecanico;
            // defino tipo
            this.tipo = ETipoDeUtil.Lapiz;
        }


        public ColorLapiz Color
        {
            get { return color; }
        }

        public bool EsMecanico
        {
            get { return esMecanico; }
        }

    }
}
