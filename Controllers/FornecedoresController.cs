using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using productsApi.Dtos;
using productsApi.Services;
using ProductsApi.Dtos;
using ProductsApi.Models;

namespace ProductsApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FornecedoresController : ControllerBase
    {
        private readonly IFornecedorService _fornecedorService;
        public FornecedoresController(IFornecedorService fornecedorService)
        {
            _fornecedorService = fornecedorService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fornecedor>>> GetFornecedores()
        {
            var resultado = await _fornecedorService.GetAll();
            if (resultado.Ok)
            {
                return Ok(resultado.Data);
            }
            return StatusCode(500, resultado.Errors);
        }

        [HttpGet("{id}")]
        public async Task<FornecedorResponseDto> GetFornecedor(Guid id)
        {
            var resultado = await _fornecedorService.Get(id);
            return resultado;
            /*if (resultado.Ok)
            {
                return Ok(resultado.Data);
            }
            return StatusCode(500, resultado.Errors);*/
        }

        [HttpPost]
        public async Task<ActionResult> CreateFornecedor(CreateFornecedorDto createFornecedorDto)
        {
            if (ModelState.IsValid)
            {

                var resultado = await _fornecedorService.Add(createFornecedorDto);

                if (resultado.Ok)
                {
                    //return Created(string.Empty, resultado.Data);
                    return CreatedAtAction(this.ControllerContext.ActionDescriptor.ActionName, createFornecedorDto);
                }
                else
                {
                    return BadRequest(resultado.Errors);
                }
            }

            return BadRequest(ModelState.Values.SelectMany(p => p.Errors)?.Select(j => j.ErrorMessage));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteFornecedor(Guid id)
        {
            var resultado = await _fornecedorService.Delete(id);

            if (resultado.Ok)
            {
                return Created(string.Empty, resultado.Data);
            }
            else
            {
                return BadRequest(resultado.Errors);
            }

        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateFornecedor(Guid id, UpdateFornecedorDto updateFornecedorDto)
        {
            var FornecedorId = id;
            var resultado = await _fornecedorService.Update(id, updateFornecedorDto);

            if (resultado.Ok)
            {
                return Created(string.Empty, resultado.Data);
            }
            else
            {
                return BadRequest(resultado.Errors);
            }
        }
    }
}
