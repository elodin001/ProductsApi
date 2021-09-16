using System;
using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;

namespace ProductsApi.Models
{
    public class Product
    {
        //[Key]
        public int ProductId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
        public string Categoria { get; set; }
        public ICollection<ProdutoFornecedor> ProdutoFornecedores { get; set; }

        //public DateTime DateCreated { get; set; }

    }
}