using System;
using AutoMapper;
using LojaApi.Entities;
using LojaApi.Infra.DTOs;
using LojaApi.Infra.Repositories.Interfaces;
using LojaApi.Services.Interfaces;

namespace LojaApi.Services;

public class PedidoService : IPedidoService
{
    private readonly IPedidoRepository _pedidoRepository;
    private readonly IClienteRepository _clienteRepository;
    private readonly IProdutoRepository _produtoRepository;
    private readonly IMapper _mapper;

    public PedidoService(IPedidoRepository pedidoRepository, IClienteRepository clienteRepository, IProdutoRepository produtoRepository, IMapper mapper)
    {
        _pedidoRepository = pedidoRepository;
        _clienteRepository = clienteRepository;
        _produtoRepository = produtoRepository;
        _mapper = mapper;
    }

    public Pedido Adicionar(CriarPedidoDto pedidoDto)
    {
        var cliente = _clienteRepository.ObterPorId(pedidoDto.ClienteId);
        if (cliente == null) throw new Exception("Cliente não encontrado.");

        var pedidoProdutos = new List<PedidoProduto>();
        decimal valorTotalCalculado = 0;

        foreach (var itemDto in pedidoDto.Itens)
        {
            var produto = _produtoRepository.ObterPorId(itemDto.ProdutoId);
            if (produto == null) throw new Exception($"Produto com ID {itemDto.ProdutoId} não encontrado.");
            if (produto.Estoque < itemDto.Quantidade) throw new Exception($"Estoque insuficiente para o produto {produto.Descricao}");

            pedidoProdutos.Add(new PedidoProduto
            {
                ProdutoId = itemDto.ProdutoId,
                Quantidade = itemDto.Quantidade
            });

            valorTotalCalculado += produto.Valor * itemDto.Quantidade;
            produto.Estoque -= itemDto.Quantidade;
        }

        var novoPedido = new Pedido
        {
            ClienteId = pedidoDto.ClienteId,
            DataPedido = DateTime.UtcNow,
            ValorTotal = valorTotalCalculado,
            PedidoProdutos = pedidoProdutos
        };

        var pedidoAdicionado = _pedidoRepository.Adicionar(novoPedido);

        return _pedidoRepository.ObterPorId(pedidoAdicionado.Id) ?? pedidoAdicionado;

    }

    public PedidoDetalhadoDto? ObterDetalhesPorId(int id)
    {
        var pedido = _pedidoRepository.ObterPorId(id);
        if (pedido == null) return null;
        return _mapper.Map<PedidoDetalhadoDto>(pedido);
    }

}
