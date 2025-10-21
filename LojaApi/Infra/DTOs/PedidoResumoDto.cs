using System;

namespace LojaApi.Infra.DTOs;

public class PedidoResumoDto
{
    public int Id { get; set; }
    public DateTime DataPedido { get; set; }
    public decimal ValorTotal { get; set; }
    public string NomeCliente { get; set; } = string.Empty;
}
