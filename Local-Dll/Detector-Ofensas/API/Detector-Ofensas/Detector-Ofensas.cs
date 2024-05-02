using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Detector_Ofensas.API;
using Detector_Ofensas.DataBase;
using Detector_Ofensas.DataBase.Model;

namespace Detector_Ofensas.API
{
    public partial class RespectFilter : LinguisticFormatter
    {

		#region Comandos que o usuario pode usar

		/// <summary>
		/// Faz o calculo de quanto o texto é ofensivo em porcentagem
		/// </summary>
		/// <param name="message">menssagem a ser calculada</param>
		/// <returns>Valor de 1 a 100 de quanto foi ofensivo</returns>
		public static double GetPercentage(string mensage)
        {
            mensage = mensage.ToLower();
            if (string.IsNullOrEmpty(mensage)) return 0;

            int generalScore = CalculatePercentageOfwords(mensage);

            // Certifique-se de que a porcentagem de ofensa não ultrapasse 100%
            return Math.Min(generalScore, 100);
        }

        /// <summary>
        /// Procura todas a palavras ofensivas
        /// </summary>
        /// <param name="mensage">menssagem a ser calculada</param>
        /// <returns>uma lista de todas as palavra ofensivas</returns>
        public static List<string> CheckText(string mensage)
        {
            mensage = mensage.ToLower();
            if (string.IsNullOrEmpty(mensage)) throw new ArgumentNullException(nameof(mensage), "Foi passa uma menssagem vazia para o algoritimo");

            mensage = ClearSentence(mensage);
            return SearchForbiddenWords(mensage);
        }


        /// <summary>
        /// Carrega todas as palavra ofensivas personalizadas pelo usuario na pasta Language/
        /// </summary>
        public static void LoadCustomWords(List<Offense> offenses)
        {
            foreach(Offense offense in offenses)
            {
                DbService.AddOfensa(offense);
            }
        }
        #endregion
    }
}
