using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;

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

            public void insertarElemento<T>(String colecion, T elemento)
            {
                var collection = db.GetCollection<T>(colecion);
                collection.InsertOne(elemento);
            }

            public List<T> listadoBD<T>(String colecion)
            {
                var collection = db.GetCollection<T>(colecion);
                var data = new BsonDocument();
                return collection.Find(data).ToList();
            }


            public void UpgradeElemento<T>(String colecion, T persona, Guid id)
            {
                var collection = db.GetCollection<T>(colecion);
                var data = new BsonDocument("_id", id);
                collection.ReplaceOne(data, persona, new ReplaceOptions { IsUpsert = true });
            }



            public void DeleteElemento<T>(String colecion, Guid id)
            {
                var collection = db.GetCollection<T>(colecion);
                var filter = Builders<T>.Filter.Eq("Id", id);
                collection.DeleteOne(filter);
            }







        }
    }
}
