using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Detector_Ofensas.API
{
    public class ArquivoHandler
    {
        #region // Escrita

        public static void EscreverArquivo(byte[] Dados, string PathFile)
        {

            using (FileStream filesteam = new FileStream(PathFile, FileMode.Create, FileAccess.Write))
            {
                using (BinaryWriter write = new BinaryWriter(filesteam))
                {
                    write.Write(Dados);
                }
            }
        }

        public static void EscreverArquivo(string Dados, string PathFile)
        {
            string diretory = Path.GetDirectoryName(PathFile);

            if (!Directory.Exists(diretory))
            {
                Directory.CreateDirectory(diretory);
            }

            using (StreamWriter writer = new StreamWriter(PathFile, false))
            {
                writer.Write(Dados);
            }
        }

        #endregion

        #region // Leitura

        public static byte[] LerArquivoByte(string PathFile)
        {
            if (!File.Exists(PathFile)) throw new FileNotFoundException("O arquivo passado não existe/Foi excluido!");

            using (FileStream fileStream = new FileStream(PathFile, FileMode.Open, FileAccess.Read))
            {
                using (BinaryReader reader = new BinaryReader(fileStream))
                {
                    byte[] dados = reader.ReadBytes((int)fileStream.Length);

                    if (dados == null || dados.Length != fileStream.Length) throw new IOException($"O arquivo {nameof(PathFile)} não possui informações registradas.");

                    return dados;
                }
            }
        }

        public static string LerArquivo(string PathFile)
        {
            if (!File.Exists(PathFile)) throw new FileNotFoundException("O arquivo passado não existe/Foi excluido!");

            using (FileStream fileStream = new FileStream(PathFile, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader reader = new StreamReader(fileStream))
                {
                    return reader.ReadToEnd();
                }
            }
        }

        #endregion
    }
}
