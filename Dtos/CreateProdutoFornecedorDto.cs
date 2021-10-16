using System;

namespace productsApi.Dtos
{
    public class CreateProdutoFornecedorDto
    {
        public Guid ProductId { get; set; }
        public Guid FornecedorId { get; set; }
    }
}