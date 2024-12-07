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

            // DbSet para cada model
            public DbSet<PontoColetaModel> PontosColeta { get; set; }
            public DbSet<EnderecoPontoColetaModel> EnderecosPontoColeta { get; set; }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                // Configuração para o relacionamento entre PontoColetaModel e EnderecoPontoColetaModel
                modelBuilder.Entity<PontoColetaModel>()
                    .HasOne(p => p.EnderecoPontoColetaModel)
                    .WithMany() // Configurado como "muitos" se necessário
                    .HasForeignKey(p => p.EnderecoId)
                    .OnDelete(DeleteBehavior.Cascade);

                base.OnModelCreating(modelBuilder);
            }
        }
    }

}
