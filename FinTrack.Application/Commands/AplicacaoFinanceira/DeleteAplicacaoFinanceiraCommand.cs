using MediatR;

namespace FinTrack.Application.Commands.AplicacoesFinanceiras;

public class DeleteAplicacaoFinanceiraCommand : IRequest<bool>
{
    public Guid Id { get; set; }
}
