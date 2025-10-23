using System;

namespace LojaApi.Entities;

public class ClienteEndereco
{
    public int ClienteId { get; set; }
    public int EnderecoId { get; set; }
    public Cliente? Cliente { get; set; }
    public Endereco? Endereco { get; set; }
}
