using System;
using System.Collections.Generic;
using ProductsApi.Models;

namespace productsApi.Dtos
{
    public class FornecedorResponseDto
    {
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
        public List<Product> Produtos { get; set; }
    }
}