using System;

namespace ProductsApi.Models
{
    public class ProdutoFornecedor
    {
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public Guid FornecedorId { get; set; }
        public Fornecedor Fornecedor { get; set; }
    }
}