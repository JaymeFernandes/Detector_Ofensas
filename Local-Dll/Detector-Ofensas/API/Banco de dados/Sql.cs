using Detector_Ofensas.API.Language;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Detector_Ofensas.API.Banco_de_dados
{
    public class SQL_Server
    {
        private static ApplicationDbContext Context;

        public static void Iniciar()
        {
            if (Context == null) Context = new ApplicationDbContext();

            if (Context.PalavrasProibidas.Count() == 0)
            {
                foreach (var temp in PT_BR.language)
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ofensas>().HasNoKey();
        }
    }
    #endregion
}
