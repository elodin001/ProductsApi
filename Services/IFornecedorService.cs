using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using productsApi.Models;
using ProductsApi.Models;
using ProductsApi.Dtos;
using productsApi.Dtos;

namespace productsApi.Services
{
    public interface IFornecedorService
    {
        Task<FornecedorResponseDto> Get(Guid id);
        Task<ServiceResult<IEnumerable<Fornecedor>>> GetAll();
        Task<ServiceResult<Fornecedor>> Add(CreateFornecedorDto createFornecedorDto);
        Task<ServiceResult<Fornecedor>> Delete(Guid id);
        Task<ServiceResult<Fornecedor>> Update(Guid id, UpdateFornecedorDto updateFornecedorDto);
    }
}