using Paradigma3.Domain.Entities;
using Paradigma3.Domain.Interface.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Paradigma3.Domain.Interface.Application
{
    public interface IClientApplication : IDao<Client>
    {
        Client GetClient(string clientId);

        bool UpdateClient(Client client, string clientId);

        bool DeleteClient(string clientId);
    }
}
