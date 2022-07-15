using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DESAFIO_MVC.DTO
{
    public class ReceitaDTO
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Categoria da receita obrigatória!")]
        public int CategoriaId { get; set; }

        [Required(ErrorMessage = "O preenchimento do nome da receita é obrigatório!")]
        [StringLength(100, ErrorMessage = "Nome de receita muito grande, digite um menor!")]
        [MinLength(5, ErrorMessage = "Digite no minimo um nome de receita com 5 caracteres!")]
        public string Nome { get; set; }

        [Required]
        public string Imagem { get; set; }

        [Required(ErrorMessage = "O preenchimento desse campo é obrigatório!")]
        public string TempoDePreparo { get; set; }

        [Required(ErrorMessage = "O preenchimento desse campo é obrigatório!")]
        public string QtdPorcao { get; set; }

        [Required(ErrorMessage = "O preenchimento desse campo é obrigatório!")]
        public string Dificuldade { get; set; }

        [Required(ErrorMessage = "O preenchimento desse campo é obrigatório!")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O preenchimento desse campo é obrigatório!")]
        public string Ingrediente { get; set; }

        [Required(ErrorMessage = "O preenchimento desse campo é obrigatório!")]
        public string ModoDePreparo { get; set; }
    }
}