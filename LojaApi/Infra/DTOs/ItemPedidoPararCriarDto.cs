using System;
using System.ComponentModel.DataAnnotations;

namespace LojaApi.Infra.DTOs;

public class ItemPedidoPararCriarDto
{
    [Required]
    public int ProdutoId { get; set; }
    [Required]
    [Range(1, 100)]
    public int Quantidade { get; set; }
}
