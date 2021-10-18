using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using productsApi.Dtos;
using productsApi.Models;
using ProductsApi.Models;

namespace productsApi.Services
{
    public interface IProdutoFornecedorService
    {
        Task<ServiceResult<ProdutoFornecedor>> Add(CreateProdutoFornecedorDto createProdutoFornecedorDto);
        //Task<ServiceResult<ProdutoFornecedor>> Get(Guid id);
        Task<ServiceResult<IEnumerable<ProdutoFornecedor>>> GetAll();
        Task<ServiceResult<ProdutoFornecedor>> Delete(Guid[] id);
        //Task<ServiceResult<ProdutoFornecedor>> Update(Guid id, UpdateProdutoFornecedorDto updateProdutoFornecedorDto);
    }
}