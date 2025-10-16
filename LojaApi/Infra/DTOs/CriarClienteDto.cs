using System;
using System.ComponentModel.DataAnnotations;

namespace LojaApi.Infra.DTOs;

public class CriarClienteDto
{
    [Required]
    public string Nome { get; set; } = string.Empty;
    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;
    public EnderecoDto? Endereco { get; set; }
}
