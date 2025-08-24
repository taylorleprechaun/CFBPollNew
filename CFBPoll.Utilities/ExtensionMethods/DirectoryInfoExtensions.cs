namespace CFBPoll.Utilities.ExtensionMethods
{
    public static class DirectoryInfoExtensions
    {
        /// <summary>
        /// Gets files in the directory that match the specified extensions.
        /// </summary>
        /// <param name="dirInfo">The directory to get files from.</param>
        /// <param name="extensions">An array of valid file extensions.</param>
        /// <returns>A collection of FileInfo for files with matching extensions.</returns>
        public static IEnumerable<FileInfo> GetFilesByExtensions(this DirectoryInfo dirInfo, params string[] extensions)
        {
            var allowedExtensions = new HashSet<string>(extensions, StringComparer.OrdinalIgnoreCase);
            return dirInfo.EnumerateFiles().Where(f => allowedExtensions.Contains(f.Extension));
        }
    }
}
