using System.Globalization;
using Microsoft.EntityFrameworkCore;
using ProductsApi.Models;

namespace ProductsApi.Data
{
    public class DataContext : DbContext, IDataContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; init; }
        public DbSet<Fornecedor> Fornecedores { get; init; }
        public DbSet<ProdutoFornecedor> ProdutoFornecedores { get; init; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProdutoFornecedor>().HasKey(sc =>
                new { sc.ProductId, sc.FornecedorId });
        }
    }
}