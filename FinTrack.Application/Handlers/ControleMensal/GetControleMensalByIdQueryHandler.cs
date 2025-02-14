using FinTrack.Application.Queries.ControlesMensal;
using FinTrack.Domain.Entities;
using FinTrack.Domain.Interfaces;
using MediatR;

namespace FinTrack.Application.Handlers.ControlesMensal
{
    public class GetControleMensalByIdQueryHandler : IRequestHandler<GetControleMensalByIdQuery, ControleMensal>
    {
        private readonly IControleMensalRepository _controleMensalRepository;

        public GetControleMensalByIdQueryHandler(IControleMensalRepository controleMensalRepository)
        {
            _controleMensalRepository = controleMensalRepository;
        }

        public async Task<ControleMensal> Handle(GetControleMensalByIdQuery request, CancellationToken cancellationToken)
        {
            return await _controleMensalRepository.GetByIdAsync(request.Id);
        }
    }
}
