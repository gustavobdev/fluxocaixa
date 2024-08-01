using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluxoDeCaixa.Api.Domain.DataObjects;
using FluxoDeCaixa.Api.Domain.Domain;

namespace FluxoDeCaixa.Api.Service.Interface;

public interface ILancamentoService
{
    Task<ResultViewModel> InsereLancamento(LancamentoDTO lancamentoDTO);
    Task<ResultViewModel> GetAllLancamentos();
    Task<ResultViewModel> GetLancamentoByData(DateTime startTime, DateTime endTime);
}
