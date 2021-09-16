using Gestao_Composicoes_Autorais_Src.Controllers;
using Gestao_Composicoes_Autorais_Src.Exceptions;
using Gestao_Composicoes_Autorais_Src.Model;
using Gestao_Composicoes_Autorais_Src.Model.Enums;
using Gestao_Composicoes_Autorais_Src.Model.Forms;
using Gestao_Composicoes_Autorais_Src.Service;
using Gestao_Composicoes_Autorais_Src.Service.Converter;
using Gestao_Composicoes_Autorais_Tests.FakeDatabase;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Gestao_Composicoes_Autorais_Tests.ControllerTests
{
    public class AutorController_OperacoesBasicas_Test
    {
        [Fact]
        public void AutorController_BuscarAutores_RetornaResultadoEsperado()
        {
            //Arrange
            var autorServiceMock = new Mock<IAutorService>();

            var autores = new List<Autor>()
            {
                new Autor
                {
                    Id = 1,
                    Nome = "Fulano",
                    Categoria = CategoriaAutoral.AUTOR
                },

                new Autor
                {
                    Id = 2,
                    Nome = "Ciclano",
                    Categoria = CategoriaAutoral.COMPOSITOR
                }
            };

            autorServiceMock
                .Setup(x => x.ObterTodosAutores())
                .Returns(new ObjectResult(autores) { StatusCode = 200 });

            var controller = new AutorController(autorServiceMock.Object);

            //Act
            var result = controller.Get();

            //Assert
            autorServiceMock.Verify(x => x.ObterTodosAutores(), Times.Once);
            Assert.IsType<ObjectResult>(result);
        }

        [Fact]
        public void AutorController_AdicionarNovoAutor_RetornaCreatedStatusCode()
        {
            //Arrange
            var autorRepo = FakeDatabaseBuilder.ObterAutoresRepository("AutorController_AdicionarNovoAutor_RetornaCreatedStatusCode");
            var service = new AutorService(autorRepo, new AutorConverter(new ExceptionStrategyContextHandler()));

            var controller = new AutorController(service);

            var form = new AutorForm { Nome = "Fulano", Categoria = "autor" };

            //Act
            var result = controller.Post(form);
            var autorAdicionado = autorRepo.GetAll().FirstOrDefault(a => a.Nome == "Fulano" && a.Categoria == CategoriaAutoral.AUTOR);


            //Assert
            Assert.IsType<ObjectResult>(result);
            Assert.Equal(201, result.StatusCode);
            Assert.Equal("Fulano", autorAdicionado.Nome);
        }

        [Fact]
        public void AutorController_AlterarAutor_RetornaOkStatusCode()
        {
            //Arrange
            var autorRepo = FakeDatabaseBuilder.ObterAutoresRepository("AutorController_AdicionarNovoAutor_RetornaCreatedStatusCode");
            var service = new AutorService(autorRepo, new AutorConverter(new ExceptionStrategyContextHandler()));

            var controller = new AutorController(service);

            var form = new AutorForm { Nome = "Fulano", Categoria = "autor" };

            //Act
            var result = controller.Post(form);
            var autorAdicionado = autorRepo.GetAll().FirstOrDefault(a => a.Nome == "Fulano" && a.Categoria == CategoriaAutoral.AUTOR);


            //Assert
            Assert.IsType<ObjectResult>(result);
            Assert.Equal(201, result.StatusCode);
            Assert.Equal("Fulano", autorAdicionado.Nome);
        }
    }
}
