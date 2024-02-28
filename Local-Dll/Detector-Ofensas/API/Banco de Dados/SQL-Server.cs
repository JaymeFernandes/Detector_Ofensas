using Detector_Ofensas.Api;
using Detector_Ofensas.Api.Language;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Remoting.Contexts;
using Microsoft.EntityFrameworkCore.Design.Internal;
using Microsoft.EntityFrameworkCore.Internal;

namespace Detector_Ofensas.API.Banco_de_Dados
{
    public class SQL_Server
    {
        private static ApplicationDbContext Context;

        public static void Iniciar()
        {
            if(Context == null) Context = new ApplicationDbContext();

            if(Context.PalavrasProibidas.Count() == 0)
            {
                foreach(var temp in PT_BR.language)
                {
                    var ofensa = new Ofensas() { ofensa = temp.Key, nivel = temp.Value };
                    AdicionarValor(ofensa);
                }
            }

            Context.Database.EnsureCreated();
        }

        public static void AdicionarValor(Ofensas ofensa)
        {
            if (Context == null) Iniciar();

            if (!Context.PalavrasProibidas.Contains(ofensa)) Context.PalavrasProibidas.Add(ofensa);
        }

        public static List<Ofensas> GetPalavras()
        {
            return Context.PalavrasProibidas.ToList();
        }
    }



    #region Representação do Banco de Dados

    internal class ApplicationDbContext : DbContext
    {
        public DbSet<Ofensas> PalavrasProibidas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configurar a string de conexão para o seu SQL Server local
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Detector-Ofensa;Integrated Security=True");
        }
    }
    #endregion
}
