using LojaApi.Entities;
using LojaApi.Infra.DTOs;
using LojaApi.Repositories.Interfaces;
using LojaAPI.Services.Interfaces;

namespace LojaApi.Services;

public class ClienteService : IClienteService
{
    private readonly IClienteRepository _clienteRepository;

    public ClienteService(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    public List<Cliente> ObterTodos()
    {
        return _clienteRepository
            .ObterTodos()
            .Where(c => c.Ativo)
            .ToList();
    }

    public Cliente? ObterPorId(int id)
    {
        return _clienteRepository.ObterPorId(id);
    }

    public Cliente Adicionar(CriarClienteDto clienteDto)
    {
        var novoCliente = new Cliente
        {
            Nome = clienteDto.Nome.ToUpper(),
            Email = clienteDto.Email,
            Ativo = true,
            DataCadastro = DateTime.UtcNow,
            Endereco = clienteDto.Endereco != null ? new Endereco
            {
                Rua = clienteDto.Endereco.Rua,
                Cidade = clienteDto.Endereco.Cidade,
                Estado = clienteDto.Endereco.Estado,
                Cep = clienteDto.Endereco.Cep
            } : null
        };
        return _clienteRepository.Adicionar(novoCliente);
    }

    public ClienteDetalhadoDto? ObterDetalhesPorId(int id)
    {
        var cliente = _clienteRepository.ObterPorId(id);
        if (cliente == null) return null;

        return new ClienteDetalhadoDto
        {
            Id = cliente.Id,
            Nome = cliente.Nome,
            Email = cliente.Email,
            Ativo = cliente.Ativo,
            Endereco = cliente.Endereco != null ? new EnderecoDto
            {
                Rua = cliente.Endereco.Rua,
                Cidade = cliente.Endereco.Cidade,
                Estado = cliente.Endereco.Estado,
                Cep = cliente.Endereco.Cep
            } : null
        };
    }

    public Cliente? Atualizar(int id, Cliente clienteAtualizado)
    {
        if (id != clienteAtualizado.Id) return null;
        return _clienteRepository.Atualizar(id, clienteAtualizado);
    }

    public bool Remover(int id)
    {
        var cliente = _clienteRepository.ObterPorId(id);
        if (cliente != null)
        {
            cliente.Ativo = false;
            return _clienteRepository.Atualizar(id, cliente) != null;
        }

        return false;
    }

}
