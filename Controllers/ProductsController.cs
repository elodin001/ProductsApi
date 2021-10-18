using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using productsApi.Dtos;
using productsApi.Services;
using ProductsApi.Dtos;
using ProductsApi.Models;

namespace ProductsApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ILogger<ProductsController> _logger;
        public ProductsController(IProductService productService, ILogger<ProductsController> logger)
        {
            _productService = productService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var resultado = await _productService.GetAll();
            if (resultado.Ok)
            {
                return Ok(resultado.Data);
            }
            return StatusCode(500, resultado.Errors);

            /*var resultado = await _productService.GetAll();

            if (resultado.Ok)
            {
                return Ok(resultado);
            }
            return StatusCode(500, resultado.Errors);*/


        }

        [HttpGet("{id}")]
        public async Task<ProductResponseDto> GetProduct(Guid id)
        {
            var resultado = await _productService.Get(id);
            return resultado;
            /*if (resultado.Ok)
            {
                return Ok(resultado.Data);
            }
            return StatusCode(500, resultado.Errors);*/

            /* if (resultado.Ok)
             {
                 return Created(string.Empty, resultado.Data);
             }
             else
             {
                 return StatusCode(500, resultado.Errors);
             }*/
        }

        [HttpPost]
        public async Task<ActionResult> CreateProduct(CreateProductDto createProductDto)
        {

            if (ModelState.IsValid)
            {
                var resultado = await _productService.Add(createProductDto);

                if (resultado.Ok)
                {
                    //return Created(string.Empty, resultado.Data);
                    return CreatedAtAction(this.ControllerContext.ActionDescriptor.ActionName, createProductDto);
                }
                else
                {
                    return BadRequest(resultado.Errors);
                }
            }

            return BadRequest(ModelState.Values.SelectMany(p => p.Errors)?.Select(j => j.ErrorMessage));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(Guid id)
        {
            if (ModelState.IsValid)
            {
                var resultado = await _productService.Delete(id);

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

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProduct(Guid id, UpdateProductDto updateProductDto)
        {
            if (ModelState.IsValid)
            {
                Product product = new()
                {
                    Nome = updateProductDto.Nome,
                    Descricao = updateProductDto.Descricao,
                    Preco = updateProductDto.Preco,
                    Quantidade = updateProductDto.Quantidade,
                    Categoria = updateProductDto.Categoria
                };

                var resultado = await _productService.Update(id, updateProductDto);

                if (resultado.Ok)
                {
                    return NoContent();
                }
                return BadRequest(resultado.Errors);
            }
            return BadRequest(ModelState.Values.SelectMany(p => p.Errors)?.Select(j => j.ErrorMessage));
        }
    }

    /*var ProductId = id;
    var resultado = await _productService.Update(id, updateProductDto);

    if (resultado.Ok)
    {
        return Created(string.Empty, resultado.Data);
    }
    else
    {
        return BadRequest(resultado.Errors);
    }*/
}

