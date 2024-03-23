using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Detector_Ofensas.API.Banco_de_dados
{
    public class Ofensas
    {
        public string ofensa { get; set; }
        public int nivel { get; set; }
    }
}
