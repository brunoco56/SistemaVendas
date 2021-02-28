using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaVendas.Entidades
{
    public class Venda
    {
        [Key]
        public int? Codigo { get; set; }
        public DateTime Data { get; set; }

        [ForeignKey("Cliente")]
        public int CodigoCategoria { get; set; }

    }
}
