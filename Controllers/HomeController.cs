using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DESAFIO_MVC.Models;
using DESAFIO_MVC.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using DESAFIO_MVC.DTO;
using Microsoft.AspNetCore.Identity;

namespace DESAFIO_MVC.Controllers
{
    public class HomeController : Controller
    {

        private readonly ApplicationDbContext database;
        private readonly ILogger<HomeController> _logger;

        private readonly UserManager<IdentityUser> UserManager;

        private readonly SignInManager<IdentityUser> SignInManager;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext database, UserManager<IdentityUser> User, SignInManager<IdentityUser> SignInManager)
        {
            _logger = logger;
            this.database = database;
            this.UserManager = User;
            this.SignInManager = SignInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult ReceitasHome()
        {
            var categorias = database.Categorias
            .Where(cat => cat.Status == true)
            .AsNoTracking();
            return View(categorias);
        }

        [Authorize]
        public IActionResult ListarReceitas(int id)
        {
            ReceitaDTO receitaDaView = new();
            CategoriaDTO categoriaDaView = new();

            var receitas = database.Receitas
                                            .Where(rec => rec.Status == true && rec.Categoria.Id == id)
                                            .Include(cat => cat.Categoria)
                                            .AsNoTracking();

            return View(receitas);
        }

        [Authorize]
        public IActionResult AcessarReceita(int id)
        {
            var receita = database.Receitas
                                          .Include(cat => cat.Categoria)
                                          .Where(rec => rec.Id == id)
                                          .FirstOrDefault();

            receita.Ingrediente = StringReplace(receita.Ingrediente);
            receita.ModoDePreparo = StringReplace(receita.ModoDePreparo);

            HistoricoAcesso historicoAcesso = new();

            if (SignInManager.IsSignedIn(User))
            {
                historicoAcesso.Usuario = User.Identity.Name;
                historicoAcesso.Receita = database.Receitas.First(rec => rec.Id == id);
                historicoAcesso.DataAcesso = DateTime.UtcNow;
            }

            database.HistoricoAcessos.Add(historicoAcesso);
            database.SaveChanges();

            return View(receita);
        }

        public string StringReplace(string texto)
        {
            return $"{texto.Replace("\n", "<br>")}";
        }

    }
}
