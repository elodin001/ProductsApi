using System;

namespace ProductsApi.Dtos
{
    public class UpdateProdutoFornecedorDto
    {
        public Guid ProductId { get; set; }
        public Guid FornecedorId { get; set; }
    }
}