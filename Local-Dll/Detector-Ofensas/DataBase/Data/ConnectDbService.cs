using Detector_Ofensas.DataBase.Model;
using MySql.Data;
using MySql.Data.MySqlClient;
using System;
using System.Linq;
using System.Data;

namespace Detector_Ofensas.DataBase
{
    public static partial class DbService
    {
        private static MySqlConnection _connection;

        public static void Connect(string strConnect) 
        {
            try
            {
                if (string.IsNullOrEmpty(strConnect)) throw new ArgumentNullException("Valor nulo passado");

                using (MySqlConnection connection = new MySqlConnection(strConnect))
                {
                    connection.Open();
                    CreateDataBase(connection, "detector_ofensas");
                }

                _connection = new MySqlConnection($"{strConnect}database=detector_ofensas;");
                _connection.Open();
            }
            catch (MySqlException ex)
            {
                throw new ArgumentException($"Erro na conexão com o MySQL: {ex.Message}", ex);
            }
        }


        private static void CreateDataBase(MySqlConnection connection, string dataBaseName)
        {
            try
            {
                // Criar o banco de dados e a tabela
                string createDatabaseQuery =
                    $"CREATE DATABASE IF NOT EXISTS `{dataBaseName}`;" +
                    $"USE `{dataBaseName}`;" +
                    "CREATE TABLE IF NOT EXISTS ofensas (" +
                    "S_ofensa VARCHAR(100) NOT NULL UNIQUE," +
                    "N_nivel INT NOT NULL);";
                using (MySqlCommand command = new MySqlCommand(createDatabaseQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
            catch (MySqlException ex)
            {
                throw new ArgumentException($"Erro ao criar banco de dados ou tabela. Detalhes: {ex.Message}", ex);
            }
        }

    }
}
