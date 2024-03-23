using Detector_Ofensas.DataBase.Model;
using MySql.Data.MySqlClient;
using System.Data.Common;

namespace Detector_Ofensas.DataBase
{
    public static partial class DbService
    {
        private static bool OfensaExists(string palavra)
        {
            string quary = "SELECT count(*) FROM detector_ofensas.Ofensas WHERE S_ofensa = @ofensa;";

            using(MySqlCommand _command = new MySqlCommand(quary, _connection))
            {
                _command.Parameters.AddWithValue("@ofensa", palavra);

                int result = Convert.ToInt32(_command.ExecuteScalar());

                return result > 0;
            }
        }

        public static int OfensasCout()
        {
            string quary = "SELECT count(*) FROM detector_ofensas.Ofensas;";
            int result = 0;

            using(MySqlCommand _command = new MySqlCommand(quary, _connection))
            {
                result = Convert.ToInt32(_command.ExecuteScalar());
            }

            return result;
        }


        public static void AddOfensa(Ofensa ofensa)
        {
            if (OfensaExists(ofensa.palavra.ToLower())) return;

            string quary = "INSERT into detector_ofensas.Ofensas values (@Palavra, @Nivel);";

            using(MySqlCommand _command = new MySqlCommand(quary, _connection))
            {
                _command.Parameters.AddWithValue("@Palavra", ofensa.palavra.ToLower());
                _command.Parameters.AddWithValue("@Nivel", ofensa.nivel);
                _command.ExecuteNonQuery();
            }
        }


        public static List<Ofensa> GetOfensas()
        { 

            var result = new List<Ofensa>();

            string quary = "SELECT S_ofensa, N_nivel FROM detector_ofensas.Ofensas;";

            using(MySqlCommand _command = new MySqlCommand(quary, _connection))
            {
                using(MySqlDataReader _render = _command.ExecuteReader())
                {
                    while(_render.Read())
                    {
                        string palavra = _render["S_ofensa"].ToString();
                        int nivel = Convert.ToInt32(_render["N_nivel"]);

                        result.Add(new Ofensa() { palavra = palavra, nivel = nivel });
                    }
                }
            }

            return result;
        }
    }
}
