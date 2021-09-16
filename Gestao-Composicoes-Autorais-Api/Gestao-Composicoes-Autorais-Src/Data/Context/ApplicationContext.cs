﻿using Gestao_Composicoes_Autorais_Src.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace Gestao_Composicoes_Autorais_Src.Data.Context
{
    public class ApplicationContext : DbContext
    {
        private const string CONNECTION_STRING = "server=us-cdbr-east-04.cleardb.com;user=b61ec255eb3f4c;password=3bcfe92fafeb1c0;database=heroku_de62e38b5e5347f";

        public DbSet<Musica> Musicas { get; set; }
        public DbSet<Autor> Autores { get; set; }

        public ApplicationContext(DbContextOptions options) : base(options) {}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var conn = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
                optionsBuilder.UseMySql(conn, new MySqlServerVersion(new Version(15, 1)))
                //optionsBuilder.UseMySql(CONNECTION_STRING, new MySqlServerVersion(new Version(15, 1)))
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