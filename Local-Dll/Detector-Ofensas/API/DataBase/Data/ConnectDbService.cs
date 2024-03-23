using Detector_Ofensas.DataBase.Model;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Detector_Ofensas.DataBase
{
    public static partial class DbService
    {
        private static MySqlConnection _connection;

        public static void Connect(string strConnect) 
        {
              _connection = new MySqlConnection(strConnect);
              _connection.Open();
        }
    }
}
