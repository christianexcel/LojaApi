using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LojaApi.Entities
{
    [Table("TB_CLIENTES")]
    public class Cliente
    {
        [Key]
        [Column("id_cliente")]
        public int Id { get; set; }
        [Column("nome_cliente")]
        [Required]
        public string Nome { get; set; } = string.Empty;
        [Column("email_cliente")]
        [Required]
        public string Email { get; set; } = string.Empty;
        [Column("ativo")]
        [Required]
        public bool Ativo { get; set; }
        [Column("data_cadastro")]
        public DateTime DataCadastro { get; set; }
    }
}
