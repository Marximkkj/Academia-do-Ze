//Marcos Vinicius Arruda Vandresen
namespace AcademiaDoZe.Infraestrutura.Exceptions
{
    public class InfraestruturaException : Exception
    {
        public InfraestruturaException(string message) : base(message)
        {
        }
        public InfraestruturaException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
