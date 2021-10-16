using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Npgsql;
using productsApi.Dtos;
using productsApi.Models;
using productsApi.Repositories;
using ProductsApi.Data;
using ProductsApi.Dtos;
using ProductsApi.Models;
using ProductsApi.Repositories;

namespace productsApi.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IFornecedorRepository _fornecedorRepository;
        private readonly IProdutoFornecedorRepository _produtoFornecedorRepository;
        private readonly ILogger<ProductService> _logger;

        private readonly IDataContext _context;

        public ProductService(IProductRepository productRepository, IFornecedorRepository fornecedorRepository, IProdutoFornecedorRepository produtoFornecedorRepository, ILogger<ProductService> logger, IDataContext context)
        {
            _productRepository = productRepository;
            _fornecedorRepository = fornecedorRepository;
            _produtoFornecedorRepository = produtoFornecedorRepository;
            _logger = logger;
            _context = context;
        }

        public async Task<ServiceResult<ProductResponseDto>> Get(Guid id)
        {
            //try
            //{
            var produto = await _productRepository.Get(id);

            var getProdFor = await _produtoFornecedorRepository.GetAll();
            var prodFor = getProdFor
            .Where(pf => pf.ProductId == id)
            .ToList();

            var getFornecedores = await _fornecedorRepository.GetAll();
            var fornecedores = getFornecedores
            .ToList();


            var forn = new List<Fornecedor>();

            foreach (ProdutoFornecedor PF in prodFor)
            {
                foreach (Fornecedor F in fornecedores)
                {
                    if (PF.FornecedorId == F.FornecedorId)
                    {
                        forn.Add(F);
                    }
                }
            }



            ProductResponseDto productResponseDto = new()
            {
                ProductId = produto.ProductId,
                Nome = produto.Nome,
                Descricao = produto.Descricao,
                Preco = produto.Preco,
                Quantidade = produto.Quantidade,
                Categoria = produto.Categoria,
                Fornecedores = forn
            };

            /*string queryProduto = $@"SELECT * FROM Product p WHERE p.ProductId = '{id}' 
            LEFT OUTER JOIN ProdutoFornecedores pf ON p.ProductId = pf.ProductId 
            LEFT OUTER JOIN Fornecedores f ON pf.FornecedorId = f.FornecedorId";*/


            //CreateProductDto createProductDto = new CreateProductDto();

            return new ServiceResult<ProductResponseDto>(true, data: productResponseDto);
            //}
            /*catch (PostgresException ex)
            {
                var erro = "Ocorreu um erro inesperado, no banco, ao tentar obter o produto";
                _logger.LogError(ex, erro);
                return new ServiceResult<ProductResponseDto>(false, new String[1] { erro });
            }
            catch (System.Exception ex)
            {
                var erro = "Ocorreu um erro inesperado ao tentar obter o produto";
                _logger.LogError(ex, erro);
                return new ServiceResult<ProductResponseDto>(false, new String[1] { erro });
            }*/
        }

        public async Task<ServiceResult<Product>> Add(CreateProductDto createProductDto)
        {
            if (createProductDto.Nome == null || createProductDto.Nome == "")
            {
                throw new ArgumentException("Nome do produto não pode estar vazio");
            }
            try
            {
                var taskRepository = _productRepository.Add(createProductDto);
                await taskRepository;
                return new ServiceResult<Product>(true);
            }
            catch (PostgresException ex)
            {
                var erro = "Ocorreu um erro inesperado, no banco, ao adicionar o produto";
                _logger.LogError(ex, erro);
                return new ServiceResult<Product>(false, new String[1] { erro });
            }
            catch (System.Exception ex)
            {
                var erro = "Ocorreu um erro inesperado ao adicionar o produto";
                _logger.LogError(ex, erro);
                return new ServiceResult<Product>(false, new String[1] { erro });
            }

        }

        public async Task<ServiceResult<IEnumerable<Product>>> GetAll()
        {
            var produto = await _productRepository.GetAll();
            return new ServiceResult<IEnumerable<Product>>(true, data: produto);
        }

        public async Task<ServiceResult<Product>> Delete(Guid id)
        {
            try
            {
                var taskRepository = _productRepository.Delete(id);
                await taskRepository;

                return new ServiceResult<Product>(true);
            }
            catch (PostgresException ex)
            {
                var erro = "Ocorreu um erro inesperado, no banco, ao obter os produtos";
                _logger.LogError(ex, erro);
                return new ServiceResult<Product>(false, new String[1] { erro });
            }
            catch (System.Exception ex)
            {
                var erro = "Ocorreu um erro inesperado ao obter os produtos";
                _logger.LogError(ex, erro);
                return new ServiceResult<Product>(false, new String[1] { erro });
            }
        }

        public async Task<ServiceResult<Product>> Update(Guid id, UpdateProductDto updateProductDto)
        {
            try
            {
                var taskRepository = _productRepository.Update(id, updateProductDto);
                await taskRepository;

                return new ServiceResult<Product>(true);
            }
            catch (PostgresException ex)
            {
                var erro = "Ocorreu um erro inesperado, no banco, ao atualizar o produto";
                _logger.LogError(ex, erro);
                return new ServiceResult<Product>(false, new String[1] { erro });
            }
            catch (System.Exception ex)
            {
                var erro = "Ocorreu um erro inesperado ao atualizar o produto";
                _logger.LogError(ex, erro);
                return new ServiceResult<Product>(false, new String[1] { erro });
            }
        }

    }
}