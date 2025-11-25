//Marcos Vinicius Arruda Vandresen
using System.ComponentModel.DataAnnotations;
namespace AcademiaDoZe.Dominio.Enums;

public enum EnumColaboradorVinculo
{
    [Display(Name = "CLT")]
    CLT = 0,
    [Display(Name = "Estagiário")]
    Estagio = 1
}