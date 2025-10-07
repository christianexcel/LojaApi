using System;

namespace LojaApi.Entities;

public class Produto
{
    public int Id { get; set; }
    public string Descricao { get; set; } = String.Empty;
    public Decimal Valor { get; set; } = Decimal.Zero;
    public Decimal Estoque { get; set; } = Decimal.Zero;
    public bool Ativo { get; set; }
}
