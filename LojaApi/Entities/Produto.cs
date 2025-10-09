using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LojaApi.Entities;

[Table("TB_PRODUTOS")]
public class Produto
{
    [Key]
    [Column("id_produto")]
    public int Id { get; set; }
    [Column("descricao")]
    [Required]
    public string Descricao { get; set; } = String.Empty;
    [Column("valor")]
    [Required]
    public Decimal Valor { get; set; } = Decimal.Zero;
    [Required]
    [Column("estoque")]
    public Decimal Estoque { get; set; } = Decimal.Zero;
    [Column("ativo")]
    [Required]
    public bool Ativo { get; set; }
}
