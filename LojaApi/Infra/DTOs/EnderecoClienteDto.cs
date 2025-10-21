using System;

namespace LojaApi.Infra.DTOs;

public class EnderecoClienteDto
{
    public int EnderecoId { get; set; }
    public string Rua { get; set; } = string.Empty;
    public string Cidade { get; set; } = string.Empty;
    public string Estado { get; set; } = string.Empty;
    public string Cep { get; set; } = string.Empty;
    
}
