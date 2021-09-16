using Gestao_Composicoes_Autorais_Src.Data;
using Gestao_Composicoes_Autorais_Src.Data.Context;
using Gestao_Composicoes_Autorais_Src.Data.Interfaces;
using Gestao_Composicoes_Autorais_Src.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;

namespace Gestao_Composicoes_Autorais_Tests.FakeDatabase
{
    public static class FakeDatabaseBuilder
    {
        public static IMusicasRepository ObterMusicasRepository(string nomeTeste)
        {
            DbContextOptions options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase(nomeTeste)
                .Options;

            return new MusicasRepository(new ApplicationContext(options), new ExceptionStrategyContextHandler());
        }

        internal static IAutoresRepository ObterAutoresRepository(string nomeTeste)
        {
            DbContextOptions options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase(nomeTeste)
                .Options;

            return new AutoresRepository(new ApplicationContext(options), new ExceptionStrategyContextHandler());
        }
    }
}
