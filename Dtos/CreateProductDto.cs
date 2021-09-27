using System;
using System.Collections.Generic;

namespace ProductsApi.Dtos
{
    public class CreateProductDto
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
        public string Categoria { get; set; }

        public ICollection<Guid> FornecedoresIds { get; set; }
    }
}