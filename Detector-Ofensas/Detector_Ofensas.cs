using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimMetrics.Net;
using SimMetrics.Net.Metric;
using Detector_Ofensas.Modules;
using Detector_Ofensas.Api;
using Detector_Ofensas.Api.Language;

namespace Detector_Ofensas
{
    /// <summary>
    /// Class com os comandos publicos
    /// </summary>
    public partial class FiltroRespeitoso : FormatadorLinguístico
    {
        #region variáveis

        protected static JaroWinkler jaroWinkler = new JaroWinkler();
        protected static Levenstein levenstein = new Levenstein();
        protected static Dictionary<string, int> PalavrasProibidas = new Dictionary<string, int>();

        #endregion

        // Comandos que o usuario pode usar
        public static double ObterPercentual(string mensagem)
        {
            int pontuacaoGeral;

            ProcurarPalavrasProibida(mensagem, out pontuacaoGeral);


            // Certifique-se de que a porcentagem de ofensa não ultrapasse 100%
            return Math.Min(pontuacaoGeral, 100);
        }

        public static List<string> VerificarTexto(string Text)
        {
            string[] partes = Text.Split(new char[] { ' ', ',', '.', ';', ':', '-', '_', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            List<string> detectadas = new List<string>();

            foreach (string parte in partes)
            {
                if (!detectadas.Contains(parte))
                {
                    int porcentagem = 0;
                    if (DetectarPalavra(parte.ToLower(), out porcentagem))
                    {
                        detectadas.Add(parte);
                    }
                }

            }

            return detectadas;
        }

        public static void CarregarPalavrasPerosnalizada()
        {
            if (Directory.Exists("Language/"))
            {
                string[] arquivos = Directory.GetFiles("Language/", "*.json");

                foreach(string arquivo in arquivos)
                {
                    string temp = ArquivoHandler.LerArquivo(arquivo);
                    Dictionary<string, int> language = JSON.ConvertObject(temp);
                    PalavrasProibidas = PalavrasProibidas.Union(language).Where(X => !PalavrasProibidas.ContainsKey(X.Key)).ToDictionary(x => x.Key, x => x.Value);
                }
            }
            else
            {
                Directory.CreateDirectory("Language/");
            }
        }
    }
}
