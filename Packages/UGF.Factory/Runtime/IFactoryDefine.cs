using System;

namespace UGF.Factory.Runtime
{
    /// <summary>
    /// Represents the define of the factory.
    /// </summary>
    public interface IFactoryDefine
    {
        /// <summary>
        /// Gets the type of the factories identifier.
        /// </summary>
        Type FactoryIdentifierType { get; }
        
        /// <summary>
        /// Gets the type of the builders identifier.
        /// </summary>
        Type BuilderIdentifierType { get; }

        /// <summary>
        /// Registers builder into the specified factory.
        /// </summary>
        /// <param name="provider">The factory provider.</param>
        /// <param name="collection">The factory collection from the provider.</param>
        /// <param name="factory">The factory from the collection.</param>
        void RegisterBuilders(IFactoryProvider provider, IFactoryCollection collection, IFactory factory);
        
        /// <summary>
        /// Gets the factory collection from the provider.
        /// <para>
        /// If the factory collection does not exists, will create and add to the provider.
        /// </para>
        /// </summary>
        /// <param name="provider">The factory provider to get from.</param>
        IFactoryCollection GetCollection(IFactoryProvider provider);
        
        /// <summary>
        /// Gets the factory from the factory collection.
        /// <para>
        /// If the factory does not exists, will create and add to the factory collection.
        /// </para>
        /// </summary>
        /// <param name="provider">The factory provider.</param>
        /// <param name="collection">The factory collection from the provider.</param>
        IFactory GetFactory(IFactoryProvider provider, IFactoryCollection collection);
        
        /// <summary>
        /// Creates the factory collection for the specified provider.
        /// </summary>
        /// <param name="provider">The factory provider.</param>
        IFactoryCollection CreateCollection(IFactoryProvider provider);
        
        /// <summary>
        /// Creates the factory for the specified factory collection.
        /// </summary>
        /// <param name="provider">The factory provider.</param>
        /// <param name="collection">The factory collection from the provider.</param>
        IFactory CreateFactory(IFactoryProvider provider, IFactoryCollection collection);
    }
}