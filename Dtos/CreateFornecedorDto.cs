namespace ProductsApi.Dtos
{
    public class CreateFornecedorDto
    {
        public int CNPJ { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string Endereco { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public int CEP { get; set; }
        public int Telefone { get; set; }
        public string Email { get; set; }
    }
}