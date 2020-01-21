using SiteEmpresarial.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SiteEmpresarial.Db
{
    public class ContatoDb : DbContext
    {
        private static string conexao = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\di3906\Desktop\Unidas_BootCamp\C#\Laboratorios\SiteEmpresarial\SiteEmpresarial\App_Data\EmpresaAbcDb.mdf;Integrated Security=True";

        public ContatoDb() : base(conexao)
        {

        }

        public DbSet<Contato> Contatos { get; set; }
    }
}