using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Npgsql;
using productsApi.Dtos;
using productsApi.Models;
using productsApi.Repositories;
using ProductsApi.Dtos;
using ProductsApi.Models;
using ProductsApi.Repositories;

namespace productsApi.Services
{
    public class ProdutoFornecedorService : IProdutoFornecedorService
    {
        private readonly IProdutoFornecedorRepository _produtoFornecedorRepository;
        private readonly IProductRepository _productRepository;
        private readonly IFornecedorRepository _fornecedorRepository;
        private readonly ILogger<ProdutoFornecedorService> _logger;

        public ProdutoFornecedorService(IProdutoFornecedorRepository produtoFornecedorRepository, IProductRepository productRepository, IFornecedorRepository fornecedorRepository, ILogger<ProdutoFornecedorService> logger)
        {
            _produtoFornecedorRepository = produtoFornecedorRepository;
            _productRepository = productRepository;
            _fornecedorRepository = fornecedorRepository;
            _logger = logger;
        }

        public async Task<ServiceResult<ProdutoFornecedor>> Add(CreateProdutoFornecedorDto createProdutoFornecedorDto)
        {
            try
            {
                Product product = await _productRepository.Get(createProdutoFornecedorDto.ProductId);
                Fornecedor fornecedor = await _fornecedorRepository.Get(createProdutoFornecedorDto.FornecedorId);

                ProdutoFornecedor produtoFornecedor = new()
                {
                    ProductId = createProdutoFornecedorDto.ProductId,
                    //Product = product,
                    FornecedorId = createProdutoFornecedorDto.FornecedorId,
                    Fornecedor = fornecedor
                };

                var taskRepository = _produtoFornecedorRepository.Add(produtoFornecedor);
                await taskRepository;

                return new ServiceResult<ProdutoFornecedor>(true);
            }
            catch (PostgresException ex)
            {
                var erro = "Ocorreu um erro inesperado, no banco, ao tentar adicionar o ProdutoFornecedor";
                _logger.LogError(ex, erro);
                return new ServiceResult<ProdutoFornecedor>(false, new String[1] { erro });
            }
            catch (System.Exception ex)
            {
                var erro = "Ocorreu um erro inesperado ao adicionar o ProdutoFornecedor";
                _logger.LogError(ex, erro);
                return new ServiceResult<ProdutoFornecedor>(false, new String[1] { erro });
            }

        }

        public async Task<ServiceResult<IEnumerable<ProdutoFornecedor>>> GetAll()
        {
            var produtoFornecedor = await _produtoFornecedorRepository.GetAll();

            return new ServiceResult<IEnumerable<ProdutoFornecedor>>(true, data: produtoFornecedor);
        }

        public async Task<ServiceResult<ProdutoFornecedor>> Delete(Guid[] id)
        {
            try
            {
                var taskRepository = _produtoFornecedorRepository.Delete(id);
                await taskRepository;

                return new ServiceResult<ProdutoFornecedor>(true);
            }
            catch (PostgresException ex)
            {
                var erro = "Ocorreu um erro inesperado, no banco, ao obter o ProdutoFornecedor";
                _logger.LogError(ex, erro);
                return new ServiceResult<ProdutoFornecedor>(false, new String[1] { erro });
            }
            catch (System.Exception ex)
            {
                var erro = "Ocorreu um erro inesperado ao obter o ProdutoFornecedor";
                _logger.LogError(ex, erro);
                return new ServiceResult<ProdutoFornecedor>(false, new String[1] { erro });
            }
        }

    }
}
