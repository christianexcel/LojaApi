using LojaApi.Entities;
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

    public Cliente Adicionar(Cliente novoCliente)
    {
        novoCliente.Nome = novoCliente.Nome.ToUpper();
        novoCliente.Ativo = true;
        return _clienteRepository.Adicionar(novoCliente);
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
