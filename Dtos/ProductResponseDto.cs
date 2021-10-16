using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using ProductsApi.Models;

namespace productsApi.Dtos
{
    public class ProductResponseDto
    {
        public Guid ProductId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
        public string Categoria { get; set; }

        //[JsonIgnore]
        public List<Fornecedor> Fornecedores { get; set; }
    }
}