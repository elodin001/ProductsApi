using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProductsApi.Models
{
    public class Fornecedor
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid FornecedorId { get; set; }
        public int CNPJ { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string Endereco { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public int CEP { get; set; }
        public int Telefone { get; set; }
        public string Email { get; set; }

        [JsonIgnore]
        public ICollection<ProdutoFornecedor> ProdutoFornecedores { get; set; }
    }
}