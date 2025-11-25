//Marcos Vinicius Arruda Vandresen
using AcademiaDoZe.Dominio.Entities;

namespace AcademiaDoZe.Dominio.Repositories
{
    public interface IColaboradorRepository : IRepository<Colaborador>
    {
        // Métodos específicos do domínio

        //Task<Colaborador?> ObterPorCpf(string cpf);
        // nova versão, retornando múltiplos colaboradores
        Task<IEnumerable<Colaborador>> ObterPorCpf(string cpf);
        Task<bool> CpfJaExiste(string cpf, int? id = null);
        Task<bool> TrocarSenha(int id, string novaSenha);
    }
}