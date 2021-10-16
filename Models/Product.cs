using System;
using System.Collections.Generic;

namespace ProductsApi.Models
{
    public class Product
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //[Key]
        public Guid ProductId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
        public string Categoria { get; set; }
        //public List<Fornecedor> Fornecedores { get; set; }
        public ICollection<ProdutoFornecedor> ProdutoFornecedores { get; set; }

        //public DateTime DateCreated { get; set; }

    }
}