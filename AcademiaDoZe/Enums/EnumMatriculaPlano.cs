//Marcos Vinicius Arruda Vandresen
using System.ComponentModel.DataAnnotations;
namespace AcademiaDoZe.Dominio.Enums;

public enum EnumMatriculaPlano
{
    [Display(Name = "Mensal")]
    Mensal = 0,
    [Display(Name = "Trimestral")]
    Trimestral = 1,
    [Display(Name = "Semestral")]
    Semestral = 2,
    [Display(Name = "Anual")]
    Anual = 3
}