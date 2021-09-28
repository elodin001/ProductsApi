using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductsApi.Models;

namespace ProductsApi.Data
{
    public interface IDataContext
    {
        DbSet<Product> Products { get; init; }
        DbSet<Fornecedor> Fornecedores { get; init; }
        DbSet<ProdutoFornecedor> ProdutoFornecedores { get; init; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}