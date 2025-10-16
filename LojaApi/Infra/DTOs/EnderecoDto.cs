using System;
using System.ComponentModel.DataAnnotations;

namespace LojaApi.Infra.DTOs;

public class EnderecoDto
{
    [Required]
    public string Rua { get; set; } = string.Empty;
    [Required]
    public string Cidade { get; set; } = string.Empty;
    [Required]
    public string Estado { get; set; } = string.Empty;
    [Required]
    public string Cep { get; set; } = string.Empty;
}
