//Marcos Vinicius Arruda Vandresen
using AcademiaDoZe.Dominio.Enums;
using AcademiaDoZe.Dominio.Exceptions;
using AcademiaDoZe.Dominio.Services;
using AcademiaDoZe.Dominio.ValueObject;

namespace AcademiaDoZe.Dominio.Entities;

public class Matricula : Entity
{
    // encapsulamento das propriedades, aplicando imutabilidade
    public Aluno AlunoMatricula { get; private set; }
    public EnumMatriculaPlano Plano { get; private set; }
    public DateOnly DataInicio { get; private set; }
    public DateOnly DataFim { get; private set; }
    public string Objetivo { get; private set; }
    public EnumMatriculaRestricoes RestricoesMedicas { get; private set; }
    public string ObservacoesRestricoes { get; private set; }
    public Arquivo LaudoMedico { get; private set; }
    // construtor privado para evitar instância direta
    private Matricula(int id, Aluno alunoMatricula, EnumMatriculaPlano plano, DateOnly dataInicio, DateOnly dataFim, string objetivo,
        EnumMatriculaRestricoes restricoesMedicas, Arquivo laudoMedico, string observacoesRestricoes = "")
    : base()
    {
        Id = id;
        AlunoMatricula = alunoMatricula;
        Plano = plano;
        DataInicio = dataInicio;
        DataFim = dataFim;
        Objetivo = objetivo;
        RestricoesMedicas = restricoesMedicas;
        LaudoMedico = laudoMedico;
        ObservacoesRestricoes = observacoesRestricoes;
    }
    // método de fábrica, ponto de entrada para criar um objeto válido
    public static Matricula Criar(int id, Aluno alunoMatricula, EnumMatriculaPlano plano, DateOnly dataInicio, DateOnly dataFim,
        string objetivo, EnumMatriculaRestricoes restricoesMedicas, Arquivo laudoMedico, string
    observacoesRestricoes = "")
    {
        // Validações e normalizações
        if (alunoMatricula == null) throw new DomainException("ALUNO_INVALIDO");
        if (alunoMatricula.DataNascimento > DateOnly.FromDateTime(DateTime.Today.AddYears(-16)) && laudoMedico == null) throw new DomainException("MENOR16_LAUDO_OBRIGATORIO");
        if (!Enum.IsDefined(plano)) throw new DomainException("PLANO_INVALIDO");
        if (dataInicio == default) throw new DomainException("DATA_INICIO_OBRIGATORIO");
        // dataFim
        if (NormalizadoService.TextoVazioOuNulo(objetivo)) throw new DomainException("OBJETIVO_OBRIGATORIO");
        objetivo = NormalizadoService.LimparEspacos(objetivo);
        if (restricoesMedicas != EnumMatriculaRestricoes.None && laudoMedico == null) throw new DomainException("RESTRICOES_LAUDO_OBRIGATORIO");
        observacoesRestricoes = NormalizadoService.LimparEspacos(observacoesRestricoes);
        // Não permitir nova matrícula se ainda tiver matrícula ativa.
        // dependeremos da persistência para verificar se o aluno já possui matrícula ativa.
        // criação e retorno do objeto
        return new Matricula(id, alunoMatricula, plano, dataInicio, dataFim, objetivo, restricoesMedicas, laudoMedico,
            observacoesRestricoes);
    }
}