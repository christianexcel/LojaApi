using LojaApi.Entities;
using LojaApi.Infra.DTOs;
using LojaAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc; 

namespace LojaApi.Controllers 
{ 
    [ApiController] // Indica que esta classe é um Controlador de API (sem Views) 
    [Route("api/[controller]")] // Define a rota base: 'api/Clientes' 
    public class ClientesController : ControllerBase // Herda de ControllerBase (padrão para APIs) 
    { 
        private readonly IClienteService _clienteService;

        public ClientesController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }
        // ---------------------------------------------------- 
        // 1. GET - Ler Recursos 
        // ---------------------------------------------------- 

        // Endpoint: GET api/Clientes 
        [HttpGet]  
        public ActionResult<List<Cliente>> GetAll() 
        { 
            // 200 OK - Sucesso 
            return Ok(_clienteService.ObterTodos());  
        } 

        // Endpoint: GET api/Clientes/{id} 
        // O {id} é um parâmetro de rota 
        [HttpGet("{id}")]  
        public ActionResult<ClienteDetalhadoDto> GetById(int id) 
        { 
            var clienteDto = _clienteService.ObterDetalhesPorId(id);

            if (clienteDto == null) 
            { 
                // 404 Not Found - Recurso não encontrado 
                return NotFound(); 
            } 

            // 200 OK - Sucesso 
            return Ok(clienteDto);  
        } 

        // ---------------------------------------------------- 
        // 2. POST - Criar Recurso 
        // ----------------------------------------------------          
        // Endpoint: POST api/Clientes 
        [HttpPost]  
        public ActionResult<Cliente> Add(CriarClienteDto clienteDto)  
        {
            try
            {
                var clienteCriado = _clienteService.Adicionar(clienteDto);
                var dtoRetorno = _clienteService.ObterDetalhesPorId(clienteCriado.Id);

                // 201 Created - Novo recurso criado com sucesso 
                // Retorna o recurso criado e a URL para acessá-lo (boa prática REST) 
                return CreatedAtAction(nameof(GetById), new { id = clienteCriado.Id }, dtoRetorno);  
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        } 

        // ---------------------------------------------------- 
        // 3. PUT - Atualizar/Substituir Recurso (Completo) 
        // ---------------------------------------------------- 

        // Endpoint: PUT api/Clientes/{id} 
        [HttpPut("{id}")] 
        public ActionResult<Cliente> Update(int id, Cliente clienteAtualizado) 
        {
            try
            {
                var cliente = _clienteService.Atualizar(id, clienteAtualizado); 

                if (cliente == null) 
                { 
                    // 404 Not Found - Tentou atualizar algo que não existe 
                    return NotFound(); 
                } 

                // 200 OK - Sucesso (Recurso substituído) 
                return Ok(cliente);  
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        } 

        // ---------------------------------------------------- 
        // 4. DELETE - Excluir Recurso 
        // ---------------------------------------------------- 

        // Endpoint: DELETE api/Clientes/{id} 
        [HttpDelete("{id}")] 
        public IActionResult Delete(int id) // Usamos IActionResult pois não retornaremos um objeto Cliente 
        { 
            var sucesso = _clienteService.Remover(id); 

            if (!sucesso) 
            { 
                // 404 Not Found - Tentou deletar algo que não existe 
                return NotFound(); 
            } 

            // 204 No Content - Sucesso, mas não há corpo de resposta (padrão REST para DELETE) 
            return NoContent();  
        } 
    } 
} 