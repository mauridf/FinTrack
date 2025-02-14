using FinTrack.Application.Queries.FontesPagamento;
using FinTrack.Domain.Entities;
using FinTrack.Domain.Interfaces;
using MediatR;

namespace FinTrack.Application.Handlers.FontesPagamento
{
    public class GetFontePagamentoByUserQueryHandler : IRequestHandler<GetFontePagamentoByUserQuery, IEnumerable<FontePagamento>>
    {
        private readonly IFontePagamentoRepository _repository;

        public GetFontePagamentoByUserQueryHandler(IFontePagamentoRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<FontePagamento>> Handle(GetFontePagamentoByUserQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetByIdUserAsync(request.IdUser);
        }
    }
}
