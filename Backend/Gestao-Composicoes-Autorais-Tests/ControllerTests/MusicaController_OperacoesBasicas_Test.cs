using Gestao_Composicoes_Autorais_Src.Controllers;
using Gestao_Composicoes_Autorais_Src.Model;
using Gestao_Composicoes_Autorais_Src.Model.Forms;
using Gestao_Composicoes_Autorais_Src.Service.Interfaces.ControllerService;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Net;
using Xunit;

namespace Gestao_Composicoes_Autorais_Tests.ControllerTests
{
    public class MusicaController_OperacoesBasicas_Test
    {
        [Fact]
        public void MusicaController_Post_RetornaStatusCode201()
        {
            //Arrange
            var service = new Mock<IMusicaService>();
            service
                .Setup(x => x.AdicionarNovoItem(It.IsAny<MusicaForm>()))
                .Returns(new ObjectResult(new Musica()) { StatusCode = 201 });

            var controller = new MusicaController(service.Object);
            //Act
            var result = controller.Post(new MusicaForm { Nome = "Teste", Genero = "gospel" });
            //Assert
            Assert.IsType<ObjectResult>(result);
            Assert.Equal((int)HttpStatusCode.Created, result.StatusCode);
        }

        [Fact]
        public void MusicaController_Put_RetornaStatusCode200()
        {
            //Arrange
            var service = new Mock<IMusicaService>();
            service
                .Setup(x => x.AtualizarItem(It.IsAny<long>(),It.IsAny<MusicaForm>()))
                .Returns(new ObjectResult(new Musica()) { StatusCode = 200 });

            var controller = new MusicaController(service.Object);

            //Act
            var result = controller.Put(1, new MusicaForm { Nome = "Teste", Genero = "gospel" });

            //Assert
            Assert.IsType<ObjectResult>(result);
            Assert.Equal((int)HttpStatusCode.OK, result.StatusCode);
        }

        [Fact]
        public void MusicaController_GetAll_RetornaStatusCode200()
        {
            //Arrange
            var service = new Mock<IMusicaService>();
            service
                .Setup(x => x.ObterTodosItens())
                .Returns(new ObjectResult(new List<Musica>()) { StatusCode = 200 });

            var controller = new MusicaController(service.Object);

            //Act
            var result = controller.Get();

            //Assert
            service.Verify(x => x.ObterTodosItens());
            Assert.Equal((int)HttpStatusCode.OK, result.StatusCode);
        }

        [Fact]
        public void MusicaController_Get_RetornaStatusCode200()
        {
            //Arrange
            var service = new Mock<IMusicaService>();
            service
                .Setup(x => x.ObterItemPorId(It.IsAny<long>()))
                .Returns(new ObjectResult(new Musica()) { StatusCode = 200 });

            var controller = new MusicaController(service.Object);

            //Act
            var result = controller.Get(1);

            //Assert
            service.Verify(x => x.ObterItemPorId(It.IsAny<long>()));
            Assert.Equal((int)HttpStatusCode.OK, result.StatusCode);
        }

        [Fact]
        public void MusicaController_Delete_RetornaStatusCode204()
        {
            //Arrange
            var service = new Mock<IMusicaService>();
            service
                .Setup(x => x.RemoverItem(It.IsAny<long>()))
                .Returns(new ObjectResult(null) { StatusCode = 204 });

            var controller = new MusicaController(service.Object);

            //Act
            var result = controller.Delete(1);

            //Assert
            service.Verify(x => x.RemoverItem(It.IsAny<long>()));
            Assert.Equal((int)HttpStatusCode.NoContent, result.StatusCode);
        }


    }
}
