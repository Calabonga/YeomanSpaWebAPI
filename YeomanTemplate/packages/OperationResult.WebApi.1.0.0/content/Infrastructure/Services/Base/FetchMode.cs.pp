namespace $rootnamespace$.Infrastructure.Services {
    /// <summary>
    /// Data fetch parameter
    /// </summary>
    public enum FetchMode {
        /// <summary>
        /// Return only entities without includes
        /// </summary>
        Simple,

        /// <summary>
        /// Returns entities with included navigation properties
        /// </summary>
        Expanded
    }
}