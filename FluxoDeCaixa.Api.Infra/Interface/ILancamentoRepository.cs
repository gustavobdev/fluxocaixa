using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluxoDeCaixa.Api.Domain.DataObjects;
using FluxoDeCaixa.Api.Domain.Domain;

namespace FluxoDeCaixa.Api.Infra.Interface;

public interface ILancamentoRepository
{
    Task<ResultViewModel> InsereLancamento(LancamentoDTO lancamentoDTO);

    Task<ResultViewModel> GetAllLancamentos();

    Task<List<LancamentoModel>> GetLancamentoByData(DateTime startTime, DateTime endTime);
}
