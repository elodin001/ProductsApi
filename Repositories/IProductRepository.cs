using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using productsApi.Dtos;
using ProductsApi.Dtos;
using ProductsApi.Models;

namespace ProductsApi.Repositories
{
    public interface IProductRepository
    {
        Task<Product> Get(Guid id);
        Task<IEnumerable<Product>> GetAll();
        Task Add(CreateProductDto createProductDto);
        Task Delete(Guid id);
        Task Update(Guid id, UpdateProductDto updateProductDto);
    }
}