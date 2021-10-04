using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductsApi.Dtos;
using ProductsApi.Models;
using ProductsApi.Repositories;

namespace ProductsApi.Services
{
    public class TesteService : ITesteService
    {
        private readonly ITesteRepository _testeRepository;
        private readonly IProductRepository _productRepository;
        private readonly IFornecedorRepository _fornecedorRepository;

        public TesteService(ITesteRepository testeRepository, IProductRepository productRepository, IFornecedorRepository fornecedorRepository)
        {
            _testeRepository = testeRepository;
            _productRepository = productRepository;
            _fornecedorRepository = fornecedorRepository;
        }
        
        public async Task<ServiceResult<ProdutoFornecedor>> Add(CreateTesteDto createTesteDto)
        {
            Product product = await _productRepository.Get(createTesteDto.ProductId);
            Fornecedor fornecedor = await _fornecedorRepository.Get(createTesteDto.FornecedorId);

            ProdutoFornecedor produtoFornecedor = new()
            {
                ProductId = createTesteDto.ProductId,
                Product = product,
                FornecedorId = createTesteDto.FornecedorId,
                Fornecedor = fornecedor
            };

            var taskRepository = _testeRepository.Add(produtoFornecedor);
            await taskRepository;

            return new ServiceResult<ProdutoFornecedor>(true);
        }
    }
}