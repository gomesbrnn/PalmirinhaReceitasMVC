using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DESAFIO_MVC.Models
{
    public class Receita
    {
        public int Id { get; set; }
        public Categoria Categoria { get; set; }
        public string Nome { get; set; }
        public string Imagem { get; set; }
        public string TempoDePreparo { get; set; }
        public string QtdPorcao { get; set; }
        public string Dificuldade { get; set; }
        public string Descricao { get; set; }
        public string Ingrediente { get; set; }
        public string ModoDePreparo { get; set; }
        public bool Status { get; set; }
    }
}