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
    public partial class FiltroRespeitoso
    {

        #region // Commandos Privado

        private static List<string> ProcurarPalavrasProibida(string Text)
        {
            Text = FormatadorLinguístico.LimparFrase(Text);
            string[] partes = Text.Split(new char[] { ' ', ',', '.', ';', ':', '-', '_', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            List<string> detectadas = new List<string>();

            foreach (string parte in partes)
            {
                if (!detectadas.Contains(parte))
                {
                    if (DetectarPalavra(parte) != "")
                    {
                        detectadas.Add(parte);
                    }
                }

            }

            return detectadas;
        }


        private static int CalcularPercentual(string Text)
        {
            var data = DbService.GetOfensas();
            Text = FormatadorLinguístico.LimparFrase(Text);
            string[] partes = Text.Split(new char[] { ' ', ',', '.', ';', ':', '-', '_', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            List<string> detectadas = new List<string>();

            int PontosDePenalidade = 0;

            foreach (string parte in partes)
            {
                if (!detectadas.Contains(parte))
                {
                    string palavra = DetectarPalavra(parte);
                    if (palavra != "")
                    {
                        PontosDePenalidade += data.Where(x => x.palavra == palavra).Sum(x => x.nivel);

                        detectadas.Add(parte);
                    }
                }

            }

            return (detectadas.Count > 0 ? PontosDePenalidade / detectadas.Count : PontosDePenalidade);
        }


        private static string DetectarPalavra(string parte)
        {
            string temp = FormatadorLinguístico.NormalizarPalavra(parte);
            var data = DbService.GetOfensas();
            string result = "";

            if (DbService.OfensasCout() == 0)
            {
                foreach(var ofensa in PT_BR.language)
                {
                    DbService.AddOfensa(new Ofensa() { palavra = ofensa.Key, nivel = ofensa.Value });
                }
            }

            if (data.Any(palavra => levenstein.GetSimilarity(palavra.palavra, parte) > 0.7 || levenstein.GetSimilarity(palavra.palavra, temp) > 0.7))
            {
                foreach (var ofensa in data)
                {
                    if (jaroWinkler.GetSimilarity(temp, ofensa.palavra) > Sensibilidade)
                    {
                        result = ofensa.palavra;
                        break;
                    }

                }
            }

            return result;
        }

        #endregion
    }
}