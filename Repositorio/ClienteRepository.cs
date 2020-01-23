using ApiClientes.Models;
using System.Collections.Generic;
using System.Linq;

namespace ApiClientes.Repositorio
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ClienteDBContext _contexto;

        public ClienteRepository(ClienteDBContext ctx)
        {
            _contexto = ctx;
        }

        public void Add(Cliente client)
        {
            _contexto.Clientes.Add(client);
            _contexto.SaveChanges();
        }

        public Cliente Find(int id)
        {
            return _contexto.Clientes.FirstOrDefault(c => c.ClienteId == id);
        }

        public IEnumerable<Cliente> GetAll()
        {
            return _contexto.Clientes.OrderBy(c => c.Nome).ToList();
        }

        public void Remove(int id)
        {
            var obj = _contexto.Clientes.First(c => c.ClienteId == id);
            _contexto.Clientes.Remove(obj);
            _contexto.SaveChanges();
        }

        public void Update(Cliente cliente)
        {
            _contexto.Clientes.Update(cliente);
            _contexto.SaveChanges();
        }
    }
}
