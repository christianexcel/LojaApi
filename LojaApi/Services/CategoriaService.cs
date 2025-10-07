using System;
using LojaApi.Entities;
using LojaApi.Repositories.Interfaces;
using LojaApi.Services.Interfaces;

namespace LojaApi.Services;

public class CategoriaService : ICategoriaRepository
{
    private readonly ICategoriaRepository _categoriaRepository;

    public CategoriaService(ICategoriaRepository categoriaRepository)
    {
        _categoriaRepository = categoriaRepository;
    }

    public List<Categoria> ObterTodos()
    {
        return _categoriaRepository
            .ObterTodos()
            .Where(c => c.Ativo)
            .ToList();
    }

    public Categoria? ObterPorId(int id)
    {
        return _categoriaRepository.ObterPorId(id);
    }

    public Categoria Adicionar(Categoria novaCategoria)
    {
        novaCategoria.Ativo = true;
        return _categoriaRepository.Adicionar(novaCategoria);
    }

    public Categoria? Atualizar(int id, Categoria categoriaAtualizada)
    {
        if (id != categoriaAtualizada.Id)
        {
            return null;
        }
        return _categoriaRepository.Atualizar(id, categoriaAtualizada);
    }

    public bool Remover(int id)
    {
        return _categoriaRepository.Remover(id);
    }
}
