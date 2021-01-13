using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paradigma3.Domain.Interface.Repositories
{
    public interface IDao<T>
    {
        IEnumerable<T> GetAll();

        bool Insert(T info);
    }
}
