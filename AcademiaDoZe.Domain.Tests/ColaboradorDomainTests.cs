//Marcos Vinicius Arruda Vandresen
using AcademiaDoZe.Dominio.Entities;
using AcademiaDoZe.Dominio.Exceptions;
using AcademiaDoZe.Dominio.ValueObject;

namespace AcademiaDoZe.Dominio.Tests;

public class ColaboradorDomainTests
{
    private Logradouro GetValidLogradouro() => Logradouro.Criar(1, "12345678", "Rua A", "Centro", "Cidade", "SP", "Brasil");
    private Arquivo GetValidArquivo() => Arquivo.Criar(new byte[1]);

    [Fact]
    public void CriarColaborador_ComDadosValidos_DeveCriarObjeto()
    {
        // Arrange
        var id = 1; var nome = "João da Silva"; var cpf = "12345678901"; var dataNascimento = DateOnly.FromDateTime(DateTime.Today.AddYears(-20)); var telefone = "11999999999";
        var email = "joao@email.com"; var logradouro = GetValidLogradouro(); var numero = "123"; var complemento = "Apto 1"; var senha = "Senha@1"; var foto = GetValidArquivo();
        var dataAdmissao = DateOnly.FromDateTime(DateTime.Today.AddDays(-1)); // ontem, data válida menor ou igual hoje
        var tipo = Dominio.Enums.EnumColaboradorTipo.Administrador; 
        var vinculo = Dominio.Enums.EnumColaboradorVinculo.CLT;
        // Act
        var colaborador = Colaborador.Criar(id, nome, cpf, dataNascimento, telefone, email, logradouro, numero, complemento, senha, foto, dataAdmissao, tipo, vinculo);
        // Assert
        Assert.NotNull(colaborador);
    }

    [Fact]
    public void CriarColaborador_ComNomeVazio_DeveLancarExcecao()
    {
        // Aqui passamos o nome vazio para lançar a exceção "NOME_OBRIGATORIO"
        var exception = Assert.Throws<DomainException>(() => Colaborador.Criar(
            1,
            "", // nome inválido
            "111.111.111-11",
            DateOnly.MinValue,
            "11999999999",
            "Teste@gmail.com",
            GetValidLogradouro(),
            "44",
            "casa",
            "senha123",
            GetValidArquivo(),
            DateOnly.MaxValue,
            Dominio.Enums.EnumColaboradorTipo.Administrador,
            Dominio.Enums.EnumColaboradorVinculo.Estagio
        ));
        Assert.Equal("NOME_OBRIGATORIO", exception.Message);
    }
}