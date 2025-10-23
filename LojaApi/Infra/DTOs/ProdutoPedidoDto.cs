using System;

namespace LojaApi.Infra.DTOs;

public class ProdutoPedidoDto
{
    public int ProdutoId { get; set; }
    public string NomeProduto { get; set; } = string.Empty;
    public decimal PrecoUnitario { get; set; }
    public int Quantidade { get; set; }
}
