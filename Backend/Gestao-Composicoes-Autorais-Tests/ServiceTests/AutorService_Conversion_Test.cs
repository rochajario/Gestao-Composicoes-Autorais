using Gestao_Composicoes_Autorais_Src.Exceptions;
using Gestao_Composicoes_Autorais_Src.Model.Enums;
using Gestao_Composicoes_Autorais_Src.Model.Forms;
using Gestao_Composicoes_Autorais_Src.Service.Converter;
using ServiceStack.Host;
using System.Net;
using Xunit;

namespace Gestao_Composicoes_Autorais_Tests.ServiceTests
{
    public class AutorService_Conversion_Test
    {
        [Fact]
        public void AutorConverter_ConvertFormParaEntityModel_ComSucesso()
        {
            //Arrange
            var form = new AutorForm
            {
                Nome = "Fulano",
                Categoria = "autor"
            };

            var service = new AutorConverter(new ExceptionStrategyContextHandler());

            //Act
            var autor = service.Convert(form);

            //Assert
            Assert.Equal("Fulano", autor.Nome);
            Assert.Equal(CategoriaAutoral.AUTOR, autor.Categoria);
        }

        [Fact]
        public void AutorConverter_ConvertFormParaEntityModel_LancaException()
        {
            //Arrange
            var form = new AutorForm
            {
                Nome = "Fulano",
                Categoria = "padeiro"
            };

            var service = new AutorConverter(new ExceptionStrategyContextHandler());

            //Act
            var exception = Assert.Throws<HttpException>(() => service.Convert(form));

            //Assert
            Assert.Equal((int)HttpStatusCode.UnprocessableEntity, exception.StatusCode);
        }
    }
}
