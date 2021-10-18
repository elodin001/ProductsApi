using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using productsApi.Dtos;
using ProductsApi.Data;
using ProductsApi.Dtos;
using ProductsApi.Models;

namespace ProductsApi.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDataContext _context;
        public ProductRepository(IDataContext context)
        {
            _context = context;

        }
        public async Task Add(CreateProductDto createProductDto)
        {
            Product product = new()
            {
                Nome = createProductDto.Nome,
                Descricao = createProductDto.Descricao,
                Preco = createProductDto.Preco,
                Quantidade = createProductDto.Quantidade,
                Categoria = createProductDto.Categoria,
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            ProdutoFornecedor produtoFornecedor = new()
            {
                ProductId = product.ProductId,
                FornecedorId = createProductDto.Fornecedor,
            };

            _context.ProdutoFornecedores.Add(produtoFornecedor);
            await _context.SaveChangesAsync();

        }

        public async Task Delete(Guid id)
        {
            var itemToRemove = await _context.Products.FindAsync(id);
            if (itemToRemove == null)
                throw new NullReferenceException();

            _context.Products.Remove(itemToRemove);
            await _context.SaveChangesAsync();
        }

        public async Task<Product> Get(Guid id)
        {

            return await _context.Products.FindAsync(id);

        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task Update(Guid id, UpdateProductDto updateProductDto)
        {
            Product product = new()
            {
                ProductId = id,
                Nome = updateProductDto.Nome,
                Descricao = updateProductDto.Descricao,
                Preco = updateProductDto.Preco,
                Quantidade = updateProductDto.Quantidade,
                Categoria = updateProductDto.Categoria

            };

            var itemToUpdate = await _context.Products.FindAsync(product.ProductId);
            if (itemToUpdate == null)
                throw new NullReferenceException();
            itemToUpdate.Nome = product.Nome;
            itemToUpdate.Descricao = product.Descricao;
            itemToUpdate.Preco = product.Preco;
            itemToUpdate.Quantidade = product.Quantidade;
            itemToUpdate.Categoria = product.Categoria;
            await _context.SaveChangesAsync();

        }
    }
}