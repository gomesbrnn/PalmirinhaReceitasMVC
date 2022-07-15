using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DESAFIO_MVC.Models;
using DESAFIO_MVC.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace DESAFIO_MVC.Controllers
{
    // [Authorize(Policy = "AdminRole")]
    [Authorize(Roles = "Admin")]
    public class GerenciamentoController : Controller
    {
        private readonly ApplicationDbContext database;

        public GerenciamentoController(ApplicationDbContext database)
        {
            this.database = database;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}