﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Detector_Ofensas.Api
{
    public class FormatadorLinguístico
    {
        private static List<string> _remove = new List<string>() { "a", "e", "o", "ou", "é" };
        private static Dictionary<char, char> simbolos = new Dictionary<char, char>()
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

        protected static string NormalizarPalavra(string texto)
        {

            foreach (var dic in simbolos)
            {
                if(texto.EndsWith("!")  || texto.EndsWith("?")) texto = texto.Substring(0, texto.Length - 1);

                if (!int.TryParse(texto, out int numero))
                {
                    texto = texto.Replace(dic.Key, dic.Value);
                }
            }

            return texto;
        }

        protected static string LimparFrase(string texto)
        {
            string[] partes = texto.Split(new char[] { ' ', ',', '.', ';', ':', '-', '_', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            string resultado = "";

            foreach(string parte in partes)
            {
                if(!_remove.Contains(parte))
                {
                    resultado += $"{parte} ";
                }
            }

            return resultado.Trim();
        }
    }
}
