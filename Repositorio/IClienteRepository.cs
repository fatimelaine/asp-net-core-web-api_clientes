using ApiClientes.Models;
using System.Collections.Generic;

namespace ApiClientes.Repositorio
{
    public interface IClienteRepository
    {
        void Add(Cliente client);
        IEnumerable<Cliente> GetAll();
        Cliente Find(int id);
        void Remove(int id);
        void Update(Cliente client);
    }
}