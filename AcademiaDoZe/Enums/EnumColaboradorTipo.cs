//Marcos Vinicius Arruda Vandresen
using System.ComponentModel.DataAnnotations;
namespace AcademiaDoZe.Dominio.Enums;

public enum EnumColaboradorTipo
{
    [Display(Name = "Administrador")]
    Administrador = 0,
    [Display(Name = "Atendente")]
    Atendente = 1,
    [Display(Name = "Instrutor")]
    Instrutor = 2
}