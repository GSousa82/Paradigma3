using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paradigma3.Domain.Entities
{
    public class Client
    {
        /// <summary>
        /// Id created by MongoDb
        /// </summary>
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        /// <summary>
        /// 1) Name of the client
        /// </summary>
        [BsonElement("Name")]
        public string Nome { get; set; }

        /// <summary>
        /// 2) Id number 
        /// </summary>]
        [BsonElement("CPF")]
        public string CPF { get; set; }
    }
}
