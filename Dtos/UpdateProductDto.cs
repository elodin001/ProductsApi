using System;

namespace ProductsApi.Dtos
{
    public class UpdateProductDto
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
        public string Categoria { get; set; }
    }
}