using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LojaApi.Entities;

[Table("TB_CATEGORIAS")]
public class Categoria
{
    [Key]
    [Column("id_categoria")]
    public int Id { get; set; }
    [Column("descricao")]
    [Required(ErrorMessage = "O nome da categoria é obrigatório.")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "O nome da categoria deve ter entre 3 e 100 caracteres.")]
    public required string Descricao { get; set; } = String.Empty;
    [Column("ativo")]
    [Required]
    public bool Ativo { get; set; }
    public ICollection<Produto> Produtos { get; set; } = new List<Produto>();
}
