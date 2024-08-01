using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxoDeCaixa.Api.Domain.Domain;

public class ConnsolidadoModel
{
    public int Id { get; set; }
    public string Referencia { get; set; }
    public int? Data {  get; set; }
    public bool? Finalizado { get; set; }
}
