using AutoMapper;
using CFBPoll.Application.Repository.RankingsRepository;
using MediatR;

namespace CFBPoll.Application.Features.RankingsFeatures.Get
{
    public sealed class GetArchivedRankingsHandler : IRequestHandler<GetArchivedRankingsRequest, GetArchivedRankingsResponse>
    {
        private readonly IRankingsRepository _rankingsRepository;
        private readonly IMapper _mapper;

        public GetArchivedRankingsHandler(IRankingsRepository rankingsRepository, IMapper mapper)
        {
            _rankingsRepository = rankingsRepository;
            _mapper = mapper;
        }

        public async Task<GetArchivedRankingsResponse> Handle(GetArchivedRankingsRequest request, CancellationToken cancellationToken)
        {
            var rankings = await _rankingsRepository.GetRankings(request, cancellationToken);
            return _mapper.Map<GetArchivedRankingsResponse>(rankings);
        }
    }
}
