﻿using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;

namespace CBD_PROYECTO
{
    public class Actor
    {
        public ObjectId _id { get; set; }

        public string nombre { get; set; }

        public string apellidos { get; set; }

        public string lugarNacimiento { get; set; }

        public int edad { get; set; }

        public double valoracion { get; set; }





        public Actor()
        {

        }

        public Actor(string nombre, string apellidos, string lugarNaciemiento, int edad, double valoracion)
        {
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.lugarNacimiento = lugarNacimiento;
            this.edad = edad;
            this.valoracion = valoracion;
        }
    }
}