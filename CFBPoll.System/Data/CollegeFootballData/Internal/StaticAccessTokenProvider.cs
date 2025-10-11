using Microsoft.Kiota.Abstractions.Authentication;

namespace CFBPoll.System.Data.CollegeFootballData.Internal
{
    internal class StaticAccessTokenProvider : IAccessTokenProvider
    {
        private readonly string _token;

        public StaticAccessTokenProvider(string token)
        {
            _token = token ?? throw new ArgumentNullException(nameof(token));
        }

        public Task<string> GetAuthorizationTokenAsync(Uri uri, Dictionary<string, object>? additionalAuthenticationContext = null, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(_token);
        }

        public AllowedHostsValidator AllowedHostsValidator { get; } = new AllowedHostsValidator();
    }
}
