//Marcos Vinicius Arruda Vandresen
using System.ComponentModel.DataAnnotations;
namespace AcademiaDoZe.Dominio.Enums
{
    public enum EnumPessoaTipo
    {
        [Display(Name = "Colaborador")]
        Colaborador = 0,
        [Display(Name = "Aluno")]
        Aluno = 1
    }
}