using MongoDB.Driver;
using Paradigma3.Domain.Interface.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paradigma3.Infra.Data
{
    public abstract class DAO<T> : IDao<T>
    {
        public IMongoCollection<T> GetCollectionDAO()
        {
            IMongoCollection<T> clientsCollection = MongoRepository.GetConnect.GetCollection<T>("clients");

            return clientsCollection;
        }

        public IEnumerable<T> GetAll()
        {
            try
            {
                var filter = Builders<T>.Filter.Empty;

                var collection = GetCollectionDAO().Find<T>(filter).ToList();

                return collection;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //public void Delete(string id)
        //{
        //    var filter = Builders<T>.Filter.Exists(id);

        //    var collection = GetCollectionDAO();

        //    collection.DeleteOne(filter);
        //}


        //public T GetOne(string id)
        //{
        //    try
        //    {
        //        var collection = GetCollectionDAO();

        //        var filter = Builders<T>.Filter.Where(c => c.Id == id);

        //        var client = collection.Find<T>(filter).First();

        //        return client;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public bool Insert( T info)
        {
            var collection = GetCollectionDAO();

            collection.InsertOne(info);

            return true;
        }

        //public void Update(T info, string id)
        //{
        //    // Filtro para Buscar apenas o Cliente que está sendo atualizado
        //    var filter = Builders<T>.Filter.Exists(c => c. == id);

        //    var collection = GetCollectionDAO();

        //    // Populando Atualização 
        //    var update = Builders<T>.Update.
        //        .Set(b => b.Nome, info.Nome)
        //        .Set(b => b.CPF, info.CPF);

        //    // Efetivar Atualização do Livro
        //    collection.UpdateOne(filter, update);

        //}
    }
}
