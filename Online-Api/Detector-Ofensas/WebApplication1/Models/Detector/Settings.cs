using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimMetrics.Net.Metric;

namespace Detector_Ofensas.API
{
    public partial class RespectFilter
    {
		#region Variables

		public static double Sensibilidade { private get; set; } = 0.93;
        private static JaroWinkler jaroWinkler { get; set; } = new JaroWinkler();
        private static Levenstein levenstein { get; set; } = new Levenstein();

        #endregion
    }
}
