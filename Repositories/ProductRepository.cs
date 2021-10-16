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
            /*var fornecedoresIds = _context.Fornecedores.Select(f => f.FornecedorId);

            var fornecedores = await _context.ProdutoFornecedores
                .Where(f => fornecedoresIds.Contains(f.FornecedorId))
                .ToListAsync();

            if (fornecedores.Count < 1)
            {
                throw new ArgumentException("IDs de fornecedores inválidos.");
            }

            product.ProdutoFornecedores = fornecedores;*/
            Product product = new()
            {
                Nome = createProductDto.Nome,
                Descricao = createProductDto.Descricao,
                Preco = createProductDto.Preco,
                Quantidade = createProductDto.Quantidade,
                Categoria = createProductDto.Categoria,
                /*ProdutoFornecedores = createProductDto.FornecedoresIds
           .Select(i => new ProdutoFornecedor() { FornecedorId = i })
           .ToList()*/
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

            /*var ProdutosList = _context.Products.Join(_context.ProdutoFornecedores, p => p.ProductId, f => f.FornecedorId,
            (p, f) => new { p, f })
            .Where(j => j.f.ProductId == id).ToList();*/



            /*var produto = await _context.Products.FirstOrDefaultAsync(t => t.ProductId == id);
            var fornecedoresIds = await _context.ProdutoFornecedores.Where(pf => pf.ProductId == produto.ProductId).Select(pf => pf.FornecedorId).ToListAsync();
            //var fornecedores = await _context.Fornecedores.Where(r => r.FornecedorId == produtoFornecedores.FornecedorId).ToListAsync();
            var fornecedores = await _context.Fornecedores
                  .Where(f => fornecedoresIds.Contains(f.FornecedorId))
                  .ToListAsync();
            //   return (produto, fornecedores);*/

            /*var produto = await  _context.Products.Where(p => p.ProductId == id)
            .Include(prod => prod.ProdutoFornecedores)
            .ThenInclude(prod => prod.Fornecedor).Where(prod => prod.ProductId == id)
            .ToListAsync();*/

            /*var produto = await _context.Products
        .Include(p => p.Fornecedores)
        .Where(u => u.ProductId == id)
        .ToListAsync();*/

            /*var produto = await _context.Products
            .Include(x => x.ProdutoFornecedores)
            .ThenInclude(y => y.Fornecedor)
            .SingleOrDefaultAsync(m => m.ProductId == id);*/

            /*return await _context.Products
            .Include(pf => pf.ProdutoFornecedores)
            .ThenInclude(pf => pf.Fornecedor)
            .Where(pf => pf.ProductId == id)
            .ToListAsync();*/




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