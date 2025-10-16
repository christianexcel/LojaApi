using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LojaApi.Entities
{
    [Table("TB_CLIENTES")]
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public bool Ativo { get; set; }
        public DateTime DataCadastro { get; set; }
        public Endereco? Endereco { get; set; }
    }
}
