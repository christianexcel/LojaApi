using System;
using System.ComponentModel.DataAnnotations;

namespace LojaApi.Infra.DTOs;

public class CriarClienteDto
{

    [Required(ErrorMessage = "O nome do cliente é obrigatório.")]
    [MaxLength(100, ErrorMessage = "O nome do cliente não pode exceder 100 caracteres.")]
    [MinLength(3, ErrorMessage = "O nome do cliente deve ter no mínimo 3 caracteres.")]
    public string Nome { get; set; } = string.Empty;
    [Required(ErrorMessage = "O email do cliente é obrigatório.")]
    [EmailAddress(ErrorMessage = "O email do cliente deve ser válido.")]
    public string Email { get; set; } = string.Empty;
    [Required(ErrorMessage = "O endereço do cliente é obrigatório.")]
    public EnderecoDto? Endereco { get; set; }
}
