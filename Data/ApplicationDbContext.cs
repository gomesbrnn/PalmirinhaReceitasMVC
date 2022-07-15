using System;
using System.Collections.Generic;
using System.Text;
using DESAFIO_MVC.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DESAFIO_MVC.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Receita> Receitas { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<HistoricoAcesso> HistoricoAcessos { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
