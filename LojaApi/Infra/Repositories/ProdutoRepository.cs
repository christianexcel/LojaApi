using LojaApi.Entities;
using LojaApi.Infra.Repositories.Interfaces;

namespace LojaApi.Infra.Repositories;

public class ProdutoRepository : IProdutoRepository
{
    private int _nextId = 5;

    private List<Produto> _produtos = new List<Produto>
    {
        new Produto { Id = 1, Descricao = "Laranja", Valor = 1.59m, Estoque = 1000.00m, Ativo = true },
        new Produto { Id = 2, Descricao = "Sabonete", Valor = 2.50m, Estoque = 500.00m, Ativo = true },
        new Produto { Id = 3, Descricao = "Biscoito", Valor = 3.50m, Estoque = 3.00m, Ativo = true },
        new Produto { Id = 4, Descricao = "Bombom Lacta", Valor = 15.00m, Estoque = 99.00m, Ativo = true }
    };

    public List<Produto> ObterTodos()
    {
        return _produtos;
    }

    public Produto? ObterPorId(int id)
    {
        return _produtos.FirstOrDefault(p => p.Id == id);
    }

    public Produto Adicionar(Produto novoProduto)
    {
        novoProduto.Id = _nextId++;
        _produtos.Add(novoProduto);
        return novoProduto;
    }
    
    public Produto? Atualizar(int id, Produto produtoAtualizado)
    {
        var produtoExistente = _produtos.FirstOrDefault(p => p.Id == id);

        if (produtoExistente == null)
        {
            return null;
        }

        produtoExistente.Descricao = produtoAtualizado.Descricao;
        produtoExistente.Valor = produtoAtualizado.Valor;
        produtoExistente.Estoque = produtoAtualizado.Estoque;
        produtoExistente.Ativo = produtoAtualizado.Ativo;

        return produtoExistente;
    }

    public bool Remover(int id)
    {
        var produtoParaDeletar = _produtos.FirstOrDefault(p => p.Id == id);

        if (produtoParaDeletar == null)
        {
            return false;
        }

        _produtos.Remove(produtoParaDeletar);
        return true;
    }

}
