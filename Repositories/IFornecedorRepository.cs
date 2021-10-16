using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProductsApi.Dtos;
using ProductsApi.Models;

namespace ProductsApi.Repositories
{
    public interface IFornecedorRepository
    {
        Task<Fornecedor> Get(Guid id);
        Task<IEnumerable<Fornecedor>> GetAll();
        Task Add(CreateFornecedorDto createFornecedorDto);
        Task Delete(Guid id);
        Task Update(Fornecedor fornecedor);
    }
}