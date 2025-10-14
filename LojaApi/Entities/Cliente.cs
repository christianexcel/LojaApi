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
        [Required(ErrorMessage = "O nome do cliente é obrigatório.")]
        [MaxLength(100, ErrorMessage = "O nome do cliente não pode exceder 100 caracteres.")]
        [MinLength(3, ErrorMessage = "O nome do cliente deve ter no mínimo 3 caracteres.")]
        public string Nome { get; set; } = string.Empty;
        [Column("email_cliente")]
        [Required(ErrorMessage = "O email do cliente é obrigatório.")]
        [EmailAddress(ErrorMessage = "O email do cliente deve ser válido.")]
        public string Email { get; set; } = string.Empty;
        [Column("ativo")]
        [Required]
        public bool Ativo { get; set; }
        [Column("data_cadastro")]
        public DateTime DataCadastro { get; set; }
    }
}
