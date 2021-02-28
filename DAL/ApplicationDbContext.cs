using Microsoft.EntityFrameworkCore;
using SistemaVendas.Entidades;

namespace SistemaVendas.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Venda> Venda { get; set; }
        public DbSet<VendaProdutos> VendaProdutos { get; set; }

        // Construtor que chama o Banco de Dados
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){ }
        protected override void OnModelCreating(ModelBuilder builder) 
        {  
            // AQUI SE MODELA O DBCONTEXT
            base.OnModelCreating(builder);

            builder.Entity<VendaProdutos>().HasKey(x => new { x.CodigoVenda, x.CodigoProduto });

            //Lê-se a venda produtos tem uma venda com muitos produtos
            builder.Entity<VendaProdutos>()
                .HasOne(x => x.Venda)
                .WithMany(y => y.Produtos)
                .HasForeignKey(x => x.CodigoVenda);
            //Lê-se a venda produtos tem um produto com muitas vendas
            builder.Entity<VendaProdutos>()
                .HasOne(x => x.Produto)
                .WithMany(y => y.Vendas)
                .HasForeignKey(x => x.CodigoProduto);

        }
       

    }
}
