using LojaApi.Entities;
using LojaApi.Infra.DTOs;

namespace LojaAPI.Services.Interfaces;

public interface IClienteService
{
    List<Cliente> ObterTodos();
    Cliente? ObterPorId(int id);
    Cliente Adicionar(CriarClienteDto clienteDto);
    Cliente? Atualizar(int id, Cliente clienteAtualizado);
    bool Remover(int id);
    ClienteDetalhadoDto? ObterDetalhesPorId(int id);
}