namespace UGF.Factory.Runtime
{
    /// <summary>
    /// Represents the define of the factory.
    /// </summary>
    public interface IFactoryDefine<TFactoryId, TBuilderId> : IFactoryDefine
    {
        /// <summary>
        /// Registers builder into the specified factory.
        /// </summary>
        /// <param name="provider">The factory provider.</param>
        /// <param name="collection">The factory collection from the provider.</param>
        /// <param name="factory">The factory from the collection.</param>
        void RegisterBuilders(IFactoryProvider provider, IFactoryCollection<TFactoryId> collection, IFactory<TBuilderId> factory);

        /// <summary>
        /// Gets the factory from the factory collection.
        /// <para>
        /// If the factory does not exists, will create and add to the factory collection.
        /// </para>
        /// </summary>
        /// <param name="provider">The factory provider.</param>
        /// <param name="collection">The factory collection from the provider.</param>
        IFactory<TBuilderId> GetFactory(IFactoryProvider provider, IFactoryCollection<TFactoryId> collection);

        /// <summary>
        /// Creates the factory for the specified factory collection.
        /// </summary>
        /// <param name="provider">The factory provider.</param>
        /// <param name="collection">The factory collection from the provider.</param>
        IFactory<TBuilderId> CreateFactory(IFactoryProvider provider, IFactoryCollection<TFactoryId> collection);
        
        /// <summary>
        /// Gets the identifier of the factory.
        /// </summary>
        /// <param name="provider">The factory provider.</param>
        /// <param name="collection">The factory collection from the provider.</param>
        TFactoryId GetFactoryId(IFactoryProvider provider, IFactoryCollection<TFactoryId> collection);
    }
}