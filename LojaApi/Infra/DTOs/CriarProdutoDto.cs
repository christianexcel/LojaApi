using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using LojaApi.Entities;

namespace LojaApi.Infra.DTOs;

public class CriarProdutoDto
{
    public int Id { get; set; }
    [Required(ErrorMessage = "O nome do produto é obrigatório.")]
    [StringLength(150, MinimumLength = 3, ErrorMessage = "O nome deve ter entre 3 e 150 caracteres.")]
    public string Descricao { get; set; } = string.Empty;
    [Required(ErrorMessage = "O valor do produto é obrigatório.")]
    [Range(0.01, 100000.00, ErrorMessage = "O preço deve ser entre 0.01 e 100.000,00")]
    public Decimal Valor { get; set; } = Decimal.Zero;
    [Required]
    [Range(0, 9999, ErrorMessage = "O estoque deve ser entre 0 e 9999.")]
    public Decimal Estoque { get; set; } = Decimal.Zero;
    [Required(ErrorMessage = "O ID categoria é obrigatório.")]
    public int CategoriaId { get; set; }
    public Categoria? Categoria { get; set; }
    [Required]
    public bool Ativo { get; set; }
}
