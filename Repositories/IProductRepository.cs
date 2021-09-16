using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProductsApi.Models;

namespace ProductsApi.Repositories
{
    public interface IProductRepository
    {
        Task<Product> Get(Guid id);
        Task<IEnumerable<Product>> GetAll();
        Task Add(Product product);
        Task Delete(Guid id);
        Task Update(Product product);
    }
}