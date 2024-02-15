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

        private static List<string> ProcurarPalavrasProibida(string Text, out int PontosDePenalidade)
        {
            Text = FormatadorLinguístico.LimparFrase(Text);
            string[] partes = Text.Split(new char[] { ' ', ',', '.', ';', ':', '-', '_', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            List<string> detectadas = new List<string>();

            PontosDePenalidade = 0;

            foreach (string parte in partes)
            {
                if (!detectadas.Contains(parte))
                {
                    int porcentagem = 0;
                    if (DetectarPalavra(parte.ToLower(), out porcentagem))
                    {
                        PontosDePenalidade += porcentagem;

                        detectadas.Add(parte);
                    }
                }

            }

            if (detectadas.Count > 0)
            {
                PontosDePenalidade = PontosDePenalidade / detectadas.Count;
            }

            return detectadas;
        }

        private static bool DetectarPalavra(string parte, out int porcentagem)
        {
            string temp = FormatadorLinguístico.NormalizarPalavra(parte);
            bool result = false;
            porcentagem = 0;

            if (PalavrasProibidas.Count == 0)
            {
                PalavrasProibidas = PalavrasProibidas.Union(PT_BR.language).ToDictionary(x => x.Key, x => x.Value);
            }

            if (PalavrasProibidas.Any(palavra => levenstein.GetSimilarity(palavra.Key, parte) > 0.7 || levenstein.GetSimilarity(palavra.Key, temp) > 0.7))
            {
                foreach (string palavra in PalavrasProibidas.Keys)
                {
                    if (jaroWinkler.GetSimilarity(temp, palavra) > 0.93)
                    {
                        porcentagem = PalavrasProibidas[palavra];
                        result = true;

                        break;
                    }

                }
            }

            return result;
        }

        #endregion
    }
}
