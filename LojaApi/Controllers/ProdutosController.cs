using LojaApi.Entities;
using LojaAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LojaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {

        private readonly IProdutoService _produtoService;

        public ProdutosController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet]
        public ActionResult<List<Produto>> GetAll()
        {
            var produtos = _produtoService.ObterTodos();
            return Ok(produtos);
        }

        [HttpGet("{id}")]
        public ActionResult<Produto> GetById(int id)
        {
            var produto = _produtoService.ObterPorId(id);

            if (produto == null)
            {
                return NotFound();
            }

            return Ok(produto);
        }

        [HttpPost]
        public ActionResult<Produto> Add(Produto novoProduto)
        {
            if (string.IsNullOrWhiteSpace(novoProduto.Descricao))
            {
                return BadRequest("A descrição do produto é obrigatória.");
            }

            if (Decimal.IsNegative(novoProduto.Valor))
            {
                return BadRequest("O valor não pode ser negativo");
            }

            if (Decimal.IsNegative(novoProduto.Estoque))
            {
                return BadRequest("O estoque não pode ser negativo");
            }

            var produtoCriado = _produtoService.Adicionar(novoProduto);

            return CreatedAtAction(nameof(GetById), new { id = produtoCriado.Id }, produtoCriado);
        } 
        

        [HttpPut("{id}")] 
        public ActionResult<Produto> Update(int id, Produto produtoAtualizado) 
        { 
            if (string.IsNullOrWhiteSpace(produtoAtualizado.Descricao)) 
            { 
                return BadRequest("A descrição do produto é obrigatória para atualização.");  
            } 

            if (Decimal.IsNegative(produtoAtualizado.Valor))
            {
                return BadRequest("O valor não pode ser negativo");
            }

            if (Decimal.IsNegative(produtoAtualizado.Estoque))
            {
                return BadRequest("O estoque não pode ser negativo");
            }

            var produto = _produtoService.Atualizar(id, produtoAtualizado); 

            if (produto == null) 
            { 
                return NotFound(); 
            } 

            return Ok(produto);  
        } 

        [HttpDelete("{id}")] 
        public IActionResult Delete(int id)
        { 
            var sucesso = _produtoService.Remover(id); 

            if (!sucesso) 
            { 
                return NotFound(); 
            } 
            return NoContent();
        } 
    }

}
