using MongoDB.Driver;
using Paradigma3.Infra.Data;
using Paradigma3.Domain.Entities;
using System.Linq;
using System;
using Xunit;
using Paradigma3.Api.Controllers;
using Paradigma3.Domain.Interface.Application;
using Paradigma3.Application.Services;

namespace Paradigma3.Test
{
    public class CrudTest
    {
        private ClientApplication client = new ClientApplication();       

        [Fact]
        public void TestGetAll()
        {      
            Assert.NotNull(client.GetAll());
        }

        [Fact]
        public void TestInsert()
        {
            Client newClient = new Client();

            newClient.CPF = "303692581477";
            newClient.Nome = "Teste";

            Assert.True(client.Insert(newClient));
        }

        [Fact]
        public void TestGetOne()
        {           
            var lista = client.GetAll();

            var oneClient = lista.First(c => c.Nome == "Teste");

            var result = client.GetClient(oneClient.Id);

            Assert.NotNull(result);
        }

        

        [Fact]
        public void TestUpdate()
        {
            Client newClient = new Client();

            var lista = client.GetAll();

            var oneClient = lista.First(c => c.Nome == "Teste");

            newClient.CPF = "11122233344";
            newClient.Nome = "Teste";

            Assert.True(client.UpdateClient(newClient, oneClient.Id));

        }

        [Fact]
        public void TestDelete()
        {
            var lista = client.GetAll();

            var oneClient = lista.First(c => c.Nome == "Teste");

            Assert.True(client.DeleteClient(oneClient.Id));
        }
    }
}
