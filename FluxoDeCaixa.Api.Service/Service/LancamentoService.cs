using FluxoDeCaixa.Api.Domain.DataObjects;
using FluxoDeCaixa.Api.Domain.Domain;
using FluxoDeCaixa.Api.Infra.Interface;
using FluxoDeCaixa.Api.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxoDeCaixa.Api.Service.Service;

public class LancamentoService : ILancamentoService
{

    readonly ILancamentoRepository _lancamentoRepository;

    public LancamentoService(ILancamentoRepository lancamentoRepository)
    {
        _lancamentoRepository = lancamentoRepository;
    }

    public async Task<ResultViewModel> GetAllLancamentos()
    {
        var result = await _lancamentoRepository.GetAllLancamentos();

        return result;
    }

    public async Task<ResultViewModel> GetLancamentoByData(DateTime startTime, DateTime endTime)
    {

        //exemplo básico de condicional
        if (endTime < startTime)
        {
            var condicao = new ResultViewModel
            {
                Data = "",
                Message = "A data final não pode ser inferior à data inicial",
                Success = false
            };

            return condicao;
        }


        List<LancamentoModel>  listaDeLancamentos = await _lancamentoRepository.GetLancamentoByData(startTime, endTime);


        decimal totalDebito = 0;
        decimal totalCredito = 0;

        foreach(var lancamento in listaDeLancamentos)
        {
            if (lancamento.Tipo == 1)
            {
                totalCredito = totalCredito + lancamento.valor;
            }
            else
            {
                totalDebito = totalDebito + lancamento.valor;
            }
        }

        var Data = new RelatorioDTO()
        {
            Volume = listaDeLancamentos.Count,
            Lancamentos = listaDeLancamentos,
            Saldo = totalCredito - totalDebito,
            TotalCredito = totalCredito,
            TotalDebito = totalDebito
        };

        var Result = new ResultViewModel()
        {
            Data = Data,
            Message = "Resultado encontrado",
            Success = true
        };

        return Result;
    }

    public async Task<ResultViewModel> InsereLancamento(LancamentoDTO lancamentoDTO)
    {
        var result = await _lancamentoRepository.InsereLancamento(lancamentoDTO);

        return result;
    }

    public async Task<ResultViewModel> PostConsolidado(ConnsolidadoDTO consolidadoDTO)
    {
        if (consolidadoDTO.Lancamentos != null)
        {

            var Result = await _lancamentoRepository.PostConsolidado(consolidadoDTO);
            return Result;

           
        }
        else
        {
            var condicao = new ResultViewModel
            {
                Data = "",
                Message = "Informe ao menos um lançamento para realizar a consolidação",
                Success = false
            };

            return condicao;
        }

        
    }
}
