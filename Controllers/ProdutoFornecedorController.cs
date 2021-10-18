using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using productsApi.Dtos;
using productsApi.Services;
using ProductsApi.Models;

namespace ProductsApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoFornecedorController : ControllerBase
    {
        private readonly IProdutoFornecedorService _produtoFornecedorService;
        public ProdutoFornecedorController(IProdutoFornecedorService produtoFornecedorService)
        {
            _produtoFornecedorService = produtoFornecedorService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateProdutoFornecedor(CreateProdutoFornecedorDto createProdutoProdutoFornecedorDto)
        {
            if (ModelState.IsValid)
            {

                var resultado = await _produtoFornecedorService.Add(createProdutoProdutoFornecedorDto);

                if (resultado.Ok)
                {
                    //return Created(string.Empty, resultado.Data);
                    return CreatedAtAction(this.ControllerContext.ActionDescriptor.ActionName, createProdutoProdutoFornecedorDto);
                }
                else
                {
                    return BadRequest(resultado.Errors);
                }
            }

            return BadRequest(ModelState.Values.SelectMany(p => p.Errors)?.Select(j => j.ErrorMessage));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdutoFornecedor>>> GetProdutoFornecedores()
        {
            var resultado = await _produtoFornecedorService.GetAll();
            if (resultado.Ok)
            {
                return Ok(resultado.Data);
            }
            return StatusCode(500, resultado.Errors);
        }

        [HttpDelete("{id1}&&{id2}")]
        public async Task<ActionResult> DeleteProdutoFornecedor(Guid id1, Guid id2)
        {
            Guid[] id = new Guid[] { id1, id2 };
            if (ModelState.IsValid)
            {
                var resultado = await _produtoFornecedorService.Delete(id);

                if (resultado.Ok)
                {
                    return NoContent();
                }
                return StatusCode(500, resultado.Errors);
            }
            return BadRequest(ModelState.Values.SelectMany(p => p.Errors)?.Select(j => j.ErrorMessage));


            //await _productService.Delete(id);
            //return Ok();
        }
    }
}
