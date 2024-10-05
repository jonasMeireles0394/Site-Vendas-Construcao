using Npgsql;
using System;
using System.Data;

namespace SiteVendasConstrucao.Uteis
{
    public class DAL
    {
        private static string Server = "localhost";
        private static string Port = "5432";
        private static string Database = "Teste";
        private static string User = "postgres";
        private static string Password = "x4ZvPSxGORXBqNP";
        private static string ConnectionString = $"Server={Server};Port={Port};Database={Database};User Id={User};Password={Password};";

        // Método para obter conexão
        private NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(ConnectionString);
        }

        // Método de consulta
        public DataTable ExecutarConsulta(string sql)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var Command = new NpgsqlCommand(sql, connection))
                {
                    using (var da = new NpgsqlDataAdapter(Command))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        // Método de inserção
        public int ExecutarComando(string sql)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var Command = new NpgsqlCommand(sql, connection))
                {
                    return Command.ExecuteNonQuery(); // Retorna o número de linhas afetadas
                }
            }
        }

        // Método para executar consultas parametrizadas (opcional)
        public DataTable ExecutarConsultaParametrizada(string sql, NpgsqlParameter[] parametros)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var Command = new NpgsqlCommand(sql, connection))
                {
                    Command.Parameters.AddRange(parametros);
                    using (var da = new NpgsqlDataAdapter(Command))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        // Método de atualização
        public int ExecutarAtualizacao(string sql, NpgsqlParameter[] parametros)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var Command = new NpgsqlCommand(sql, connection))
                {
                    Command.Parameters.AddRange(parametros);
                    return Command.ExecuteNonQuery(); // Retorna o número de linhas afetadas
                }
            }
        }
    }
}
