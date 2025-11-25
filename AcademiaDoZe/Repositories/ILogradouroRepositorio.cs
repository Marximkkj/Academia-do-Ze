//Marcos Vinicius Arruda Vandresen
using AcademiaDoZe.Dominio.Entities;
namespace AcademiaDoZe.Dominio.Repositories
{
    public interface ILogradouroRepository : IRepository<Logradouro>
    {
        // Métodos específicos do domínio

        Task<Logradouro?> ObterPorCep(string cep);

        Task<IEnumerable<Logradouro>> ObterPorCidade(string cidade);
    }
}