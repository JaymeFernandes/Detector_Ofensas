using Detector_Ofensas.API;
using SimMetrics.Net.Metric;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace Detector_Ofensas.API
{
    /// <summary>
    /// Os comandos privados que a API usa para identificar os textos
    /// </summary>
    public partial class RespectFilter
    {

        #region // Commandos Privado

        private static async Task<List<string>> SearchForbiddenWords(string Text, List<Ofensa> data)
        {

            Text = LinguisticFormatter.ClearSentence(Text);
            string[] parts = Text.ToLower().Split(new char[] { ' ', ',', '.', ';', ':', '-', '_', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);



            var temp = parts.Select(parte => DetectWord(parte, data)).ToList();

			await Task.WhenAll(temp);

            var result = temp.Select(x => x.Result).Where(x => !string.IsNullOrEmpty(x)).ToList();

            return result;
        }


        private static async Task<int> CalculatePercentageOfwords(string Text, List<Ofensa> data)
        {
            Text = LinguisticFormatter.ClearSentence(Text);
            string[] parts = Text.ToLower().Split(new char[] { ' ', ',', '.', ';', ':', '-', '_', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            HashSet<string> detected = new HashSet<string>();

            int penaltyPoints = 0;

			var words = parts.Select(parte => DetectWord(parte, data));

            foreach(var part in words)
            {
				if (!string.IsNullOrEmpty(part.Result) && detected.Add(part.Result))
				{
					penaltyPoints += data.Where(x => x.SOfensa == part.Result).Sum(x => x.NNivel);
				}
			}

			return (detected.Count > 0 ? penaltyPoints / detected.Count : penaltyPoints);
        }


        private static async Task<string> DetectWord(string parte, List<Ofensa> data)
        {
			string temp = LinguisticFormatter.NormalizeText(parte);
			string result = "";

			if (data.Any(palavra => levenstein.GetSimilarity(palavra.SOfensa, parte) > 0.7 || levenstein.GetSimilarity(palavra.SOfensa, temp) > 0.7))
			{
				foreach (var ofensa in data)
				{
					if (jaroWinkler.GetSimilarity(temp, ofensa.SOfensa) > Sensibilidade)
					{
						result = ofensa.SOfensa;
						break;
					}

				}
			}
			return result;
		}

        #endregion
    }
}