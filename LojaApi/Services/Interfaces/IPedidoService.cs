using System;
using LojaApi.Entities;
using LojaApi.Infra.DTOs;

namespace LojaApi.Services.Interfaces;

public interface IPedidoService
{
    Pedido Adicionar(CriarPedidoDto pedidoDto);
    PedidoDetalhadoDto? ObterDetalhesPorId(int id);
}
