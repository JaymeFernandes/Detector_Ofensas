using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimMetrics.Net;
using SimMetrics.Net.Metric;
using Detector_Ofensas.Api.Modules;
using Detector_Ofensas.Api;
using Detector_Ofensas.Api.Language;

namespace Detector_Ofensas
{
    /// <summary>
    /// Class com os comandos publicos
    /// </summary>
    public partial class FiltroRespeitoso : FormatadorLinguístico
    {

        #region Comandos que o usuario pode usar

        /// <summary>
        /// Faz o calculo de quanto o texto é ofensivo em porcentagem
        /// </summary>
        /// <param name="mensagem">menssagem a ser calculada</param>
        /// <returns>Valor de 1 a 100 de quanto foi ofensivo</returns>
        public static double ObterPercentual(string mensagem)
        {
            if(string.IsNullOrEmpty(mensagem)) return 0;

            int pontuacaoGeral = CalcularPercentual(mensagem);

            // Certifique-se de que a porcentagem de ofensa não ultrapasse 100%
            return Math.Min(pontuacaoGeral, 100);
        }

        /// <summary>
        /// Procura todas a palavras ofensivas
        /// </summary>
        /// <param name="mensagem">menssagem a ser calculada</param>
        /// <returns>uma lista de todas as palavra ofensivas</returns>
        public static List<string> VerificarTexto(string mensagem)
        {
            if (string.IsNullOrEmpty(mensagem)) throw new ArgumentNullException(nameof(mensagem), "Foi passa uma menssagem vazia para o algoritimo");

            mensagem = LimparFrase(mensagem);
            return ProcurarPalavrasProibida(mensagem);
        }

        /// <summary>
        /// Carrega todas as palavra ofensivas personalizadas pelo usuario na pasta Language/
        /// </summary>
        public static void CarregarPalavrasPersonalizadas()
        {
            if (Directory.Exists("Language/"))
            {
                string[] arquivos = Directory.GetFiles("Language/", "*.json");

                foreach (string arquivo in arquivos)
                {
                    string temp = ArquivoHandler.LerArquivo(arquivo);
                    Dictionary<string, int> language = JSON.ConvertObject(temp);
                    PalavrasProibidas = PalavrasProibidas.Union(language).Where(X => !PalavrasProibidas.ContainsKey(X.Key.ToLower())).ToDictionary(x => x.Key.ToLower(), x => x.Value);
                }
            }
            else
            {
                Directory.CreateDirectory("Language/");
            }
        }

        #endregion
    }
}
