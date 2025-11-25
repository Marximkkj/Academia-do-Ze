//Marcos Vinicius Arruda Vandresen
using AcademiaDoZe.Dominio.Entities;
namespace AcademiaDoZe.Dominio.Repositories
{
    public interface IAlunoRepository : IRepository<Aluno>
    {
        // Métodos específicos do domínio
        Task<Aluno?> ObterPorCpf(string cpf);

        Task<bool> CpfJaExiste(string cpf, int? id = null);
        Task<bool> TrocarSenha(int id, string novaSenha);
    }
}