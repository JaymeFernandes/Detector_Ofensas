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
		/// Calculates the percentage of offensiveness in a text message.
		/// </summary>
		/// <param name="message">The message to be evaluated.</param>
		/// <returns>A value from 1 to 100 indicating the level of offensiveness.</returns>
		public static async Task<double> GetPercentage(string message, List<Ofensa> data)
        {
			message = message.ToLower();
            if (string.IsNullOrEmpty(message)) return 0;

            var generalScore = await CalculatePercentageOfwords(message, data);

            // Certifique-se de que a porcentagem de ofensa não ultrapasse 100%
            return Math.Min(generalScore, 100);
        }

		/// <summary>
		/// Finds all offensive words in the given message.
		/// </summary>
		/// <param name="message">The message to be searched.</param>
		/// <returns>A list of all offensive words found in the message.</returns>
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
