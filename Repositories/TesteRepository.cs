using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductsApi.Data;
using ProductsApi.Models;

namespace ProductsApi.Repositories
{
    public class TesteRepository : ITesteRepository
    {
        private readonly IDataContext _context;
        public TesteRepository(IDataContext context)
        {
            _context = context;

        }
        public async Task Add(ProdutoFornecedor produtoFornecedor)
        {
            _context.ProdutoFornecedores.Add(produtoFornecedor);
            await _context.SaveChangesAsync();
        }
    }
}