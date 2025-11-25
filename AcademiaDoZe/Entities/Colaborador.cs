//Marcos Vinicius Arruda Vandresen
using AcademiaDoZe.Dominio.Exceptions;
using AcademiaDoZe.Dominio.Services;
using AcademiaDoZe.Dominio.Enums;
using AcademiaDoZe.Dominio.ValueObject;
namespace AcademiaDoZe.Dominio.Entities;

public class Colaborador : Pessoa
{
    // encapsulamento das propriedades, aplicando imutabilidade
    public DateOnly DataAdmissao { get; private set; }
    public EnumColaboradorTipo Tipo { get; private set; }
    public EnumColaboradorVinculo Vinculo { get; private set; }

    // construtor privado para evitar instanciação direta
    private Colaborador(int id, string nomeCompleto,
    string cpf,
    DateOnly dataNascimento,
    string telefone,
    string email,
    Logradouro endereco,
    string numero,
    string complemento,
    string senha,
    Arquivo foto,
    DateOnly dataAdmissao,
    EnumColaboradorTipo tipo,
    EnumColaboradorVinculo vinculo)
    : base(id, nomeCompleto, cpf, dataNascimento, telefone, email,
    endereco, numero, complemento, senha, foto)
    {
        Id = id;
        DataAdmissao = dataAdmissao;
        Tipo = tipo;
        Vinculo = vinculo;
    }

    // método de fábrica, ponto de entrada para criar um objeto válido
    public static Colaborador Criar(int id, string nome, string cpf, DateOnly dataNascimento, string telefone, string email, Logradouro endereco, string numero, string complemento, string senha, Arquivo foto, DateOnly dataAdmissao, EnumColaboradorTipo tipo,
    EnumColaboradorVinculo vinculo)
    {
        // Validações e normalizações
        if (NormalizadoService.TextoVazioOuNulo(nome)) throw new DomainException("NOME_OBRIGATORIO");
        nome = NormalizadoService.LimparEspacos(nome);

        if (NormalizadoService.TextoVazioOuNulo(cpf)) throw new DomainException("CPF_OBRIGATORIO");
        cpf = NormalizadoService.LimparEDigitos(cpf);
        if (cpf.Length != 11) throw new DomainException("CPF_DIGITOS");

        if (dataNascimento == default) throw new DomainException("DATA_NASCIMENTO_OBRIGATORIO");
        if (dataNascimento > DateOnly.FromDateTime(DateTime.Today.AddYears(-12))) throw new DomainException("DATA_NASCIMENTO_MINIMA_INVALIDA");

        if (NormalizadoService.TextoVazioOuNulo(telefone)) throw new DomainException("TELEFONE_OBRIGATORIO");
        telefone = NormalizadoService.LimparEDigitos(telefone);
        if (telefone.Length != 11) throw new DomainException("TELEFONE_DIGITOS");

        email = NormalizadoService.LimparEspacos(email);
        if (NormalizadoService.ValidarFormatoEmail(email)) throw new DomainException("EMAIL_FORMATO");

        if (NormalizadoService.TextoVazioOuNulo(senha)) throw new DomainException("SENHA_OBRIGATORIO");
        senha = NormalizadoService.LimparEspacos(senha);
        if (NormalizadoService.ValidarFormatoSenha(senha)) throw new DomainException("SENHA_FORMATO");

        // if (foto == null) throw new DomainException("FOTO_OBRIGATORIO");

        if (endereco == null) throw new DomainException("LOGRADOURO_OBRIGATORIO");

        if (NormalizadoService.TextoVazioOuNulo(numero)) throw new DomainException("NUMERO_OBRIGATORIO");
        numero = NormalizadoService.LimparEspacos(numero);

        complemento = NormalizadoService.LimparEspacos(complemento);

        if (dataAdmissao == default) throw new DomainException("DATA_ADMISSAO_OBRIGATORIO");
        if (dataAdmissao > DateOnly.FromDateTime(DateTime.Today)) throw new DomainException("DATA_ADMISSAO_MAIOR_ATUAL");

        if (!Enum.IsDefined(tipo)) throw new DomainException("TIPO_COLABORADOR_INVALIDO");
        if (!Enum.IsDefined(vinculo)) throw new DomainException("VINCULO_COLABORADOR_INVALIDO");
        if (tipo == EnumColaboradorTipo.Administrador && vinculo == EnumColaboradorVinculo.CLT) throw new DomainException("ADMINISTRADOR_CLT_INVALIDO");

        // Cpf único - vamos depender da persistência dos dados

        // criação e retorno do objeto
        return new Colaborador(id, nome, cpf, dataNascimento, telefone, email, endereco, numero, complemento, senha, foto, dataAdmissao, tipo, vinculo);
    }
}