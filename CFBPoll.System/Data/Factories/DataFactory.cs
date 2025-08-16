using CFBPoll.Utilities;

namespace CFBPoll.System.Data.Factories
{
    public static class DataFactory
    {
        /// <summary>
        /// Get the data provider for the given type.
        /// </summary>
        /// <typeparam name="T">The type of data provider to get.</typeparam>
        /// <returns>A concrete implementation of a data provider that implements the given type.</returns>
        public static T GetDataProvider<T>()
        {
            var interfaceType = typeof(T);
            var dataProviderName = interfaceType.Name.StartsWith("i", StringComparison.OrdinalIgnoreCase) //Don't assume the generic type is named with a preceeding "I"
                ? interfaceType.Name.Substring(1) //The data provider name is the interface name, minus the preceding "I".
                : interfaceType.Name;

            var dataProviderSource = GetDataProviderSource($"{dataProviderName}Provider"); //SQL, API, etc.
            var dataProvider = Type.GetType($"CFBPoll.System.Data.{dataProviderSource}.{dataProviderSource}{dataProviderName}, CFBPoll.System");

            //If there isn't an existing concrete object for this data provider, or it exists but doesn't implement the specified interface, throw an exception.
            if (dataProvider == null || !dataProvider.GetInterfaces().Any(i => interfaceType.Equals(i)))
                throw new Exception($"No {dataProviderName} Provider implementation exists for Type: {dataProviderSource}.");

            return (T)Activator.CreateInstance(dataProvider);
        }

        /// <summary>
        /// Checks to see if a unique data provider type has been specified for the named data provider, if not, returns the
        /// default data provider type that has been defined for this application.
        /// </summary>
        /// <param name="dataProviderName">The data provider name.</param>
        /// <returns>"SQL", "API", etc.</returns>
        private static string GetDataProviderSource(string dataProviderName)
        {
            var dataProviderSource = ConfigurationHelper.GetConfiguration($"{dataProviderName}Source");
            if (string.IsNullOrEmpty(dataProviderSource))
            {
                dataProviderSource = ConfigurationHelper.GetConfiguration($"{dataProviderName}Type");
                if (string.IsNullOrEmpty(dataProviderSource))
                {
                    dataProviderSource = ConfigurationHelper.GetConfiguration($"DataProviderType");
                    if (string.IsNullOrEmpty(dataProviderSource))
                    {
                        dataProviderSource = ConfigurationHelper.GetConfiguration($"DefaultDataProviderSource");
                        {
                            if (string.IsNullOrEmpty(dataProviderSource))
                                throw new Exception($"DefaultDataProviderSource has not been specified for the application.");
                        }
                    }
                }
            }

            return dataProviderSource;
        }
    }
}
