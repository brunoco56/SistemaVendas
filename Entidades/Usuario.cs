using System.ComponentModel.DataAnnotations;

namespace SistemaVendas.Entidades
{
    public class Usuario
    {
        [Key]
        public int? Codigo { get; set; }
        public string Nome { get; set; }
        public string CNPJ_CPF { get; set; }
        public string Email  { get; set;}
        public string Celular { get; set; }
    }
}
