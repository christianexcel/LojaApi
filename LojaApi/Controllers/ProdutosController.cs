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
            try
            {
                var produtoCriado = _produtoService.Adicionar(novoProduto);

                return CreatedAtAction(nameof(GetById), new { id = produtoCriado.Id }, produtoCriado);    
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        } 
        

        [HttpPut("{id}")] 
        public ActionResult<Produto> Update(int id, Produto produtoAtualizado) 
        {
            try
            {
                var produto = _produtoService.Atualizar(id, produtoAtualizado); 

                if (produto == null) 
                { 
                    return NotFound(); 
                } 

                return Ok(produto);  
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

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
