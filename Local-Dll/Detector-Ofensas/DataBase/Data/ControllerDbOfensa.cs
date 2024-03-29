﻿using Detector_Ofensas.API.Language;
using Detector_Ofensas.DataBase.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace Detector_Ofensas.DataBase
{
    public static partial class DbService
    {
        private static bool OfensaExists(string palavra)
        {
            string quary = "SELECT count(*) FROM detector_ofensas.Ofensas WHERE S_ofensa = @ofensa;";

            using(MySqlCommand command = new MySqlCommand(quary, _connection))
            {
                command.Parameters.AddWithValue("@ofensa", palavra);

                int result = Convert.ToInt32(command.ExecuteScalar());

                return result > 0;
            }
        }

        public static int OfensasCout()
        {
            string quary = "SELECT count(*) FROM detector_ofensas.Ofensas;";
            int result = 0;

            using(MySqlCommand command = new MySqlCommand(quary, _connection))
            {
                result = Convert.ToInt32(command.ExecuteScalar());
            }

            return result;
        }


        public static void AddOfensa(Offense ofensa)
        {
            if (string.IsNullOrEmpty(ofensa.word) || ofensa.level < 0 || ofensa.level > 100)
            {
                throw new ArgumentException($"Valores passados inválidos ({ofensa?.word} ou {ofensa?.level})");
            }

            if (OfensaExists(ofensa.word.ToLower())) return;

            string quary = "INSERT into detector_ofensas.Ofensas values (@Palavra, @Nivel);";

            using(MySqlCommand command = new MySqlCommand(quary, _connection))
            {
                command.Parameters.AddWithValue("@Palavra", ofensa.word.ToLower());
                command.Parameters.AddWithValue("@Nivel", ofensa.level);
                command.ExecuteNonQuery();
            }
        }


        public static List<Offense> GetOfensas()
        {

            if (DbService.OfensasCout() == 0)
            {
                foreach (var ofensa in PT_BR.language)
                {
                    DbService.AddOfensa(new Offense() { word = ofensa.Key, level = ofensa.Value });
                }
            }

            var result = new List<Offense>();

            string quary = "SELECT S_ofensa, N_nivel FROM detector_ofensas.Ofensas;";

            using(MySqlCommand command = new MySqlCommand(quary, _connection))
            {
                using(MySqlDataReader render = command.ExecuteReader())
                {
                    while(render.Read())
                    {
                        string palavra = render["S_ofensa"].ToString();
                        int nivel = Convert.ToInt32(render["N_nivel"]);

                        result.Add(new Offense() { word = palavra, level = nivel });
                    }
                }
            }

            return result;
        }
    }
}
