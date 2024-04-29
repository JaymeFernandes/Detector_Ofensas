using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Detector_Ofensas.API
{
    public class LinguisticFormatter
	{
        private readonly static List<string> _remove = new List<string>()
        {
            "a", "o", "e", "é", "de", "do", "da", "dos", "das", "em", "na", "no", "nos", "nas", "um", "uma", "uns", "umas", "por", "para", "com", "como", "se", "mas", "mais", "menos", "ou", "ao", "aos", "à", "às", "onde", "quando", "porque", "que", "quem", "qual", "cujo", "cujos", "cuja", "cujas", "isto", "isso", "aquilo", "mesmo", "mesma", "mesmos", "mesmas", "também", "ainda", "muito", "muita", "muitos", "muitas", "ele", "ela", "eles", "elas", "você", "nós", "vossos", "vosso", "vos", "teu", "tua", "teus", "tuas", "meu", "minha", "meus", "minhas", "seu", "sua", "seus", "suas"
        };

        private readonly static Dictionary<char, char> _symbols = new Dictionary<char, char>()
        {
            { '4', 'a' },
            { '@', 'a' },
            { '8', 'b' },
            { '(', 'c' },
            { '3', 'e' },
            { '€', 'e' },
            { '9', 'g' },
            { '6', 'g' },
            { '#', 'h' },
            { '1', 'i' },
            { '!', 'i' },
            { '|', 'l' },
            { 'Й', 'n' },
            { '0', 'o' },
            { '*', 'o' },
            { '5', 's' },
            { '$', 's' },
            { '7', 't' },
            { '+', 'T' },
            { '2', 'z' },
            { '%', 'z' }
        };

        protected static string NormalizeText(string text)
        {
            text = text.ToLower();
            foreach (var dic in _symbols)
            {
                if (text.EndsWith("!")) text = text.Substring(0, text.Length - 1);

                if (!int.TryParse(text, out int numero))
                {
                    text = text.Replace(dic.Key, dic.Value);
                }
            }

            return text;
        }

        protected static string ClearSentence(string text)
        {
            string[] parts = text.ToLower().Split(new char[] { ' ', ',', '.', ';', ':', '-', '_', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            string result = "";

            foreach (string part in parts)
            {
                if (!_remove.Contains(part))
                {
                    result += $"{part} ";
                }
            }

            return result.Trim();
        }
    }
}
