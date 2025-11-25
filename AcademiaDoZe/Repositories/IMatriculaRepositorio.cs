//Marcos Vinicius Arruda Vandresen
using AcademiaDoZe.Dominio.Entities;
namespace AcademiaDoZe.Dominio.Repositories
{
    public interface IMatriculaRepository : IRepository<Matricula>
    {
        // Métodos específicos do domínio

        Task<IEnumerable<Matricula>> ObterPorAluno(int alunoId);
        Task<IEnumerable<Matricula>> ObterAtivas(int alunoId = 0);
        Task<IEnumerable<Matricula>> ObterVencendoEmDias(int dias);
    }
}