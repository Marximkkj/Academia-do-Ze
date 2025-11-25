//Marcos Vinicius Arruda Vandresen
using AcademiaDoZe.Application.Enums;
using AcademiaDoZe.Dominio.Enums;
namespace AcademiaDoZe.Application.Mappings
{
    public static class ColaboradorEnumMappings
    {
        public static EnumColaboradorTipo ToDomain(this EAppColaboradorTipo appTipo)
        {
            return (EnumColaboradorTipo)appTipo;
        }
        public static EAppColaboradorTipo ToApp(this EnumColaboradorTipo domainTipo)
        {
            return (EAppColaboradorTipo)domainTipo;
        }
        public static EnumColaboradorVinculo ToDomain(this EAppColaboradorVinculo appVinculo)
        {
            return (EnumColaboradorVinculo)appVinculo;
        }
        public static EAppColaboradorVinculo ToApp(this EnumColaboradorVinculo domainVinculo)
        {
            return (EAppColaboradorVinculo)domainVinculo;
        }
    }
}