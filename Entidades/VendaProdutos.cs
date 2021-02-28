using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaVendas.Entidades
{
    public class VendaProdutos
    {
        [Key]
        public int CodigoVenda { get; set; }
        public int CodigoProduto { get; set; }
        public double Quantidade { get; set; }
        public Decimal ValorUnitario { get; set; }
        public Decimal ValorTotal { get; set; }
        public Produto Produto { get; set; }
        public Venda Venda { get; set; }
       

    }
}
