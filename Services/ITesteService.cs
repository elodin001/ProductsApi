using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductsApi.Dtos;
using ProductsApi.Models;

namespace ProductsApi.Services
{
    public interface ITesteService
    {
        Task<ServiceResult<ProdutoFornecedor>> Add(CreateTesteDto createTesteDto);
    }
}