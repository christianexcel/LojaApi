using System;
using System.Text.Json.Serialization;

namespace LojaApi.Infra.DTOs;

public class ProdutoDetalhadoDto
{
    public int Id { get; set; }
    public String Descricao { get; set; } = string.Empty;
    public Decimal Valor { get; set; } = decimal.Zero;
    public Decimal Estoque { get; set; } = decimal.Zero;
    public bool Ativo { get; set; }
    public int CategoriaId { get; set; }
    public CategoriaDto? Categoria { get; set; }
}
