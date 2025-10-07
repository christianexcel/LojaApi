using LojaApi.Entities;

namespace LojaAPI.Services.Interfaces;

public interface IProdutoService
{
    List<Produto> ObterTodos();
    Produto? ObterPorId(int id);
    Produto Adicionar(Produto novoProduto);
    Produto? Atualizar(int id, Produto produtoAtualizado);
    bool Remover(int id);
}