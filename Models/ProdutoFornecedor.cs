namespace ProductsApi.Models
{
    public class ProdutoFornecedor
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int FornecedorId { get; set; }
        public Fornecedor Fornecedor { get; set; }
    }
}