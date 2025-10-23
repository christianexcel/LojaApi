using System;
using System.ComponentModel.DataAnnotations;

namespace LojaApi.Infra.DTOs;

public class CriarPedidoDto
{
    [Required]
    public int ClienteId { get; set; }
    [Required]
    [MinLength(1)]
    public List<ItemPedidoPararCriarDto> Itens { get; set; } = new List<ItemPedidoPararCriarDto>();
}
