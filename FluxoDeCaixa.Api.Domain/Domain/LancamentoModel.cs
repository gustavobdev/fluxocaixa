using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxoDeCaixa.Api.Domain.Domain;


public class LancamentoModel
{
    public int ID { get; set; }

    public string Descricao { get; set; }

    public decimal valor { get; set;}

    public int Tipo { get; set; }

    public DateTime Data {  get; set; }

    public int? Consolidado { get; set; }
}
