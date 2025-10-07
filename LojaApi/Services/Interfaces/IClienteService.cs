using LojaApi.Entities;

namespace LojaAPI.Services.Interfaces;

public interface IClienteService
{
    List<Cliente> ObterTodos();
    Cliente? ObterPorId(int id);
    Cliente Adicionar(Cliente novoCliente);
    Cliente? Atualizar(int id, Cliente clienteAtualizado);
    bool Remover(int id);
}