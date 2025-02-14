using FinTrack.Domain.DTOs;
using MediatR;

namespace FinTrack.Application.Queries.ControlesMensal;

public class GetControleMensalResumoQuery : IRequest<ControleMensalResumoDto>
{
    public Guid IdUsuario { get; set; }
    public string Mes { get; set; }
    public string Ano { get; set; }

    public GetControleMensalResumoQuery(Guid idUsuario, string mes, string ano)
    {
        IdUsuario = idUsuario;
        Mes = mes;
        Ano = ano;
    }
}
