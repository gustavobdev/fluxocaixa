using FluxoDeCaixa.Api.Domain.DataObjects;
using FluxoDeCaixa.Api.Infra.Interface;
using FluxoDeCaixa.Api.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace FluxoDeCaixa.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class LancamentoController : ControllerBase
{
    readonly ILancamentoService _lancamentoService;

    public LancamentoController(ILancamentoService lancamentoService)
    {
        _lancamentoService = lancamentoService;
    }



    [HttpPost(Name = "EnviaLançamento")]
    public async Task<IActionResult> InsereLancamento(LancamentoDTO lancamentoDTO)
    {
		try
		{
            var objects = await _lancamentoService.InsereLancamento(lancamentoDTO);

            if (objects != null)
            {
                return Ok(objects);
            }
            else
            {
                return NotFound(objects);
            }


        }
        catch (Exception)
		{
            return BadRequest(new ResultViewModel
            {
                Message = "Erro ao processar sua solicitação",
                Success = false,
                Data = ""
            });
        }
    }



    [HttpGet]
    public async Task<IActionResult> GetAllLancamentos()
    {
        try
        {
            var objects = await _lancamentoService.GetAllLancamentos();

            if (objects != null)
            {
                return Ok(objects);
            }
            else
            {
                return NotFound(objects);
            }
        }
        catch (Exception)
        {
            return BadRequest(new ResultViewModel
            {
                Message = "Erro ao processar sua solicitação",
                Success = false,
                Data = ""
            });
        }
    }


    [HttpGet("FiltroPorData")]
    public async Task<IActionResult> GetLancamentoByData(DateTime startTime, DateTime endTime)
    {
        try
        {
            var objects = await _lancamentoService.GetLancamentoByData(startTime, endTime);

            if (objects != null)
            {
                return Ok(objects);
            }
            else
            {
                return NotFound(objects);
            }
        }
        catch (Exception)
        {
            return BadRequest(new ResultViewModel
            {
                Message = "Erro ao processar sua solicitação",
                Success = false,
                Data = ""
            });
        }
    }



}
