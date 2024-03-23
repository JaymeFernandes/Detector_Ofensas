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

        private static List<string> ProcurarPalavrasProibida(string Text)
        {
            Text = FormatadorLinguístico.LimparFrase(Text);
            string[] partes = Text.ToLower().Split(new char[] { ' ', ',', '.', ';', ':', '-', '_', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            var data = DbService.GetOfensas();


            HashSet<string> detectadas = new HashSet<string>();

            Parallel.ForEach(partes, parte =>
            {
                string palavra = DetectarPalavra(parte, data);

                if (!string.IsNullOrEmpty(palavra) && detectadas.Add(palavra))
                {
                    detectadas.Add(parte);
                }
            });

            return detectadas.ToList();
        }


        private static int CalcularPercentual(string Text)
        {
            var data = DbService.GetOfensas();
            Text = FormatadorLinguístico.LimparFrase(Text);
            string[] partes = Text.ToLower().Split(new char[] { ' ', ',', '.', ';', ':', '-', '_', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            HashSet<string> detectadas = new HashSet<string>();

            int PontosDePenalidade = 0;

            Parallel.ForEach(partes, parte =>
            {
                string palavra = DetectarPalavra(parte, data);

                if (!string.IsNullOrEmpty(palavra) && detectadas.Add(palavra))
                {
                    PontosDePenalidade += data.Where(x => x.word == palavra).Sum(x => x.level);
                }
            });

            return (detectadas.Count > 0 ? PontosDePenalidade / detectadas.Count : PontosDePenalidade);
        }


        private static string DetectarPalavra(string parte, List<Offense> data)
        {
            string temp = FormatadorLinguístico.NormalizarPalavra(parte);
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