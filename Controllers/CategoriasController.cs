using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DESAFIO_MVC.Data;
using DESAFIO_MVC.DTO;
using DESAFIO_MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DESAFIO_MVC.Controllers
{
    public class CategoriasController : Controller
    {
        private readonly ApplicationDbContext database;
        public CategoriasController(ApplicationDbContext database)
        {
            this.database = database;
        }

        public IActionResult GerenciarCategorias()
        {
            var categorias = database.Categorias
            .Where(cat => cat.Status == true)
            .AsNoTracking();

            return View(categorias);
        }

        public IActionResult NovaCategoria()
        {
            return View();
        }

        public IActionResult AtualizarCategoria(int id)
        {
            var categoria = database.Categorias
            .AsNoTracking()
            .Where(cat => cat.Id == id)
            .FirstOrDefault();

            CategoriaDTO categoriaView = new();
            categoriaView.Id = categoria.Id;
            categoriaView.Nome = categoria.Nome;
            categoriaView.Imagem = categoria.Imagem;

            return View(categoriaView);
        }

        [HttpPost]
        public IActionResult Salvar(CategoriaDTO categoriaTemporaria)
        {
            if (ModelState.IsValid)
            {
                Categoria categoria = new();
                categoria.Nome = categoriaTemporaria.Nome;
                categoria.Imagem = categoriaTemporaria.Imagem;
                categoria.Status = true;

                database.Categorias.Add(categoria);
                database.SaveChanges();

                return RedirectToAction("GerenciarCategorias", "Categorias");
            }
            else
            {
                return RedirectToAction("GerenciarCategorias", "Categorias");
            }
        }

        [HttpPost]
        public IActionResult Atualizar(CategoriaDTO categoriaTemporaria)
        {
            if (ModelState.IsValid)
            {
                var categoria = database.Categorias
                .Where(cat => cat.Id == categoriaTemporaria.Id)
                .FirstOrDefault();

                categoria.Nome = categoriaTemporaria.Nome;
                categoria.Imagem = categoriaTemporaria.Imagem;
                database.SaveChanges();

                return RedirectToAction("GerenciarCategorias", "Categorias");
            }
            else
            {
                return RedirectToAction("GerenciarCategorias", "Categorias");
            }
        }

        [HttpPost]
        public IActionResult Deletar(int id)
        {
            if (id > 0)
            {
                var categoria = database.Categorias
                .Where(cat => cat.Id == id)
                .FirstOrDefault();

                categoria.Status = false;
                database.SaveChanges();
            }
            return RedirectToAction("GerenciarCategorias", "Categorias");
        }
    }
}