using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Npgsql;
using productsApi.Dtos;
using productsApi.Models;
using productsApi.Repositories;
using productsApi.Services;
using ProductsApi.Dtos;
using ProductsApi.Models;
using ProductsApi.Repositories;

namespace fornecedorsApi.Services
{
    public class FornecedorService : IFornecedorService
    {
        private readonly IFornecedorRepository _fornecedorRepository;
        private readonly IProductRepository _productRepository;
        private readonly IProdutoFornecedorRepository _produtoFornecedorRepository;
        private readonly ILogger<FornecedorService> _logger;

        public FornecedorService(IFornecedorRepository fornecedorRepository, IProductRepository productRepository, IProdutoFornecedorRepository produtoFornecedorRepository, ILogger<FornecedorService> logger)
        {
            _fornecedorRepository = fornecedorRepository;
            _productRepository = productRepository;
            _produtoFornecedorRepository = produtoFornecedorRepository;
            _logger = logger;
        }

        public async Task<FornecedorResponseDto> Get(Guid id)
        {
            try
            {
                var fornecedor = await _fornecedorRepository.Get(id);

                var getProdFor = await _produtoFornecedorRepository.GetAll();
                var prodFor = getProdFor
                .Where(pf => pf.FornecedorId == id)
                .ToList();

                var getProducts = await _productRepository.GetAll();
                var products = getProducts
                .ToList();


                var prods = new List<Product>();

                foreach (ProdutoFornecedor PF in prodFor)
                {
                    foreach (Product P in products)
                    {
                        if (PF.ProductId == P.ProductId)
                        {
                            P.ProdutoFornecedores = null;
                            prods.Add(P);
                        }
                    }
                }



                FornecedorResponseDto fornecedorResponseDto = new()
                {
                    FornecedorId = fornecedor.FornecedorId,
                    CNPJ = fornecedor.CNPJ,
                    RazaoSocial = fornecedor.RazaoSocial,
                    NomeFantasia = fornecedor.NomeFantasia,
                    Endereco = fornecedor.Endereco,
                    Cidade = fornecedor.Cidade,
                    Estado = fornecedor.Estado,
                    CEP = fornecedor.CEP,
                    Telefone = fornecedor.Telefone,
                    Email = fornecedor.Email,
                    Produtos = prods
                };

                return fornecedorResponseDto;
            }
            catch (PostgresException ex)
            {
                var erro = "Ocorreu um erro inesperado, no banco, ao tentar obter o produto";
                _logger.LogError(ex, erro);
                throw new ArgumentException(erro, ex);
            }
            catch (System.Exception ex)
            {
                var erro = "Ocorreu um erro inesperado ao tentar obter o produto";
                _logger.LogError(ex, erro);
                throw new ArgumentException(erro, ex);
            }
        }

        public async Task<ServiceResult<Fornecedor>> Add(CreateFornecedorDto createFornecedorDto)
        {
            try
            {
                var taskRepository = _fornecedorRepository.Add(createFornecedorDto);
                await taskRepository;
                return new ServiceResult<Fornecedor>(true);
            }
            catch (PostgresException ex)
            {
                var erro = "Ocorreu um erro inesperado, no banco, ao tentar adicionar o fornecedor";
                _logger.LogError(ex, erro);
                return new ServiceResult<Fornecedor>(false, new String[1] { erro });
            }
            catch (System.Exception ex)
            {
                var erro = "Ocorreu um erro inesperado ao tentar adicionar o fornecedor";
                _logger.LogError(ex, erro);
                return new ServiceResult<Fornecedor>(false, new String[1] { erro });
            }

        }

        public async Task<ServiceResult<IEnumerable<Fornecedor>>> GetAll()
        {
            var fornecedor = await _fornecedorRepository.GetAll();

            return new ServiceResult<IEnumerable<Fornecedor>>(true, data: fornecedor);
        }

        public async Task<ServiceResult<Fornecedor>> Delete(Guid id)
        {
            try
            {
                var taskRepository = _fornecedorRepository.Delete(id);
                await taskRepository;

                return new ServiceResult<Fornecedor>(true);
            }
            catch (PostgresException ex)
            {
                var erro = "Ocorreu um erro inesperado, no banco, ao tentar deletar o fornecedor";
                _logger.LogError(ex, erro);
                return new ServiceResult<Fornecedor>(false, new String[1] { erro });
            }
            catch (System.Exception ex)
            {
                var erro = "Ocorreu um erro inesperado ao tentar deletar o fornecedor";
                _logger.LogError(ex, erro);
                return new ServiceResult<Fornecedor>(false, new String[1] { erro });
            }
        }

        public async Task<ServiceResult<Fornecedor>> Update(Guid id, UpdateFornecedorDto updateFornecedorDto)
        {
            try
            {
                Fornecedor fornecedor = new()
                {
                    FornecedorId = id,
                    CNPJ = updateFornecedorDto.CNPJ,
                    RazaoSocial = updateFornecedorDto.RazaoSocial,
                    NomeFantasia = updateFornecedorDto.NomeFantasia,
                    Endereco = updateFornecedorDto.Endereco,
                    Cidade = updateFornecedorDto.Cidade,
                    Estado = updateFornecedorDto.Estado,
                    CEP = updateFornecedorDto.CEP,
                    Telefone = updateFornecedorDto.Telefone,
                    Email = updateFornecedorDto.Email

                };

                var taskRepository = _fornecedorRepository.Update(fornecedor);
                await taskRepository;

                return new ServiceResult<Fornecedor>(true);
            }
            catch (PostgresException ex)
            {
                var erro = "Ocorreu um erro inesperado, no banco, ao tentar atualizar o fornecedor";
                _logger.LogError(ex, erro);
                return new ServiceResult<Fornecedor>(false, new String[1] { erro });
            }
            catch (System.Exception ex)
            {
                var erro = "Ocorreu um erro inesperado ao tentar atualizar o fornecedor";
                _logger.LogError(ex, erro);
                return new ServiceResult<Fornecedor>(false, new String[1] { erro });
            }
        }




    }
}