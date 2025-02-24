using AutoMapper;
using CFBPoll.Application.Repository.SeasonsRepository;
using MediatR;

namespace CFBPoll.Application.Features.SeasonsFeatures.Get
{
    public sealed class GetAllSeasonsHandler : IRequestHandler<GetAllSeasonsRequest, GetAllSeasonsResponse>
    {
        private readonly ISeasonsRepository _seasonsRepository;
        private readonly IMapper _mapper;

        public GetAllSeasonsHandler(ISeasonsRepository seasonsRepository, IMapper mapper)
        {
            _seasonsRepository = seasonsRepository;
            _mapper = mapper;
        }

        public async Task<GetAllSeasonsResponse> Handle(GetAllSeasonsRequest request, CancellationToken cancellationToken)
        {
            var seasons = await _seasonsRepository.GetAllSeasons(cancellationToken);
            return _mapper.Map<GetAllSeasonsResponse>(seasons);
        }
    }
}
