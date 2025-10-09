using System;
using LojaApi.Data;
using LojaApi.Entities;
using LojaApi.Repositories.Interfaces;

namespace LojaApi.Repositories;

public class ProdutoDBRepository : IProdutoRepository
{
    private readonly LojaContext _context;

    public ProdutoDBRepository(LojaContext context)
    {
        _context = context;
    }

    public List<Produto> ObterTodos()
    {
        return _context.Produtos.ToList();
    }

    public Produto? ObterPorId(int id)
    {
        return _context.Produtos.FirstOrDefault(p => p.Id == id);
    }

    public Produto Adicionar(Produto novoProduto)
    {
        _context.Produtos.Add(novoProduto);
        _context.SaveChanges();
        return novoProduto;
    }

    public Produto? Atualizar(int id, Produto produtoAtualizado)
    {
        _context.Produtos.Update(produtoAtualizado);
        _context.SaveChanges();
        return produtoAtualizado;
    }

    public bool Remover(int id)
    {
        var produtosParaDeletar = ObterPorId(id);
        if (produtosParaDeletar == null) return false;

        _context.Produtos.Remove(produtosParaDeletar);
        _context.SaveChanges();
        return true;
    }

}
