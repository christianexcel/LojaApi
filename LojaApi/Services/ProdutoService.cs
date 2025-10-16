using LojaApi.Entities;
using LojaApi.Infra.DTOs;
using LojaApi.Infra.Repositories.Interfaces;
using LojaAPI.Services.Interfaces;

namespace LojaApi.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly ICategoriaRepository _categoriaRepository;

        public ProdutoService(
            IProdutoRepository produtoRepository,
            ICategoriaRepository categoriaRepository
        )
        {
            _produtoRepository = produtoRepository;
            _categoriaRepository = categoriaRepository;
        }

        public List<Produto> ObterTodos()
        {
            return _produtoRepository
                .ObterTodos()
                .Where(p => p.Ativo && p.Estoque > 0)
                .ToList();
        }

        public Produto? ObterPorId(int id)
        {
            return _produtoRepository.ObterPorId(id);
        }

        public ProdutoDto Adicionar(CriarProdutoDto produtoDto)
        {
            /*var categoria = _categoriaRepository.ObterPorId(novoProduto.CategoriaId);
            if (categoria == null)
            {
                throw new Exception("A categoria informada não existe");
            }

            if (categoria.Descricao.Equals("Eletrônicos", StringComparison.OrdinalIgnoreCase) && novoProduto.Valor < 50.00m)
            {
                throw new Exception("Produtos da categoria 'Eletrônicos' devem custar no mínimo R$50,00.");
            }*/

            var novoProduto = new Produto
            {
                Descricao = produtoDto.Descricao,
                Valor = produtoDto.Valor,
                Ativo = produtoDto.Ativo,
                Estoque = produtoDto.Estoque,
                CategoriaId = produtoDto.CategoriaId,
                Categoria = produtoDto.Categoria != null ? new Categoria
                {
                    Descricao = produtoDto.Categoria.Descricao,
                    Ativo = produtoDto.Categoria.Ativo
                } : null
            };

            var produtoRetorno = _produtoRepository.Adicionar(novoProduto);

            return new ProdutoDto
            {
                Id = produtoRetorno.Id,
                Descricao = produtoRetorno.Descricao,
                Valor = produtoRetorno.Valor,
                Estoque = produtoRetorno.Estoque,
                Ativo = produtoRetorno.Ativo,
                CategoriaId = produtoRetorno.CategoriaId
            };
        }

        public ProdutoDetalhadoDto? ObterDetalhesPorId(int id)
        {
            var produto = _produtoRepository.ObterPorId(id);
            if (produto == null) return null;

            return new ProdutoDetalhadoDto
            {
                Id = produto.Id,
                Descricao = produto.Descricao,
                Valor = produto.Valor,
                Estoque = produto.Estoque,
                Ativo = produto.Ativo,
                CategoriaId = produto.CategoriaId,
                Categoria = produto.Categoria != null ? new CategoriaDto
                {
                    Id = produto.Categoria.Id,
                    Descricao = produto.Categoria.Descricao,
                    Ativo = produto.Categoria.Ativo
                } : null
            };
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