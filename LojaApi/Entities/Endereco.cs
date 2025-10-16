using System;

namespace LojaApi.Entities;

public class Endereco
{
    public int Id { get; set; }
    public string Rua { get; set; } = string.Empty;
    public string Cidade { get; set; } = string.Empty;
    public string Estado { get; set; } = string.Empty;
    public string Cep { get; set; } = string.Empty;
    public Cliente? Cliente { get; set; }
}
