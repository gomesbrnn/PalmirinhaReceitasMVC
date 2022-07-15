using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DESAFIO_MVC.Models
{
    public class HistoricoAcesso
    {
        public int Id { get; set; }
        public string Usuario { get; set; }
        public Receita Receita { get; set; }
        public DateTime DataAcesso { get; set; }
    }
}