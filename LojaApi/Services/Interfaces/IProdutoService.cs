using LojaApi.Entities;
using LojaApi.Infra.DTOs;

namespace LojaAPI.Services.Interfaces;

public interface IProdutoService
{
    List<Produto> ObterTodos();
    Produto? ObterPorId(int id);
    ProdutoDto Adicionar(CriarProdutoDto produtoDto);
    Produto? Atualizar(int id, Produto produtoAtualizado);
    ProdutoDetalhadoDto? ObterDetalhesPorId(int id);

    bool Remover(int id);
}