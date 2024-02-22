using Detector_Ofensas.Api.Language;
using Detector_Ofensas.Api;
using SimMetrics.Net.Metric;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Detector_Ofensas
{
    /// <summary>
    /// Os comandos privados que a API usa para identificar os textos
    /// </summary>
    public partial class FiltroRespeitoso
    { 

        #region // Commandos Privado

        private static List<string> ProcurarPalavrasProibida(string Text)
        {
            Text = FormatadorLinguístico.LimparFrase(Text);
            string[] partes = Text.ToLower().Split(new char[] { ' ', ',', '.', ';', ':', '-', '_', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            List<string> detectadas = new List<string>();

            foreach (string parte in partes)
            {
                if (!detectadas.Contains(parte))
                {
                    string palavra = DetectarPalavra(parte.ToLower());
                    if (DetectarPalavra(parte.ToLower()) != "")
                    {
                        detectadas.Add(parte);
                    }
                }

            }

            return detectadas;
        }


        private static int CalcularPercentual(string Text)
        {
            Text = FormatadorLinguístico.LimparFrase(Text);
            string[] partes = Text.ToLower().Split(new char[] { ' ', ',', '.', ';', ':', '-', '_', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            List<string> detectadas = new List<string>();

            int PontosDePenalidade = 0;

            foreach (string parte in partes)
            {
                if (!detectadas.Contains(parte))
                {
                    string palavra = DetectarPalavra(parte.ToLower());
                    if (DetectarPalavra(parte.ToLower()) != "")
                    {
                        PontosDePenalidade += PalavrasProibidas[palavra];

                        detectadas.Add(parte);
                    }
                }

            }

            return (detectadas.Count > 0 ? PontosDePenalidade / detectadas.Count : PontosDePenalidade);
        }


        private static string DetectarPalavra(string parte)
        {
            string temp = FormatadorLinguístico.NormalizarPalavra(parte);
            string result = "";

            if (PalavrasProibidas.Count == 0) PalavrasProibidas = PalavrasProibidas.Union(PT_BR.language).ToDictionary(x => x.Key, x => x.Value);

            if (PalavrasProibidas.Any(palavra => levenstein.GetSimilarity(palavra.Key, parte) > 0.7 || levenstein.GetSimilarity(palavra.Key, temp) > 0.7))
            {
                foreach (string palavra in PalavrasProibidas.Keys)
                {
                    if (jaroWinkler.GetSimilarity(temp, palavra) > Sensibilidade)
                    {
                        result = palavra;
                        break;
                    }

                }
            }

            return result;
        }

        #endregion
    }
}
