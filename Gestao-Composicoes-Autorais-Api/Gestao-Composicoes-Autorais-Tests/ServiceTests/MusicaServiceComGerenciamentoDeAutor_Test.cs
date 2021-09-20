using Gestao_Composicoes_Autorais_Src.Data.Interfaces;
using Gestao_Composicoes_Autorais_Src.Exceptions;
using Gestao_Composicoes_Autorais_Src.Model;
using Gestao_Composicoes_Autorais_Src.Model.Enums;
using Gestao_Composicoes_Autorais_Src.Model.Forms;
using Gestao_Composicoes_Autorais_Src.Service.ControllerService;
using Gestao_Composicoes_Autorais_Src.Service.Converter;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace Gestao_Composicoes_Autorais_Tests.ServiceTests
{
    public class MusicaServiceComGerenciamentoDeAutor_Test
    {
        [Fact]
        public void DeveriaAdicionarMusicaComCampoAutoresPreenchido()
        {
            //Arrange
            var musicasRepository = new Mock<IMusicasRepository>();
            var autoresRepository = new Mock<IAutoresRepository>();
            autoresRepository
                .Setup(x => x.GetById(It.IsAny<long>()))
                .Returns(new Autor
                {
                    Id = 1,
                    Nome = "Fulano",
                    Categoria = CategoriaAutoral.COMPOSITOR
                });
            var service = new MusicaControllerServiceExtendido(new MusicaConverter(new ExceptionStrategyContextHandler()), musicasRepository.Object, autoresRepository.Object);
            var ids = new List<long>()
            {
                1,
                2,
                3
            };

            var form = new MusicaForm
            {
                Nome = "Teste",
                Genero = "rock",
                CodAutores = ids
            };

            //Act
            _ = service.AdicionarNovoItem(form);

            //Assert
            autoresRepository.Verify(x => x.GetById(It.IsAny<long>()), Times.Exactly(3));
        }

        [Fact]
        public void DeveriaAtualizarMusicaComCampoAutoresPreenchido()
        {
            //Arrange
            var musicasRepository = new Mock<IMusicasRepository>();
            musicasRepository
                .Setup(x => x.GetById(It.IsAny<long>()))
                .Returns(new Musica
                {
                    Id = 1,
                    Nome = "teste",
                    Genero = GeneroMusical.SERTANEJO,
                    Autores = default
                });

            var autoresRepository = new Mock<IAutoresRepository>();
            autoresRepository
                .Setup(x => x.GetById(It.IsAny<long>()))
                .Returns(new Autor
                {
                    Id = 1,
                    Nome = "Fulano",
                    Categoria = CategoriaAutoral.COMPOSITOR
                });
            var service = new MusicaControllerServiceExtendido(new MusicaConverter(new ExceptionStrategyContextHandler()), musicasRepository.Object, autoresRepository.Object);

            var ids = new List<long>()
            {
                1,
                2,
                3
            };

            var form = new MusicaForm
            {
                Nome = "Teste",
                Genero = "rock",
                CodAutores = ids
            };

            //Act

            _ = service.AtualizarItem(1, form);

            //Assert
            autoresRepository.Verify(x => x.GetById(It.IsAny<long>()), Times.Exactly(3));
        }
    }
}
