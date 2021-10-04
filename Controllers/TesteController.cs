using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductsApi.Dtos;
using ProductsApi.Models;
using ProductsApi.Repositories;
using ProductsApi.Services;

namespace ProductsApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TesteController : ControllerBase
    {
        private readonly ITesteService _testeService;

        public TesteController(ITesteService testeService)
        {
            _testeService = testeService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateTeste(CreateTesteDto createTesteDto)
        {
            var resultado = await _testeService.Add(createTesteDto);

            if(resultado.Ok)
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