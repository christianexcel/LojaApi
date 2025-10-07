// Services/ClienteService.cs
using LojaApi.Entities;
using LojaApi.Repositories.Interfaces;
using LojaAPI.Services.Interfaces;

namespace LojaApi.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public List<Produto> ObterTodos()
        {
            return _produtoRepository.ObterTodos().Where(c => c.Ativo).ToList();
        }

        public Produto? ObterPorId(int id)
        {
            return _produtoRepository.ObterPorId(id);
        }

        public Produto Adicionar(Produto novoProduto)
        {
            novoProduto.Id = novoProduto.Id;
            novoProduto.Descricao = novoProduto.Descricao;
            novoProduto.Estoque = novoProduto.Estoque;
            novoProduto.Valor = novoProduto.Valor;
            
            return _produtoRepository.Adicionar(novoProduto);
        }

        public Produto? Atualizar(int id, Produto produtoAtualizado)
        {
            if (id != produtoAtualizado.Id) return null;
            return _produtoRepository.Atualizar(id, produtoAtualizado);
        }

        public bool Remover(int id)
        {
            var produto = _produtoRepository.ObterPorId(id);
            if (produto != null)
            {
                produto.Ativo = false;
                return _produtoRepository.Atualizar(id, produto) != null;
            }
            return false;
        }
    }
}