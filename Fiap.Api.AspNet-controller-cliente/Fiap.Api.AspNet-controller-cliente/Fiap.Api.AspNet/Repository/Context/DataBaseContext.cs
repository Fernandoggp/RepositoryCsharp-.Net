using Microsoft.EntityFrameworkCore;

namespace Fiap.Api.AspNet.Repository.Context
{
    public class DataBaseContext : DbContext
    {
        // Propriedade que será responsável pelo acesso a tabela de Mercado
        public DbSet<MercadoModel> Mercado { get; set; }

        // Propriedade que será responsável pelo acesso a tabela de Produto
        public DbSet<ProdutoModel> Produto { get; set; }

        public DataBaseContext(DbContextOptions options) : base(options)
        {
        }

        private DataBaseContext()
        {
        }

    }
}
