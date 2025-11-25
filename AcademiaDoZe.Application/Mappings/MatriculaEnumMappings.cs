//Marcos Vinicius Arruda Vandresen
using AcademiaDoZe.Application.Enums;
using AcademiaDoZe.Dominio.Enums;
namespace AcademiaDoZe.Application.Mappings
{
    public static class MatriculaEnumMappings
    {
        public static EnumMatriculaPlano ToDomain(this EAppMatriculaPlano appPlano)
        {
            return (EnumMatriculaPlano)appPlano;
        }
        public static EAppMatriculaPlano ToApp(this EnumMatriculaPlano domainPlano)
        {
            return (EAppMatriculaPlano)domainPlano;
        }
        public static EnumMatriculaRestricoes ToDomain(this EAppMatriculaRestricoes appRestricoes)
        {
            return (EnumMatriculaRestricoes)appRestricoes;
        }
        public static EAppMatriculaRestricoes ToApp(this EnumMatriculaRestricoes domainRestricoes)
        {
            return (EAppMatriculaRestricoes)domainRestricoes;
        }
    }
}