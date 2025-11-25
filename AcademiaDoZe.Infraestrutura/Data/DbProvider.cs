//Marcos Vinicius Arruda Vandresen
using AcademiaDoZe.Infraestrutura.Exceptions;
using MySql.Data.MySqlClient;
using System.Data;
using System.Data.Common;
namespace AcademiaDoZe.Infraestrutura.Data
{
    public enum DatabaseType { MySql }
    public static class DbProvider
    {
        // Timeout padrão de 30 segundos para todos os comandos
        public const int DefaultCommandTimeout = 30;
        public static DbConnection CreateConnection(string connectionString, DatabaseType dbType)
        {
            try
            {
                DbConnection connection = dbType switch
                {
                    DatabaseType.MySql => new MySqlConnection(connectionString),
                    _ => throw new InfraestruturaException($"SGDB_NAO_SUPORTADO {dbType}")
                };
                if (connection == null) throw new InfraestruturaException($"FALHA_CONEXAO {dbType}");
                return connection;
            }
            catch (DbException ex) { throw new InfraestruturaException($"FALHA_CONEXAO {dbType}", ex); }
        }
        public static DbCommand CreateCommand(string commandText, DbConnection connection, CommandType commandType = CommandType.Text)
        {
            if (connection == null) { throw new ArgumentNullException($"COMMAND_CONEXAO_NULL"); }
            if (string.IsNullOrWhiteSpace(commandText)) { throw new ArgumentException($"COMMAND_TEXT_VAZIO"); }
            try
            {
                var command = connection.CreateCommand() ?? throw new InfraestruturaException("FALHA_CRIAR_COMANDO");
                command.CommandText = commandText;
                command.CommandType = commandType;
                command.CommandTimeout = DefaultCommandTimeout;
                return command;
            }
            catch (DbException ex) { throw new InfraestruturaException($"FALHA_CRIAR_COMANDO", ex); }
        }
        public static DbParameter CreateParameter(string name, object value, DbType dbType, DatabaseType databaseType)
        {
            if (string.IsNullOrWhiteSpace(name)) { throw new ArgumentException($"PARAMETER_VAZIO"); }
            try
            {
                DbParameter parameter = databaseType switch
                {
                    DatabaseType.MySql => new MySqlParameter(),
                    _ => throw new InfraestruturaException($"SGDB_NAO_SUPORTADO {databaseType}")
                };
                parameter.ParameterName = name;
                parameter.Value = value ?? DBNull.Value;
                parameter.DbType = dbType;
                return parameter;
            }
            catch (DbException ex) { throw new InfraestruturaException($"ERRO_CRIAR_PARAMETRO", ex); }
        }
    }
}