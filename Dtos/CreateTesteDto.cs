using System;

namespace ProductsApi.Dtos
{
    public class CreateTesteDto
    {
        public Guid ProductId { get; set; }
        public Guid FornecedorId { get; set; }
    }
}