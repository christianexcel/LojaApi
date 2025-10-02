using System;
using LojaApi.Entities;

namespace LojaApi.Repositories;

public class ProdutoRepository
{
    private static int _nextId = 2;

    private static List<Produto> _produtos = new List<Produto>
    {
        new Produto { Id = 1, Descricao = "Laranja", Valor = 1.59m, Estoque = 1000.00m },
        new Produto { Id = 2, Descricao = "Sabonete", Valor = 2.50m, Estoque = 500.00m },
        new Produto { Id = 3, Descricao = "Biscoito", Valor = 3.50m, Estoque = 3.00m },
        new Produto { Id = 4, Descricao = "Bombom Lacta", Valor = 15.00m, Estoque = 99.00m }
    };

    public static List<Produto> GetAll()
    {
        return _produtos;
    }

    public static Produto? GetById(int id)
    {
        return _produtos.FirstOrDefault(p => p.Id == id);
    }

    public static Produto Add(Produto novoProduto)
    {
        novoProduto.Id = _nextId++;
        _produtos.Add(novoProduto);
        return novoProduto;
    }
    
    public static Produto? Update(int id, Produto produtoAtualizado)
    {
        var produtoExistente = _produtos.FirstOrDefault(p => p.Id == id);

        if (produtoExistente == null)
        {
            return null;
        }

        produtoExistente.Descricao = produtoAtualizado.Descricao;
        produtoExistente.Valor = produtoAtualizado.Valor;
        produtoExistente.Estoque = produtoAtualizado.Estoque;

        return produtoExistente;
    }

    public static bool Delete(int id)
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
