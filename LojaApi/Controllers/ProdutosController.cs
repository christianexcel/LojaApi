using LojaApi.Entities;
using LojaApi.Infra.DTOs;
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
        public ActionResult<ProdutoDetalhadoDto> GetById(int id)
        {
            var produto = _produtoService.ObterDetalhesPorId(id);

            if (produto == null)
            {
                return NotFound();
            }

            return Ok(produto);
        }

        [HttpPost]
        public ActionResult<Produto> Add(CriarProdutoDto produtoDto)
        {
            try
            {
                var produtoCriado = _produtoService.Adicionar(produtoDto);
                var dtoRetorno = _produtoService.ObterDetalhesPorId(produtoCriado.Id);

                return CreatedAtAction(nameof(GetById), new { id = produtoCriado.Id }, dtoRetorno);    
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
