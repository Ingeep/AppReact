using ApiPrueba.DataModel;
using Microsoft.EntityFrameworkCore;

namespace ApiPrueba.Context
{
    public class ClienteDbContext : DbContext
    {
        public ClienteDbContext(DbContextOptions<ClienteDbContext> options) : base(options)
        {

        }

        public DbSet<Cliente> Cliente { get; set; }
    }
}
