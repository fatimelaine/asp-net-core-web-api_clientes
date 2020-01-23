using Microsoft.EntityFrameworkCore;

namespace ApiClientes.Models
{
    public class ClienteDBContext : DbContext
    {
        public ClienteDBContext(DbContextOptions<ClienteDBContext> options) : base (options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
    }
}
