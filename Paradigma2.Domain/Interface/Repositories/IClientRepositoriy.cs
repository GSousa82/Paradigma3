using Paradigma2.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paradigma2.Domain.Interface.Repositories
{
    public interface IClientRepository
    {
        List<Client> GetClients();

        Client GetClient(string name);

        bool InsertClient(Client client);

        bool UpdateClient(Client client);

        bool DeleteClient(Client client);
    }
}
