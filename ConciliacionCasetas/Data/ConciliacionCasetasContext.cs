using Domain;
using Domain.Catalogos;
using Domain.Trafico;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public partial class ConciliacionCasetasContext : DbContext
    {
        public ConciliacionCasetasContext()
        {

        }

        public ConciliacionCasetasContext(DbContextOptions<ConciliacionCasetasContext> options)
            : base(options)
        {
        }

        public DbSet<Caseta> Caseta { get; set; }
        public DbSet<CampoTicketCaseta> CampoTicketCaseta { get; set; }
        public DbSet<Carril> Carril { get; set; }
        public DbSet<ListaGenericaTipo> ListaGenericaTipo { set; get; }
        public DbSet<Peaje> Peaje { set; get; }
        public DbSet<HistoricoPeaje> HistoricoPeaje { set; get; }
        public DbSet<Geocerca> Geocerca { get; set; }
        public DbSet<ListaGenerica> ListaGenerica { get; set; }

        public DbSet<ConciliacionCaseta> ConciliacionCaseta { get; set; }
        public DbSet<ConciliacionCasetaArchivo> ConciliacionCasetaArchivo { get; set; }
        public DbSet<ConciliacionCasetaArchivoEvento> ConciliacionCasetaArchivoEvento { get; set; }
        public DbSet<Empresa> Empresa { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            OnModelCreatingPartial(modelBuilder);

            modelBuilder.Entity<Geocerca>().Property(t => t.PoligonoComputado).HasComputedColumnSql("[Poligono].ToString()");
            modelBuilder.Entity<Geocerca>().Property(t => t.PuntoComputado).HasComputedColumnSql("[Punto].ToString()");
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
