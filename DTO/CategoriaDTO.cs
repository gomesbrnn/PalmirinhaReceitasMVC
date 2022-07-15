using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DESAFIO_MVC.DTO
{
    public class CategoriaDTO
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "O preenchimento do nome da categoria é obrigatório!")]
        [StringLength(100, ErrorMessage = "Nome de categoria muito grande, digite um menor!")]
        [MinLength(5, ErrorMessage = "Digite no minimo um nome com 5 caracteres!")]
        public string Nome { get; set; }

        [Required]
        public string Imagem { get; set; }
    }
}