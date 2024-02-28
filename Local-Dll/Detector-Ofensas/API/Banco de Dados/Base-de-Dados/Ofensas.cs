using Detector_Ofensas.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Remoting.Contexts;

namespace Detector_Ofensas.API.Banco_de_Dados
{

    public class Ofensas
    {
        public string ofensa { get; set; }
        public int nivel { get; set; }
    }
}
