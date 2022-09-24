using Microsoft.EntityFrameworkCore;
using WebApiAcmeEncuestasV1.Models;

namespace WebApiAcmeEncuestasV1
{
    public class AplicationDbContext : DbContext
    {
        public DbSet<Encuesta> Encuesta { get; set; }
        public DbSet<CamposEncuesta> Campos { get; set; }
        public DbSet<LlenarEncuesta> Llenarencuesta { get; set; }
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options)
        {

        }
    }
}
