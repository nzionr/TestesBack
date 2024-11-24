using Microsoft.EntityFrameworkCore;
using ProjetoP2.Models;
using System.Collections.Generic;

namespace ProjetoP2.Contexto
{
    public class RoletaContextMySQL : DbContext
    {
        //Para gerar as tabelas na aplicação ir até o console do Gerenciado de pacotes (Ferramentas):
        //dar op comando (no console) Add-Migration inicial

        //Para gerar o banco com as tabelas:
        //dar o comando Update-Database

        public RoletaContextMySQL(DbContextOptions<RoletaContextMySQL> context) : base(context)
        {
        }

        public DbSet<Premios> Premios { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Camisas> Camisas { get; set; }
    }
}