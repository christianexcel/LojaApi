using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LojaApi.Entities;

[Table("TB_CATEGORIAS")]
public class Categoria
{
    [Key]
    [Column("id_cliente")]
    public int Id { get; set; }
    [Column("descricao")]
    [Required]
    public required string Descricao { get; set; }
    [Column("ativo")]
    [Required]
    public bool Ativo { get; set; }
}
