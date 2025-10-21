using System;
using LojaApi.Infra.DTOs;
using LojaApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LojaApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PedidosController : ControllerBase
{
    private readonly IPedidoService _pedidoService;
    public PedidosController(IPedidoService pedidoService) { _pedidoService = pedidoService; }

    [HttpGet("{id}")]
    public ActionResult<PedidoDetalhadoDto> GetById(int id)
    {
        var pedidoDto = _pedidoService.ObterDetalhesPorId(id);
        if (pedidoDto == null) return NotFound();
        return Ok(pedidoDto);
    }

    [HttpPost]
    public ActionResult<PedidoDetalhadoDto> Add(CriarPedidoDto pedidoDto)
    {
        try
        {
            var pedidoCriado = _pedidoService.Adicionar(pedidoDto);
            var dtoRetorno = _pedidoService.ObterDetalhesPorId(pedidoCriado.Id);
            return CreatedAtAction(nameof(GetById), new { id = pedidoCriado.Id }, dtoRetorno);
        }
        catch (Exception ex) { return BadRequest(ex.Message);  }
    }

}