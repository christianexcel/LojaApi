using System;
using System.ComponentModel.DataAnnotations;
using LojaApi.Entities;

namespace LojaApi.Infra.DTOs;

public class CategoriaDto
{
    public int Id { get; set; }
    [Required(ErrorMessage = "O nome da categoria é obrigatório.")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "O nome da categoria deve ter entre 3 e 100 caracteres.")]
    public string Descricao { get; set; } = string.Empty;
    [Required]
    public bool Ativo { get; set; }
    //public ICollection<Produto> Produtos { get; set; } = new List<Produto>();
}
