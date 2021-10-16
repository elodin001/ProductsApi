using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductsApi.Data;
using ProductsApi.Dtos;
using ProductsApi.Models;

namespace ProductsApi.Repositories
{
    public class FornecedorRepository : IFornecedorRepository
    {
        private readonly IDataContext _context;
        public FornecedorRepository(IDataContext context)
        {
            _context = context;

        }
        public async Task Add(CreateFornecedorDto createFornecedorDto)
        {
            Fornecedor fornecedor = new()
            {
                CNPJ = createFornecedorDto.CNPJ,
                RazaoSocial = createFornecedorDto.RazaoSocial,
                NomeFantasia = createFornecedorDto.NomeFantasia,
                Endereco = createFornecedorDto.Endereco,
                Cidade = createFornecedorDto.Cidade,
                Estado = createFornecedorDto.Estado,
                CEP = createFornecedorDto.CEP,
                Telefone = createFornecedorDto.Telefone,
                Email = createFornecedorDto.Email
            };

            _context.Fornecedores.Add(fornecedor);
            await _context.SaveChangesAsync();

        }

        public async Task Delete(Guid id)
        {
            var itemToRemove = await _context.Fornecedores.FindAsync(id);
            if (itemToRemove == null)
            {
                throw new NullReferenceException();
            }

            _context.Fornecedores.Remove(itemToRemove);
            await _context.SaveChangesAsync();
        }

        public async Task<Fornecedor> Get(Guid id)
        {
            return await _context.Fornecedores.FindAsync(id);
        }

        public async Task<IEnumerable<Fornecedor>> GetAll()
        {
            return await _context.Fornecedores.ToListAsync();
        }

        public async Task Update(Fornecedor fornecedor)
        {
            var itemToUpdate = await _context.Fornecedores.FindAsync(fornecedor.FornecedorId);
            if (itemToUpdate == null)
                throw new NullReferenceException();
            itemToUpdate.CNPJ = fornecedor.CNPJ;
            itemToUpdate.RazaoSocial = fornecedor.RazaoSocial;
            itemToUpdate.NomeFantasia = fornecedor.NomeFantasia;
            itemToUpdate.Endereco = fornecedor.Endereco;
            itemToUpdate.Cidade = fornecedor.Cidade;
            itemToUpdate.Estado = fornecedor.Estado;
            itemToUpdate.CEP = fornecedor.CEP;
            itemToUpdate.Telefone = fornecedor.Telefone;
            itemToUpdate.Email = fornecedor.Email;
            await _context.SaveChangesAsync();

        }
    }
}