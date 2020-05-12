using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CBD_PROYECTO
{
    class Serie
    {
        [BsonId]
        public ObjectId _id { get; set; }

        [BsonElement("Titulo")]
        public string titulo { get; set; }

        [BsonElement("Descripcion")]
        public string descripcion { get; set; }

        [BsonElement("Valoracion")]
        public double valoracion { get; set; }
        
        [BsonElement("Lanzamiento")]
        public String fechaLanzamiento { get; set; }

        public int temporada { get; set; }

        public Actor[] actores { get; set; }



        public Serie() { 
        
        }
        public Serie(string tit, String des, double val, Actor[] actores, string creador, String fechaLanzamiento, int temp )
        {
            this.titulo = tit;
            this.descripcion = des;
            this.valoracion = val;
            this.fechaLanzamiento = fechaLanzamiento;
            this.temporada = temp;
        }


       
    }
}
