using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Npgsql;
using productsApi.Models;
using productsApi.Services;
using ProductsApi.Dtos;
using ProductsApi.Models;
using ProductsApi.Repositories;

namespace fornecedorsApi.Services
{
    public class FornecedorService : IFornecedorService
    {
        private readonly IFornecedorRepository _fornecedorRepository;
        private readonly ILogger<FornecedorService> _logger;

        public FornecedorService(IFornecedorRepository fornecedorRepository, ILogger<FornecedorService> logger)
        {
            _fornecedorRepository = fornecedorRepository;
            _logger = logger;
        }

        public async Task<ServiceResult<Fornecedor>> Get(Guid id)
        {
            try
            {
                var fornecedor = await _fornecedorRepository.Get(id);

                return new ServiceResult<Fornecedor>(true, data: fornecedor);
            }
            catch (PostgresException ex)
            {
                var erro = "Ocorreu um erro inesperado, no banco, ao tentar obter o fornecedor";
                _logger.LogError(ex, erro);
                return new ServiceResult<Fornecedor>(false, new String[1] { erro });
            }
            catch (System.Exception ex)
            {
                var erro = "Ocorreu um erro inesperado ao tentar obter o fornecedor";
                _logger.LogError(ex, erro);
                return new ServiceResult<Fornecedor>(false, new String[1] { erro });
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