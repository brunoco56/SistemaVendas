using Microsoft.EntityFrameworkCore;
using SistemaVendas.Entidades;

namespace SistemaVendas.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Categoria> Categoria { get; set; }


        // Construtor que chama o Banco de Dados
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {

        }

    }
}
