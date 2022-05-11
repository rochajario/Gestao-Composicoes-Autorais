using Gestao_Composicoes_Autorais_Src.Model;
using Gestao_Composicoes_Autorais_Src.Model.Enums;
using Gestao_Composicoes_Autorais_Tests.FakeDatabase;
using ServiceStack.Host;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Xunit;

namespace Gestao_Composicoes_Autorais_Tests.RepositoryTests
{
    public class MusicaRepository_OperacoesBasicas_Test
    {
        [Fact]
        public void MusicaRepository_CreateItem_CriaItemComSucesso()
        {
            //Arrange
            var repo = FakeDatabaseBuilder.ObterMusicasRepository("MusicaRepository_CreateItem_CriaItemComSucesso");

            var musica = new Musica {
                Nome = "Tudo que eu vivi",
                Genero = GeneroMusical.GOSPEL,
                Autores = new List<Autor> (){
                    new Autor
                    {
                        Id=1,
                        Nome ="Fulano",
                        Categoria = CategoriaAutoral.AUTOR
                    }
                }
            };

            //Act
            repo.Create(musica);
            var musicaCriada = repo.GetAll().FirstOrDefault(m => m.Nome == "Tudo que eu vivi");

            //Assert
            Assert.Equal("Tudo que eu vivi", musicaCriada.Nome);
            Assert.Equal(GeneroMusical.GOSPEL, musicaCriada.Genero);
            Assert.Equal(1, musicaCriada.Autores.ToArray()[0].Id);
        }

        [Fact]
        public void MusicaRepository_UpdateItem_AtualizaItemComSucesso()
        {
            //Arrange
            var repo = FakeDatabaseBuilder.ObterMusicasRepository("MusicaRepository_UpdateItem_AtualizaItemComSucesso");

            var musica = new Musica
            {
                Nome = "Tudo que eu vivi",
                Genero = GeneroMusical.GOSPEL
            };

            //Act
            repo.Create(musica);
            var musicaCriada = repo.GetAll().FirstOrDefault(m => m.Nome == "Tudo que eu vivi");
            musicaCriada.Nome = "Outro título";
            repo.Update(musicaCriada);

            //Assert
            Assert.Equal("Outro título", musicaCriada.Nome);
            Assert.Equal(GeneroMusical.GOSPEL, musicaCriada.Genero);
        }

        [Fact]
        public void MusicaRepository_DeleteItem_RemoveItemComSucesso()
        {
            //Arrange
            var repo = FakeDatabaseBuilder.ObterMusicasRepository("MusicaRepository_DeleteItem_RemoveItemComSucesso");

            var musica1 = new Musica
            {
                Nome = "Tudo que eu vivi",
                Genero = GeneroMusical.GOSPEL
            };

            var musica2 = new Musica
            {
                Nome = "Outra Musica",
                Genero = GeneroMusical.GOSPEL
            };

            //Act
            repo.Create(musica1);
            repo.Create(musica2);
            var musicaCriada = repo.GetAll().FirstOrDefault(m => m.Nome == "Tudo que eu vivi");
            repo.Delete(musicaCriada.Id);

            //Assert
            Assert.Equal(1, repo.GetAll().Count);
        }

        [Fact]
        public void MusicaRepository_GetAllItems_LancaException()
        {
            //Arrange
            var repo = FakeDatabaseBuilder.ObterMusicasRepository("MusicaRepository_GetAllItems_LancaException");

            //Act
            var exception = Assert.Throws<HttpException>(() => repo.GetAll());

            //Assert
            Assert.Equal((int)HttpStatusCode.NotFound, exception.StatusCode);
        }

        [Fact]
        public void MusicaRepository_GetById_LancaException()
        {
            //Arrange
            var repo = FakeDatabaseBuilder.ObterMusicasRepository("MusicaRepository_GetById_LancaException");

            //Act
            var exception = Assert.Throws<HttpException>(() => repo.GetById(1));

            //Assert
            Assert.Equal((int)HttpStatusCode.NotFound, exception.StatusCode);
        }
    }
}
