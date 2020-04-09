using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;

namespace CBD_PROYECTO
{
    class Serie
    { 
         public ObjectId _id { get; set; }
         public string titulo { get; set; }

        public string descripcion { get; set; }

        public double valoracion { get; set; }

        public DateTime fechaLanzamiento { get; set; }

        public int temporada { get; set; }

        public Actor[] actores { get; set; }



        public Serie() { }
        public Serie(string tit, String des, double val, Actor[] actores, string creador, DateTime fechaLanzamiento, int temp )
        {
            this.titulo = tit;
            this.descripcion = des;
            this.valoracion = val;
            this.fechaLanzamiento = fechaLanzamiento;
            this.temporada = temp;
        }
    }
}
