using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProductsApi.Models;

namespace productsApi.Repositories
{
    public interface IProdutoFornecedorRepository
    {
        //Task<ProdutoFornecedor> Get(Guid id);
        Task<IEnumerable<ProdutoFornecedor>> GetAll();
        Task Add(ProdutoFornecedor produtoFornecedor);
        //Task Delete(Guid keyId1, Guid keyId2);
        //Task Update(Product product);
    }
}