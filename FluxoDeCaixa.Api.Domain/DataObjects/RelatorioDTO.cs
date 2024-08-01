using FluxoDeCaixa.Api.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxoDeCaixa.Api.Domain.DataObjects;

public class RelatorioDTO
{
    public int Volume {get; set;}
    public decimal TotalDebito { get; set;}
    public decimal TotalCredito {  get; set;}
    public decimal Saldo { get; set;}
    public List<LancamentoModel> Lancamentos { get; set;}

}
