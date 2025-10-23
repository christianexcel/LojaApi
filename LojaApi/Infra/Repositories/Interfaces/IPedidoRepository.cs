using System;
using LojaApi.Entities;

namespace LojaApi.Infra.Repositories.Interfaces;

public interface IPedidoRepository
{
    Pedido? Adicionar(Pedido novoPedido);
    Pedido? ObterPorId(int id);
    List<Pedido> ObterTodos();
}
