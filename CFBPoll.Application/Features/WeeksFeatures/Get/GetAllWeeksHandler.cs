using AutoMapper;
using CFBPoll.Application.Repository.WeeksRepository;
using MediatR;

namespace CFBPoll.Application.Features.WeeksFeatures.Get
{
    public sealed class GetAllWeeksHandler : IRequestHandler<GetAllWeeksRequest, GetAllWeeksResponse>
    {
        private readonly IWeeksRepository _weeksRepository;
        private readonly IMapper _mapper;

        public GetAllWeeksHandler(IWeeksRepository weeksRepository, IMapper mapper)
        {
            _weeksRepository = weeksRepository;
            _mapper = mapper;
        }

        public async Task<GetAllWeeksResponse> Handle(GetAllWeeksRequest request, CancellationToken cancellationToken)
        {
            var weeks = await _weeksRepository.GetAllWeeks(request, cancellationToken);
            return _mapper.Map<GetAllWeeksResponse>(weeks);
        }
    }
}
