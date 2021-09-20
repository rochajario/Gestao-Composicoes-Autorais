using Gestao_Composicoes_Autorais_Src.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace Gestao_Composicoes_Autorais_Src.Data.Context
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Musica> Musicas { get; set; }
        public DbSet<Autor> Autores { get; set; }

        public ApplicationContext(DbContextOptions options) : base(options) {}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                /*
                    Caso opte-se por utilizar uma abordagem de desenvolvimento Code-First 
                    será necessário declarar de maneira explícita a connection string do banco de dados
                    conforme padrão no arquivo /Properties/launchSettings.json
                */
                var databaseConnectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
                optionsBuilder.UseMySql(databaseConnectionString, new MySqlServerVersion(new Version(15, 1)))
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Musica>()
                .ToTable("Musicas")
                .Property(m => m.Genero)
                .HasConversion<string>();

            modelBuilder.Entity<Autor>()
                .ToTable("Autores")
                .Property(a => a.Categoria)
                .HasConversion<string>();
        }
    }
}
