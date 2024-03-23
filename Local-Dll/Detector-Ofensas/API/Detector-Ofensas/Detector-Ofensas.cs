using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Detector_Ofensas.API;
using Detector_Ofensas.DataBase;
using Detector_Ofensas.DataBase.Model;

namespace Detector_Ofensas.API
{
    public partial class RespectFilter : FormatadorLinguístico
    {

        #region Comandos que o usuario pode usar

        /// <summary>
        /// Faz o calculo de quanto o texto é ofensivo em porcentagem
        /// </summary>
        /// <param name="mensagem">menssagem a ser calculada</param>
        /// <returns>Valor de 1 a 100 de quanto foi ofensivo</returns>
        public static double GetPercentage(string mensagem)
        {
            mensagem = mensagem.ToLower();
            if (string.IsNullOrEmpty(mensagem)) return 0;

            int pontuacaoGeral = CalcularPercentual(mensagem);

            // Certifique-se de que a porcentagem de ofensa não ultrapasse 100%
            return Math.Min(pontuacaoGeral, 100);
        }

        /// <summary>
        /// Procura todas a palavras ofensivas
        /// </summary>
        /// <param name="mensagem">menssagem a ser calculada</param>
        /// <returns>uma lista de todas as palavra ofensivas</returns>
        public static List<string> CheckText(string mensagem)
        {
            mensagem = mensagem.ToLower();
            if (string.IsNullOrEmpty(mensagem)) throw new ArgumentNullException(nameof(mensagem), "Foi passa uma menssagem vazia para o algoritimo");

            mensagem = LimparFrase(mensagem);
            return ProcurarPalavrasProibida(mensagem);
        }


        /// <summary>
        /// Carrega todas as palavra ofensivas personalizadas pelo usuario na pasta Language/
        /// </summary>
        public static void LoadCustomWords(List<Offense> ofensas)
        {
            foreach(Offense ofensa in ofensas)
            {
                DbService.AddOfensa(ofensa);
            }
        }
        #endregion
    }
}
