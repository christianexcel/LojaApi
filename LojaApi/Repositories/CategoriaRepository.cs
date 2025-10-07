using System;
using LojaApi.Entities;
using LojaApi.Repositories.Interfaces;

namespace LojaApi.Repositories;

public class CategoriaRepository : ICategoriaRepository
{
    private int _nextId = 4;

    public List<Categoria> _categorias = new List<Categoria>()
    {
        new Categoria { Id = 1, Descricao = "Frutas", Ativo = true}
    };

    public List<Categoria> ObterTodos()
    {
        return _categorias;
    }

    public Categoria? ObterPorId(int id)
    {
        var categoria = _categorias.FirstOrDefault(c => c.Id == id);
        if (categoria == null)
        {
            return null;
        }

        return categoria;
    }

    public Categoria Adicionar(Categoria novaCategoria)
    {
        _nextId++;
        novaCategoria.Id = _nextId;
        _categorias.Add(novaCategoria);
        return novaCategoria;
    }

    public Categoria? Atualizar(int id, Categoria categoriaAtualizada)
    {
        var categoriaExistente = _categorias.FirstOrDefault(c => c.Id == id);
        if (categoriaExistente == null)
        {
            return null;
        }

        categoriaExistente.Descricao = categoriaAtualizada.Descricao;
        categoriaExistente.Ativo = categoriaAtualizada.Ativo;

        return categoriaExistente;
    }

    public bool Remover(int id)
    {
        var categoriaParaDeletar = _categorias.FirstOrDefault(c => c.Id == id);
        if (categoriaParaDeletar != null)
        {
            categoriaParaDeletar.Ativo = false;
            Atualizar(id, categoriaParaDeletar);
            return true;
        }
        return false;
    }
}
