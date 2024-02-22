using SimMetrics.Net.Metric;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Detector_Ofensas
{
    public partial class FiltroRespeitoso
    {
        #region variáveis
        public static double Sensibilidade { private get; set; } = 0.93;
        private static JaroWinkler jaroWinkler { get; set; } = new JaroWinkler();
        private static Levenstein levenstein { get; set; } = new Levenstein();
        private static Dictionary<string, int> PalavrasProibidas { get; set; } = new Dictionary<string, int>();

        #endregion
    }
}
