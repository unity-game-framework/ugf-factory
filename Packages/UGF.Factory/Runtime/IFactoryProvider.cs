using System;
using System.Collections.Generic;

namespace UGF.Factory.Runtime
{
    /// <summary>
    /// Represents collection of the factory collections stored by the type of the collection identifier.
    /// </summary>
    public interface IFactoryProvider
    {
        /// <summary>
        /// Gets the collection of the factory collections.
        /// </summary>
        IReadOnlyDictionary<Type, IFactoryCollection> Collections { get; }

        /// <summary>
        /// Adds the factory collection by its identifier type.
        /// </summary>
        /// <param name="collection">The factory collection to add.</param>
        void Add(IFactoryCollection collection);

        /// <summary>
        /// Removes the factory collection by its identifier type.
        /// </summary>
        /// <param name="collection">The factory collection to remove.</param>
        bool Remove(IFactoryCollection collection);

        /// <summary>
        /// Clears collection from all factory collections.
        /// </summary>
        void Clear();

        /// <summary>
        /// Gets factory collection by the specified identifier type.
        /// </summary>
        IFactoryCollection<T> Get<T>();

        /// <summary>
        /// Tries to get factory collection by the specified identifier type.
        /// <para>
        /// Returns true if the factory collection was removed, otherwise false.
        /// </para>
        /// </summary>
        /// <param name="collection">The found factory collection.</param>
        bool TryGet<T>(out IFactoryCollection<T> collection);

        /// <summary>
        /// Tries to get factory collection by the specified identifier type.
        /// <para>
        /// Returns true if the factory collection was removed, otherwise false.
        /// </para>
        /// </summary>
        /// <param name="type">The type of the identifier.</param>
        /// <param name="collection">The found factory collection.</param>
        bool TryGet(Type type, out IFactoryCollection collection);
    }
}
