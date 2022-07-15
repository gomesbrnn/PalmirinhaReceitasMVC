using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DESAFIO_MVC.Data;
using DESAFIO_MVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DESAFIO_MVC.Controllers
{
    public class HistoricoAcessosController : Controller
    {
        private readonly ApplicationDbContext database;
        private readonly UserManager<IdentityUser> UserManager;

        private readonly SignInManager<IdentityUser> SignInManager;

        public HistoricoAcessosController(ApplicationDbContext database, UserManager<IdentityUser> User, SignInManager<IdentityUser> SignInManager)
        {
            this.database = database;
            this.UserManager = User;
            this.SignInManager = SignInManager;
        }

        public IActionResult VisualizarAcessos()
        {
            var historicoAcesso = database.HistoricoAcessos
                                                         .Include(rec => rec.Receita)
                                                         .AsNoTracking();

            return View(historicoAcesso);
        }
    }
}