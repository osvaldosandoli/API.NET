using System.ComponentModel.DataAnnotations;

namespace ProdutoAPI2.Models
{
    public class Produto
    {
        [Key] // Esta anotação indica que é uma chave primária
        public int IdProduto { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
    }
}
