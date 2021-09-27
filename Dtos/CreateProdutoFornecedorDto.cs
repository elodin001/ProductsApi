using System;

namespace ProductsApi.Dtos
{
    public class CreateProdutoFornecedorDto
    {
        public Guid ProductId { get; set; }
        public Guid FornecedorId { get; set; }
    }
}