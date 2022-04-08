using ApiPrueba.DataModel;
using Microsoft.EntityFrameworkCore;

namespace ApiPrueba.Context
{
    public class ServicioDbContextcs : DbContext
    {
        public ServicioDbContextcs(DbContextOptions<ServicioDbContextcs> options) : base(options)   
        {

        }

        public DbSet<Servicio> Servicio { get; set; }
    }

}
