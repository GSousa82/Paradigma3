using MongoDB.Bson;
using MongoDB.Driver;
using Paradigma3.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paradigma3.Infra.Data
{
    public sealed class ClientDAO : DAO<Client>
    {
        private static ClientDAO _instace;

        public static ClientDAO Instance
        {
            get
            {
                if (_instace == null) _instace = new ClientDAO();
                return _instace;
            }
        }

        public IMongoCollection<Client> GetClientCollectionDAO()
        {
            IMongoCollection<Client> booksCollection = MongoRepository.GetConnect.GetCollection<Client>("clients");

            return booksCollection;
        }

        public void InsertClientDAO(IMongoCollection<Client> clientCollection, Client infoClient)
        {
            clientCollection.InsertOne(infoClient);
        }

        public Client GetClient(string clientId)
        {
            try
            {
                var clientsCollection = GetClientCollectionDAO();

                var filter = Builders<Client>.Filter.Where(c => c.Id == clientId);

                var client = clientsCollection.Find<Client>(filter).First();

                return client;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Client> ListClientDAO(IMongoCollection<Client> clientsCollection)
        {
            try
            {
                var filter = Builders<Client>.Filter.Empty;

                var books = clientsCollection.Find<Client>(filter).ToList();

                return books;
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }

        public void UpdateClientDAO(IMongoCollection<Client> clientsCollection, Client infoClient, string id)
        {
            // Filtro para Buscar apenas o Cliente que está sendo atualizado
            var filter = Builders<Client>.Filter.Eq(b => b.Id, id);

            // Populando Atualização 
            var clientUpdate = Builders<Client>.Update
                .Set(b => b.Nome, infoClient.Nome)
                .Set(b => b.CPF, infoClient.CPF);

            // Efetivar Atualização do Livro
            clientsCollection.UpdateOne(filter, clientUpdate);

        }

        public void DeleteClientDAO(IMongoCollection<Client> clientsCollection, string id)
        {
            // Filtro para excluir apenas o Cliente que contém o id passando em parâmetro
            var filter = Builders<Client>.Filter.Where(b => b.Id == id);

            clientsCollection.DeleteOne(filter);
        }
    }
}