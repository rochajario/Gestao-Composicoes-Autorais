using Gestao_Composicoes_Autorais_Src.Controllers;
using Gestao_Composicoes_Autorais_Src.Data.Interfaces;
using Gestao_Composicoes_Autorais_Src.Exceptions;
using Gestao_Composicoes_Autorais_Src.Model;
using Gestao_Composicoes_Autorais_Src.Model.Enums;
using Gestao_Composicoes_Autorais_Src.Model.Forms;
using Gestao_Composicoes_Autorais_Src.Service;
using Gestao_Composicoes_Autorais_Src.Service.ControllerService;
using Gestao_Composicoes_Autorais_Src.Service.Converter;
using Gestao_Composicoes_Autorais_Src.Service.Interfaces.ControllerService;
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
                .Setup(x => x.ObterTodosItens())
                .Returns(new ObjectResult(autores) { StatusCode = 200 });

            var controller = new AutorController(autorServiceMock.Object);

            //Act
            var result = controller.Get();

            //Assert
            autorServiceMock.Verify(x => x.ObterTodosItens(), Times.Once);
            Assert.IsType<ObjectResult>(result);
        }

        [Fact]
        public void AutorController_AdicionarNovoAutor_RetornaCreatedStatusCode()
        {
            //Arrange
            var autorRepo = FakeDatabaseBuilder.ObterAutoresRepository("AutorController_AdicionarNovoAutor_RetornaCreatedStatusCode");
            var service = new AutorControllerService(autorRepo, new AutorConverter(new ExceptionStrategyContextHandler()));

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
            autorRepo.Create(new Autor
            {
                Id = 1,
                Nome = "Fulano",
                Categoria = CategoriaAutoral.COMPOSITOR
            });

            var service = new AutorControllerService(autorRepo, new AutorConverter(new ExceptionStrategyContextHandler()));
            var controller = new AutorController(service);

            var form = new AutorForm { Nome = "Beltrano", Categoria = "autor" };

            //Act
            var result = controller.Put(1, form);
            Autor autorAdicionado = (Autor)result.Value;


            //Assert
            Assert.IsType<ObjectResult>(result);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal("Beltrano", autorAdicionado.Nome);
            Assert.Equal(CategoriaAutoral.AUTOR, autorAdicionado.Categoria);
        }

        [Fact]
        public void AutorController_ObterItemPorId_RetornaOkStatusCode()
        {
            //Arrange
            var autorRepo = new Mock<IAutoresRepository>();
            autorRepo
                .Setup(x => x.GetById(1))
                .Returns(new Autor
                {
                    Id = 1,
                    Nome = "Fulano",
                    Categoria = CategoriaAutoral.AUTOR
                });

            var service = new AutorControllerService(autorRepo.Object, new AutorConverter(new ExceptionStrategyContextHandler()));
            var controller = new AutorController(service);

            //Act
            var result = controller.Get(1);
            Autor autor = (Autor)result.Value;

            //Assert
            Assert.IsType<ObjectResult>(result);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal("Fulano", autor.Nome);
        }

        [Fact]
        public void AutorController_DeletaItem_RetornaOkStatusCode()
        {
            //Arrange
            var autorRepo = FakeDatabaseBuilder.ObterAutoresRepository("AutorController_DeletaItem_RetornaOkStatusCode");

            autorRepo.Create(
                new Autor
                {
                    Id = 1,
                    Nome = "Teste",
                    Categoria = CategoriaAutoral.AUTOR
                });

            var autor = autorRepo
                .GetAll()
                .FirstOrDefault(x => x.Nome == "Teste" && x.Categoria == CategoriaAutoral.AUTOR);

            var service = new AutorControllerService(autorRepo, new AutorConverter(new ExceptionStrategyContextHandler()));
            var controller = new AutorController(service);

            //Act
            var result = controller.Delete(autor.Id);

            //Assert
            Assert.IsType<ObjectResult>(result);
            Assert.Equal(204, result.StatusCode);
        }
    }
}
