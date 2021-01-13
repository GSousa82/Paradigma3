
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using MongoDB.Driver.Core;
using MongoDB.Driver.Core.Clusters;
using Paradigma3.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Paradigma3.Infra.Data
{
    public class MongoRepository
    {
        private static volatile MongoRepository instance;
        private static object syncLock = new Object();
        private static IMongoDatabase db = null;

        public MongoRepository()
        {

            try
            {
                // Conection to the server
                //var connection = AppSettings.Instance.GetSection("ClientsDatabaseSettings").GetChildren().First(c => c.Key == "MongoDBConnectString").Value;
                //var database = AppSettings.Instance.GetSection("ClientsDatabaseSettings").GetChildren().First(c => c.Key == "DatabaseName").Value;

                //var client = new MongoClient(connection);
                var client = new MongoClient("mongodb+srv://Admin:h8EQsNBHzbiAo2jV@cluster0.mq3gv.mongodb.net/crudmongodb?retryWrites=true&w=majority");

                var databases = client.ListDatabases();
                databases.MoveNext();

                if (client.Cluster.Description.State == ClusterState.Connected)
                {
                    // Database is connected.

                    //db = client.GetDatabase(database);
                    db = client.GetDatabase("crudmongodb");
                    
                }
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static IMongoDatabase GetConnect
        {
            get
            {
                if (instance == null)
                {
                    lock (syncLock)
                    {
                        if (instance == null)
                        {
                            instance = new MongoRepository();
                        }
                    }
                }

                return db;
            }
        }
    }
}
