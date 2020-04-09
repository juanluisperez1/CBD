using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
namespace CBD_PROYECTO
{
    class Temporada
    {
        public ObjectId _id { get; set; }
        public string titulo { get; set; }

        public double valoracion { get; set; }

        public Episodios[] episodios { get; set; }

        public DateTime fechaLanzamiento { get; set; }





        public Temporada() { }
        public Temporada(string tit, double val, Episodios[] episodios, DateTime fechaLanzamiento)
        {
            this.titulo = tit;
            this.valoracion = val;
            this.episodios = episodios;
            this.fechaLanzamiento = fechaLanzamiento;
        }
    }
}
