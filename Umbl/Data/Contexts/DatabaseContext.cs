using Microsoft.EntityFrameworkCore;
using Umbl.Models;

namespace Umbl.Data.Contexts
{
    using Microsoft.EntityFrameworkCore;

    namespace Umbl.Data.Contexts
    {
        public class DatabaseContext : DbContext
        {
            public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

            public DbSet<PontoColetaModel> PontosColeta { get; set; }
            public DbSet<EnderecoPontoColetaModel> EnderecosPontoColeta { get; set; }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<PontoColetaModel>()
                    .HasOne(p => p.EnderecoPontoColetaModel)
                    .WithMany()
                    .HasForeignKey(p => p.EnderecoId)
                    .OnDelete(DeleteBehavior.Cascade);

                base.OnModelCreating(modelBuilder);
            }
        }
    }

}
