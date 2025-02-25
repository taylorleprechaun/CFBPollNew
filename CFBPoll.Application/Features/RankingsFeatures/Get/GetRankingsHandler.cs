using AutoMapper;
using CFBPoll.Application.Repository.RankingsRepository;
using MediatR;

namespace CFBPoll.Application.Features.RankingsFeatures.Get
{
    public sealed class GetRankingsHandler : IRequestHandler<GetRankingsRequest, GetRankingsResponse>
    {
        private readonly IRankingsRepository _rankingsRepository;
        private readonly IMapper _mapper;

        public GetRankingsHandler(IRankingsRepository rankingsRepository, IMapper mapper)
        {
            _rankingsRepository = rankingsRepository;
            _mapper = mapper;
        }

        public async Task<GetRankingsResponse> Handle(GetRankingsRequest request, CancellationToken cancellationToken)
        {
            var rankings = await _rankingsRepository.GetRankings(request, cancellationToken);
            return _mapper.Map<GetRankingsResponse>(rankings);
        }
    }
}
