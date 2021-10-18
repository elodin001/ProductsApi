using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

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

        [JsonIgnore]
        public ICollection<ProdutoFornecedor> ProdutoFornecedores { get; set; }

    }
}