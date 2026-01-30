using System.ComponentModel.DataAnnotations;

namespace PaveControl.Models
{
    public class Produto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do pavê é obrigatório")]
        [Display(Name = "Nome do sabor")]
        public string Nome { get; set; } = string.Empty; 

        [Required(ErrorMessage = "Informe o preço do produto")]
        [Display(Name = "Preço da venda")]
        public decimal Preco { get; set; }

        [Display(Name = "Quantidade em Estoque")]
        public int Estoque { get; set; }

        public bool Ativo { get; set; } = true;
    }
}
