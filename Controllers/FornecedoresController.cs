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
    public class FornecedoresController : ControllerBase
    {
        private readonly IFornecedorRepository _fornecedorRepository;
        public FornecedoresController(IFornecedorRepository fornecedorRepository)
        {
            _fornecedorRepository = fornecedorRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fornecedor>>> GetFornecedores()
        {
            var fornecedor = await _fornecedorRepository.GetAll();
            return Ok(fornecedor);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Fornecedor>> GetFornecedor(int id)
        {
            var fornecedor = await _fornecedorRepository.Get(id);
            if (fornecedor == null)
                return NotFound();

            return Ok(fornecedor);
        }

        [HttpPost]
        public async Task<ActionResult> CreateFornecedor(CreateFornecedorDto createFornecedorDto)
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

            await _fornecedorRepository.Add(fornecedor);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteFornecedor(int id)
        {
            await _fornecedorRepository.Delete(id);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateFornecedor(int id, UpdateFornecedorDto updateFornecedorDto)
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

            await _fornecedorRepository.Update(fornecedor);
            return Ok();
        }
    }
}