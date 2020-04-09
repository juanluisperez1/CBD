using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;

namespace CBD_PROYECTO
{
    class Episodios
    {
        public ObjectId _id { get; set; }
        public string titulo { get; set; }

        public string descripcion { get; set; }

        public double valoracion { get; set; }

        public DateTime fechaLanzamiento { get; set; }


        public Episodios() { }
        public Episodios(string tit, String des, double val, DateTime fechaLanzamiento)
        {
            this.titulo = tit;
            this.descripcion = des;
            this.valoracion = val;
            this.fechaLanzamiento = fechaLanzamiento;
        }
    
}
}
