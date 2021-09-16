using Gestao_Composicoes_Autorais_Src.Data.Interfaces;
using Gestao_Composicoes_Autorais_Src.Exceptions;
using Gestao_Composicoes_Autorais_Src.Model;
using Gestao_Composicoes_Autorais_Src.Model.Enums;
using Gestao_Composicoes_Autorais_Src.Model.Forms;
using Gestao_Composicoes_Autorais_Src.Service.ControllerService;
using Gestao_Composicoes_Autorais_Src.Service.Converter;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ServiceStack.Host;
using System.Collections.Generic;
using System.Net;
using Xunit;

namespace Gestao_Composicoes_Autorais_Tests.ServiceTests
{
    public class MusicaService_Test
    {
        [Fact]
        public void AdicionarItem_ObtemSucesso()
        {
            //Arrange
            var musicasRepo = new Mock<IMusicasRepository>();
            var converter = new MusicaConverter(new ExceptionStrategyContextHandler());
            var service = new MusicaControllerService(converter, musicasRepo.Object);

            //Act
            var resultado = service.AdicionarNovoItem(new MusicaForm { Genero = "gospel", Nome = "Teste" });
            var payloadResultado = (Musica)resultado.Value;

            //Assert
            musicasRepo.Verify(x => x.Create(It.IsAny<Musica>()), Times.Once);
            Assert.Equal("Teste", payloadResultado.Nome);
            Assert.IsType<GeneroMusical>(payloadResultado.Genero);
        }

        [Fact]
        public void AdicionarItem_LancaException()
        {
            //Arrange
            var musicasRepo = new Mock<IMusicasRepository>();
            var converter = new MusicaConverter(new ExceptionStrategyContextHandler());
            var service = new MusicaControllerService(converter, musicasRepo.Object);

            //Act
            var exception = Assert.Throws<HttpException>(() => service.AdicionarNovoItem(new MusicaForm { Genero = "Padeiro", Nome = "Teste" }));

            //Assert
            Assert.Equal((int)HttpStatusCode.UnprocessableEntity, exception.StatusCode);
        }

        [Fact]
        public void AtualizarItem_ObtemSucesso()
        {
            //Arrange
            var musicasRepo = new Mock<IMusicasRepository>();
            musicasRepo
                .Setup(x => x.GetById(It.IsAny<long>()))
                .Returns(new Musica
                {
                    Id = 1,
                    Genero = GeneroMusical.GOSPEL,
                    Nome = "Teste1"
                });

            var converter = new MusicaConverter(new ExceptionStrategyContextHandler());
            var service = new MusicaControllerService(converter, musicasRepo.Object);

            //Act
            var resultado = service.AtualizarItem(1, new MusicaForm
            {
                Genero = "rock",
                Nome = "Teste2"
            });
            var payloadResultado = (Musica)resultado.Value;

            //Assert
            musicasRepo.Verify(x => x.Update(It.IsAny<Musica>()), Times.Once);
            Assert.Equal("Teste2", payloadResultado.Nome);
            Assert.Equal(GeneroMusical.ROCK, payloadResultado.Genero);
        }

        [Fact]
        public void AtualizarItem_LancaException()
        {
            //Arrange
            var musicasRepo = new Mock<IMusicasRepository>();
            musicasRepo
                .Setup(x => x.GetById(It.IsAny<long>()))
                .Returns(new Musica
                {
                    Id = 1,
                    Genero = GeneroMusical.GOSPEL,
                    Nome = "Teste1"
                });

            var converter = new MusicaConverter(new ExceptionStrategyContextHandler());
            var service = new MusicaControllerService(converter, musicasRepo.Object);

            //Act
            var exception = Assert.Throws<HttpException>(() => service.AtualizarItem(1, new MusicaForm
            {
                Genero = "limpeza",
                Nome = "Teste2"
            }));

            //Assert
            Assert.Equal(422, exception.StatusCode);
        }

        [Fact]
        public void ObterListaDeItens_ObtemSucesso()
        {
            //Arrange
            var musicasRepo = new Mock<IMusicasRepository>();
            musicasRepo
                .Setup(x => x.GetAll())
                .Returns(new List<Musica>()
                {
                    new Musica
                    {
                        Id = 1,
                        Genero = GeneroMusical.GOSPEL,
                        Nome = "Teste1"
                    },
                    new Musica
                    {
                        Id = 2,
                        Genero = GeneroMusical.ROCK,
                        Nome = "Teste2"
                    }
                });

            var converter = new MusicaConverter(new ExceptionStrategyContextHandler());
            var service = new MusicaControllerService(converter, musicasRepo.Object);

            //Act
            var result = service.ObterTodosItens();

            //Assert
            musicasRepo.Verify(x => x.GetAll(), Times.Once);
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public void ObterItem_ObtemSucesso()
        {
            //Arrange
            var musicasRepo = new Mock<IMusicasRepository>();
            musicasRepo
                .Setup(x => x.GetById(It.IsAny<long>()))
                .Returns(
                    new Musica{
                        Id = 1,
                        Genero = GeneroMusical.GOSPEL,
                        Nome = "Teste1"
                    });

            var converter = new MusicaConverter(new ExceptionStrategyContextHandler());
            var service = new MusicaControllerService(converter, musicasRepo.Object);

            //Act
            var result = service.ObterItemPorId(1);

            //Assert
            musicasRepo.Verify(x => x.GetById(It.IsAny<long>()), Times.Once);
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public void RemoverItem_ObtemSucesso()
        {
            //Arrange
            var musicasRepo = new Mock<IMusicasRepository>();
            var converter = new MusicaConverter(new ExceptionStrategyContextHandler());
            var service = new MusicaControllerService(converter, musicasRepo.Object);

            //Act
            var result = service.RemoverItem(1);

            //Assert
            musicasRepo.Verify(x => x.Delete(It.IsAny<long>()), Times.Once);
            Assert.IsType<ObjectResult>(result);
            Assert.Equal(204, result.StatusCode);
        }
    }
}
