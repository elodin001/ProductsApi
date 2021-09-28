using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProductsApi.Models;

namespace ProductsApi.Repositories
{
    public interface ITesteRepository
    {
        Task Add(ProdutoFornecedor produtoFornecedor);
    }
}