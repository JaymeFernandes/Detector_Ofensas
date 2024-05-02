using Detector_Ofensas.API;
using Detector_Ofensas.API.Language;
using Detector_Ofensas.DataBase;
using Detector_Ofensas.DataBase.Model;
using SimMetrics.Net.Metric;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Detector_Ofensas.API
{
    /// <summary>
    /// Os comandos privados que a API usa para identificar os textos
    /// </summary>
    public partial class RespectFilter
    {

        #region // Commandos Privado

        private static List<string> SearchForbiddenWords(string Text)
        {
            Text = LinguisticFormatter.ClearSentence(Text);
            string[] parts = Text.ToLower().Split(new char[] { ' ', ',', '.', ';', ':', '-', '_', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            var data = DbService.GetOfensas();


            HashSet<string> detected = new HashSet<string>();

            Parallel.ForEach(parts, part =>
            {
                string palavra = DetectWord(part, data);

                if (!string.IsNullOrEmpty(palavra) && detected.Add(palavra))
                {
					detected.Add(part);
                }
            });

            return detected.ToList();
        }


        private static int CalculatePercentageOfwords(string Text)
        {
            var data = DbService.GetOfensas();
            Text = LinguisticFormatter.ClearSentence(Text);
            string[] parts = Text.ToLower().Split(new char[] { ' ', ',', '.', ';', ':', '-', '_', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            HashSet<string> detected = new HashSet<string>();

            int penaltyPoints = 0;

            Parallel.ForEach(parts, parte =>
            {
                string palavra = DetectWord(parte, data);

                if (!string.IsNullOrEmpty(palavra) && detected.Add(palavra))
                {
					penaltyPoints += data.Where(x => x.word == palavra).Sum(x => x.level);
                }
            });

            return (detected.Count > 0 ? penaltyPoints / detected.Count : penaltyPoints);
        }


        private static string DetectWord(string parte, List<Offense> data)
        {
            string temp = LinguisticFormatter.NormalizeText(parte);
            string result = "";

            if (data.Any(palavra => levenstein.GetSimilarity(palavra.word, parte) > 0.7 || levenstein.GetSimilarity(palavra.word, temp) > 0.7))
            {
                foreach (var ofensa in data)
                {
                    if (jaroWinkler.GetSimilarity(temp, ofensa.word) > Sensibilidade)
                    {
                        result = ofensa.word;
                        break;
                    }

                }
            }

            return result;
        }

        #endregion
    }
}