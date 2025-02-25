using CFBPoll.Application.Repository.RankingsRepository;
using CFBPoll.Application.Repository.SeasonsRepository;
using CFBPoll.Application.Repository.WeeksRepository;
using CFBPoll.Persistence.Repository.RankingsRepository;
using CFBPoll.Persistence.Repository.SeasonsRepository;
using CFBPoll.Persistence.Repository.WeeksRepository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CFBPoll.Persistence.Repository
{
    public static class ServiceExtensions
    {
        public static void ConfigurePersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IRankingsRepository, RankingRepository>();
            services.AddScoped<ISeasonsRepository, SeasonRepository>();
            services.AddScoped<IWeeksRepository, WeekRepository>();
        }
    }
}
