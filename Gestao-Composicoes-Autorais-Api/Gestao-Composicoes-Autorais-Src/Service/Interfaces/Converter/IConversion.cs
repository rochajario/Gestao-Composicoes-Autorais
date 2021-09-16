namespace Gestao_Composicoes_Autorais_Src.Service.Interfaces.Converter
{
    interface IConversion<Tin, Tout>
    {
        Tout Convert(Tin input);
    }
}
