using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Detector_Ofensas.API;
using WebApplication1.Models;

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
		public static async Task<double> GetPercentage(string message, List<Ofensa> data)
        {
			message = message.ToLower();
            if (string.IsNullOrEmpty(message)) return 0;

            var generalScore = await CalculatePercentageOfwords(message, data);

            // Certifique-se de que a porcentagem de ofensa não ultrapasse 100%
            return Math.Min(generalScore, 100);
        }

		/// <summary>
		/// Procura todas a palavras ofensivas
		/// </summary>
		/// <param name="message">menssagem a ser calculada</param>
		/// <returns>uma lista de todas as palavra ofensivas</returns>
		public static async Task<List<string>> CheckText(string message, List<Ofensa> data)
        {
			if (string.IsNullOrEmpty(message)) return null;
			message = message.ToLower();
            
            message = ClearSentence(message);
			var result = await SearchForbiddenWords(message, data);
            return result;
        }

        #endregion
    }
}
