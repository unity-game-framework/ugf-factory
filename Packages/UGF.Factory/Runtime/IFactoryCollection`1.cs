using System.Collections.Generic;

namespace UGF.Factory.Runtime
{
    /// <summary>
    /// Represents generic collection of the factories stored by identifier.
    /// </summary>
    public interface IFactoryCollection<TIdentifier> : IFactoryCollection
    {
        /// <summary>
        /// Gets the collection of the factories.
        /// </summary>
        IReadOnlyDictionary<TIdentifier, IFactory> Factories { get; }

        /// <summary>
        /// Adds the factory to collection by the specified identifier.
        /// </summary>
        /// <param name="identifier">The identifier of the factory to add by.</param>
        /// <param name="factory">The factory to add.</param>
        void Add(TIdentifier identifier, IFactory factory);

        /// <summary>
        /// Removes factory from collection by the specified identifier.
        /// <para>
        /// Returns true if the factory was removed, otherwise false.
        /// </para>
        /// </summary>
        /// <param name="identifier">The identifier of the factory to remove.</param>
        bool Remove(TIdentifier identifier);

        /// <summary>
        /// Clears collection from the all factories.
        /// </summary>
        void Clear();

        /// <summary>
        /// Gets factory be the specified identifier.
        /// </summary>
        /// <param name="identifier">The identifier of the factory.</param>
        T Get<T>(TIdentifier identifier) where T : IFactory;

        /// <summary>
        /// Tries to get factory by the specified identifier, if presents.
        /// <para>
        /// Returns true if factory was found, otherwise false.
        /// </para>
        /// </summary>
        /// <param name="identifier">The identifier of the factory to find.</param>
        /// <param name="factory">The found factory.</param>
        bool TryGet<T>(TIdentifier identifier, out T factory) where T : IFactory;

        /// <summary>
        /// Tries to get factory by the specified identifier, if presents.
        /// <para>
        /// Returns true if factory was found, otherwise false.
        /// </para>
        /// </summary>
        /// <param name="identifier">The identifier of the factory to find.</param>
        /// <param name="factory">The found factory.</param>
        bool TryGet(TIdentifier identifier, out IFactory factory);
    }
}
