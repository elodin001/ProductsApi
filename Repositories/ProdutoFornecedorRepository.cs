using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using productsApi.Repositories;
using ProductsApi.Data;
using ProductsApi.Models;

namespace ProductsApi.Repositories
{
    public class ProdutoFornecedorRepository : IProdutoFornecedorRepository
    {
        private readonly IDataContext _context;
        public ProdutoFornecedorRepository(IDataContext context)
        {
            _context = context;

        }
        public async Task Add(ProdutoFornecedor produtoFornecedor)
        {
            _context.ProdutoFornecedores.Add(produtoFornecedor);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProdutoFornecedor>> GetAll()
        {
            return await _context.ProdutoFornecedores.ToListAsync();
        }

        public async Task Delete(Guid id, Guid id2)
        {
            var itemToRemove = await _context.ProdutoFornecedores.FindAsync(id, id2);
            if (itemToRemove == null)
                throw new NullReferenceException();

            _context.ProdutoFornecedores.Remove(itemToRemove);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid[] id)
        {
            var itemToRemove = await _context.ProdutoFornecedores.FindAsync(id[0], id[1]);
            if (itemToRemove == null)
                throw new NullReferenceException();

            _context.ProdutoFornecedores.Remove(itemToRemove);
            await _context.SaveChangesAsync();
        }
    }
}