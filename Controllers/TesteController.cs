using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductsApi.Dtos;
using ProductsApi.Models;
using ProductsApi.Repositories;

namespace ProductsApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TesteController : ControllerBase
    {
        private readonly ITesteRepository _testeRepository;
        private readonly IProductRepository _productRepository;
        private readonly IFornecedorRepository _fornecedorRepository;
        public TesteController(ITesteRepository testeRepository, IProductRepository productRepository, IFornecedorRepository fornecedorRepository)
        {
            _testeRepository = testeRepository;
            _productRepository = productRepository;
            _fornecedorRepository = fornecedorRepository;
        }

        [HttpPost]
        public async Task<ActionResult> CreateTeste(CreateTesteDto createTesteDto)
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

            await _testeRepository.Add(produtoFornecedor);
            return Ok();
        }
    }
}