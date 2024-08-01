using FluxoDeCaixa.Api.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxoDeCaixa.Api.Domain.DataObjects;

public class ConnsolidadoDTO
{
    public string Referencia { get; set; }
    public List<LancamentoModel> Lancamentos { get; set; }
}
