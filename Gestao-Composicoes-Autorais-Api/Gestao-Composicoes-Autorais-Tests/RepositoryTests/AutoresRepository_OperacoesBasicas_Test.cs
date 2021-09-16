using Gestao_Composicoes_Autorais_Src.Model;
using Gestao_Composicoes_Autorais_Src.Model.Enums;
using Gestao_Composicoes_Autorais_Tests.FakeDatabase;
using ServiceStack.Host;
using System.Linq;
using System.Net;
using Xunit;

namespace Gestao_Composicoes_Autorais_Tests.RepositoryTests
{
    public class AutoresRepository_OperacoesBasicas_Test
    {
        [Fact]
        public void AutoresRepository_CreateItem_CriaItemComSucesso()
        {
            //Arrange
            var repo = FakeDatabaseBuilder.ObterAutoresRepository("AutoresRepository_CreateItem_CriaItemComSucesso");

            var autor = new Autor
            {
                Nome = "Fulano",
                Categoria = CategoriaAutoral.AUTOR
            };

            //Act
            repo.Create(autor);
            var autorCriado = repo.GetAll().FirstOrDefault(m => m.Nome == "Fulano");

            //Assert
            Assert.Equal("Fulano", autorCriado.Nome);
            Assert.Equal(CategoriaAutoral.AUTOR, autorCriado.Categoria);
        }

        [Fact]
        public void AutoresRepository_UpdateItem_CriaItemComSucesso()
        {
            //Arrange
            var repo = FakeDatabaseBuilder.ObterAutoresRepository("AutoresRepository_UpdateItem_CriaItemComSucesso");

            var autor = new Autor
            {
                Nome = "Fulano",
                Categoria = CategoriaAutoral.AUTOR
            };
            repo.Create(autor);
            var autorCriado = repo.GetAll().FirstOrDefault(m => m.Nome == "Fulano");

            //Act
            autorCriado.Nome = "Ciclano";
            autorCriado.Categoria = CategoriaAutoral.COMPOSITOR;
            repo.Update(autorCriado);

            //Assert
            Assert.Equal("Ciclano", autorCriado.Nome);
            Assert.Equal(CategoriaAutoral.COMPOSITOR, autorCriado.Categoria);
        }

        [Fact]
        public void AutoresRepository_DeleteItem_RemoveItemComSucesso()
        {
            //Arrange
            var repo = FakeDatabaseBuilder.ObterAutoresRepository("AutoresRepository_DeleteItem_RemoveItemComSucesso");

            var autor1 = new Autor
            {
                Nome = "Fulano",
                Categoria = CategoriaAutoral.AUTOR
            };

            var autor2 = new Autor
            {
                Nome = "Ciclano",
                Categoria = CategoriaAutoral.COMPOSITOR
            };

            repo.Create(autor1);
            repo.Create(autor2);
            var autorCriado = repo.GetAll().FirstOrDefault(m => m.Nome == "Fulano");

            //Act
            repo.Delete(autorCriado.Id);

            //Assert
            Assert.Equal(1, repo.GetAll().Count);
        }

        [Fact]
        public void AutoresRepository_GetAllItems_LancaException()
        {
            //Arrange
            var repo = FakeDatabaseBuilder.ObterAutoresRepository("AutoresRepository_GetAllItems_LancaException");

            //Act
            var exception = Assert.Throws<HttpException>(() => repo.GetAll());

            //Assert
            Assert.Equal((int)HttpStatusCode.NotFound, exception.StatusCode);
        }

        [Fact]
        public void AutoresRepository_GetItemById_LancaException()
        {
            //Arrange
            var repo = FakeDatabaseBuilder.ObterAutoresRepository("AutoresRepository_GetItemById_LancaException");

            //Act
            var exception = Assert.Throws<HttpException>(() => repo.GetById(1));

            //Assert
            Assert.Equal((int)HttpStatusCode.NotFound, exception.StatusCode);
        }

    }
}
