using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LojaApi.Entities;

public class Produto
{
    public int Id { get; set; }
    public string Descricao { get; set; } = String.Empty;
    public Decimal Valor { get; set; } = Decimal.Zero;
    public Decimal Estoque { get; set; } = Decimal.Zero;
    public int CategoriaId { get; set; }
    public Categoria? Categoria { get; set; }
    public bool Ativo { get; set; }
    public ICollection<PedidoProduto> PedidoProdutos { get; set; } = new List<PedidoProduto>();
}
