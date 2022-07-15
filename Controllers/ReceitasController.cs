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

    public class ReceitasController : Controller
    {
        private readonly ApplicationDbContext database;
        public ReceitasController(ApplicationDbContext database)
        {
            this.database = database;
        }

        public IActionResult GerenciarReceitas()
        {
            var receitas = database.Receitas
                           .Where(rec => rec.Status == true)
                           .Include(cat => cat.Categoria)
                           .AsNoTracking();

            return View(receitas);
        }

        public IActionResult NovaReceita()
        {
            ViewBag.Categorias = database.Categorias
                                .Where(cat => cat.Status == true)
                                .AsNoTracking();
            return View();
        }

        public IActionResult AtualizarReceita(int id)
        {
            var receita = database.Receitas
                                           .Include(cat => cat.Categoria)
                                           .Where(rec => rec.Id == id)
                                           .FirstOrDefault();

            ReceitaDTO receitaDaView = new();
            receitaDaView.Nome = receita.Nome;
            receitaDaView.CategoriaId = receita.Categoria.Id;
            receitaDaView.Imagem = receita.Imagem;
            receitaDaView.TempoDePreparo = receita.TempoDePreparo;
            receitaDaView.QtdPorcao = receita.QtdPorcao;
            receitaDaView.Dificuldade = receita.Dificuldade;
            receitaDaView.Descricao = receita.Descricao;
            receitaDaView.Ingrediente = receita.Ingrediente;
            receitaDaView.ModoDePreparo = receita.ModoDePreparo;

            ViewBag.Categorias = database.Categorias
                                .Where(cat => cat.Status == true)
                                .AsNoTracking();

            return View(receitaDaView);
        }

        [HttpPost]
        public IActionResult Salvar(ReceitaDTO receitaDaView)
        {
            if (ModelState.IsValid)
            {
                Receita receita = new();

                receita.Nome = receitaDaView.Nome;
                receita.Categoria = database.Categorias
                                            .Where(cat => cat.Id == receitaDaView.CategoriaId)
                                            .FirstOrDefault();
                receita.Imagem = receitaDaView.Imagem;
                receita.TempoDePreparo = receitaDaView.TempoDePreparo;
                receita.QtdPorcao = receitaDaView.QtdPorcao;
                receita.Dificuldade = receitaDaView.Dificuldade;
                receita.Descricao = receitaDaView.Descricao;
                receita.Ingrediente = receitaDaView.Ingrediente;
                receita.ModoDePreparo = receitaDaView.ModoDePreparo;
                receita.Status = true;

                database.Add(receita);
                database.SaveChanges();

                return RedirectToAction("GerenciarReceitas", "Receitas");
            }
            else
            {
                return RedirectToAction("GerenciarReceitas", "Receitas");
            }
        }

        [HttpPost]
        public IActionResult Atualizar(ReceitaDTO receitaDaView)
        {
            if (ModelState.IsValid)
            {
                var receita = database.Receitas.FirstOrDefault(rec => rec.Id == receitaDaView.Id);

                receita.Nome = receitaDaView.Nome;
                receita.Categoria = database.Categorias
                                            .Where(cat => cat.Id == receitaDaView.CategoriaId)
                                            .FirstOrDefault();
                receita.Imagem = receitaDaView.Imagem;
                receita.TempoDePreparo = receitaDaView.TempoDePreparo;
                receita.QtdPorcao = receitaDaView.QtdPorcao;
                receita.Dificuldade = receitaDaView.Dificuldade;
                receita.Descricao = receitaDaView.Descricao;
                receita.Ingrediente = receitaDaView.Ingrediente;
                receita.ModoDePreparo = receitaDaView.ModoDePreparo;

                database.SaveChanges();
                return RedirectToAction("GerenciarReceitas", "Receitas");
            }

            return RedirectToAction("GerenciarReceitas", "Receitas");
        }

        [HttpPost]
        public IActionResult Deletar(int id)
        {
            if (id > 0)
            {
                var receita = database.Receitas
                                            .Where(rec => rec.Id == id)
                                            .FirstOrDefault();
                receita.Status = false;

                database.SaveChanges();
            }

            return RedirectToAction("GerenciarReceitas", "Receitas");
        }
    }
}