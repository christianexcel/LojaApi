using System;

namespace LojaApi.Entities;

public class Pedido
{
    public int Id { get; set; }
    public DateTime DataPedido { get; set; }
    public decimal ValorTotal { get; set; }
    public int ClienteId { get; set; }
    public Cliente? Cliente { get; set; }
    public ICollection<PedidoProduto> PedidoProdutos { get; set; } = new List<PedidoProduto>();
}
