using Microsoft.Extensions.Configuration;

namespace CFBPoll.Utilities
{
    public class ConfigurationHelper
    {
        #region public methods

        /// <summary>
        /// Get a configuration setting.
        /// </summary>
        /// <param name="configurationName">The name of the configuration setting to get.</param>
        /// <returns>The value of the configuration setting.</returns>
        public static string GetConfiguration(string configurationName)
        {
            return GetConfiguration().GetSection($"AppSettings:{configurationName}").Value ?? string.Empty;
        }

        /// <summary>
        /// Get the connection string for the application.
        /// </summary>
        /// <returns>The application's connection string.</returns>
        public static string GetConnectionString()
        {
            return GetConfiguration().GetSection($"AppSettings:ConnectionString").Value ?? string.Empty;
        }

        #endregion

        #region private methods

        /// <summary>
        /// Get the IConfiguration object with the application settings.
        /// </summary>
        /// <returns>The IConfiguration object with the application settings.</returns>
        private static IConfiguration GetConfiguration()
        {
            var configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddJsonFile($"appsettings.json");
            return configurationBuilder.Build();
        }

        #endregion
    }
}
