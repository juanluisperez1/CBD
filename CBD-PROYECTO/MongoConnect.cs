using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Linq;

namespace CBD_PROYECTO
{
    partial class Program
    {
        public class MongoConnect
        {
            private IMongoDatabase db;

            public MongoConnect(String database)
            {
                var cliente = new MongoClient();
                db = cliente.GetDatabase(database);


            }

            public void insertarElemento<T>(String coleccion, T elemento)
            {
                var collection = db.GetCollection<T>(coleccion);
                collection.InsertOne(elemento);
            }

            public List<T> listadoBD<T>(String coleccion)
            {
                var collection = db.GetCollection<T>(coleccion);
                var data = new BsonDocument();
                return collection.Find(data).ToList();
            }
            public List<Serie> listadoBestBD<T>(String coleccion)
            {
                var collection = db.GetCollection<Serie>(coleccion);
                var data = new BsonDocument();
               List<Serie> series = collection.Find(data).ToList();

                var filteredCollection =
                series.Where(item => item.valoracion >= 4.0).ToList();

                return filteredCollection.ToList();
            }
            public T filterByName<T>(String coleccion,String s)
            {
                var collection = db.GetCollection<T>(coleccion);
                var filter = Builders<T>.Filter.Eq("titulo", s);
                return collection.Find(filter).FirstOrDefault();
            }
            


            public T mostrarElementoPorId<T>(String coleccion, ObjectId id)
            {
                var collection = db.GetCollection<T>(coleccion);
                var filter = Builders<T>.Filter.Eq("_id", id);
                return collection.Find(filter).First();
            }


            public void editarElemento<T>(String coleccion, T elemento, ObjectId id)
            {
                var collection = db.GetCollection<T>(coleccion);
                var data = new BsonDocument("_id", id);
                collection.ReplaceOne(data, elemento, new ReplaceOptions { IsUpsert = true });
            }



            public void eliminarElemento<T>(String coleccion, ObjectId id)
            {
                var collection = db.GetCollection<T>(coleccion);
                var filter = Builders<T>.Filter.Eq("_id", id);
                collection.DeleteOne(filter);
            }







        }
    }
}
