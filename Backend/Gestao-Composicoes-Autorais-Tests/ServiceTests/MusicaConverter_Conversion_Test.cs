using Gestao_Composicoes_Autorais_Src.Exceptions;
using Gestao_Composicoes_Autorais_Src.Model.Enums;
using Gestao_Composicoes_Autorais_Src.Model.Forms;
using Gestao_Composicoes_Autorais_Src.Service.Converter;
using ServiceStack.Host;
using System.Net;
using Xunit;

namespace Gestao_Composicoes_Autorais_Tests.ServiceTests
{
    public class MusicaConverter_Conversion_Test
    {
        [Fact]
        public void MusicaConverter_ConvertFormParaEntityModel_ComSucesso()
        {
            //Arrange
            var form = new MusicaForm
            {
                Nome = "Uma música Qualquer",
                Genero = "gospel"
            };

            var service = new MusicaConverter(new ExceptionStrategyContextHandler());

            //Act
            var musica = service.Convert(form);

            //Assert
            Assert.Equal("Uma música Qualquer", musica.Nome);
            Assert.Equal(GeneroMusical.GOSPEL, musica.Genero);
        }

        [Fact]
        public void MusicaConverter_ConvertFormParaEntityModel_LancaException()
        {
            //Arrange
            var form = new MusicaForm
            {
                Nome = "Uma música Qualquer",
                Genero = "Ação"
            };

            var service = new MusicaConverter(new ExceptionStrategyContextHandler());

            //Act
            var exception = Assert.Throws<HttpException>(() => service.Convert(form));

            //Assert
            Assert.Equal((int)HttpStatusCode.UnprocessableEntity, exception.StatusCode);
        }
    }
}
