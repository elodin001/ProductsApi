using System.Threading.Tasks;
using ProductsApi.Models;
using ProductsApi.Dtos;
using productsApi.Models;
using System.Collections.Generic;
using System;
using productsApi.Dtos;

namespace productsApi.Services
{
    public interface IProductService
    {
        Task<ProductResponseDto> Get(Guid id);
        Task<ServiceResult<IEnumerable<Product>>> GetAll();
        Task<ServiceResult<Product>> Add(CreateProductDto createProductDto);
        Task<ServiceResult<Product>> Delete(Guid id);
        Task<ServiceResult<Product>> Update(Guid id, UpdateProductDto updateProductDto);
    }
}