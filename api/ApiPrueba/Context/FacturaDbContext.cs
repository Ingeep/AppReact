using ApiPrueba.DataModel;
using Microsoft.EntityFrameworkCore;

namespace ApiPrueba.Context
{
    public class FacturaDbContext : DbContext
    {
        public FacturaDbContext(DbContextOptions<FacturaDbContext> options) : base(options) 
        {

        }

      public DbSet<Factura> Factura { get; set; }
    }
}
