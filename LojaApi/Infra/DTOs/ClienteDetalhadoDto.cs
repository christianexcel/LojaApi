using System;
using System.Text.Json.Serialization;
using LojaApi.Entities;

namespace LojaApi.Infra.DTOs;

public class ClienteDetalhadoDto
{
    public int Id { get; set; }
    public String Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public bool Ativo { get; set; }
    public EnderecoDto? Endereco { get; set; }
}
