using System;

namespace LojaApi.Infra.DTOs;

public class PedidoDetalhadoDto
{
    public int Id { get; set; }
    public DateTime DataPedido { get; set; }
    public decimal ValorTotal { get; set; }
    public int ClienteId { get; set; }
    public string NomeCliente { get; set; } = string.Empty;
    public List<ProdutoPedidoDto> Itens { get; set; } = new List<ProdutoPedidoDto>();
}
