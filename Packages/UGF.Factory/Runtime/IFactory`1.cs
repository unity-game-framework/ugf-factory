using System.Collections.Generic;
using UGF.Builder.Runtime;

namespace UGF.Factory.Runtime
{
    /// <summary>
    /// Represents the generic collection of the factory builders stored by identifier.
    /// </summary>
    public interface IFactory<TIdentifier> : IFactory, IEnumerable<KeyValuePair<TIdentifier, IBuilder>>
    {
        /// <summary>
        /// Gets or sets the builder by the specified identifier.
        /// </summary>
        /// <param name="identifier">The identifier of the builder.</param>
        IBuilder this[TIdentifier identifier] { get; set; }

        /// <summary>
        /// Determines whether the collection contains builder by the specified identifier.
        /// </summary>
        /// <param name="identifier">The identifier of the builder.</param>
        bool Contains(TIdentifier identifier);

        /// <summary>
        /// Determines whether the collection contains the specified builder.
        /// </summary>
        /// <param name="builder">The builder to check.</param>
        bool Contains(IBuilder builder);
        
        /// <summary>
        /// Adds the builder to collection by the specified identifier.
        /// </summary>
        /// <param name="identifier">The identifier of the builder to add by.</param>
        /// <param name="builder">The builder to add.</param>
        void Add(TIdentifier identifier, IBuilder builder);
        
        /// <summary>
        /// Removes builder from the collection by the specified identifier.
        /// <para>
        /// Returns true if the builder was removed, otherwise false.
        /// </para>
        /// </summary>
        /// <param name="identifier">The identifier of the builder to remove.</param>
        bool Remove(TIdentifier identifier);
        
        /// <summary>
        /// Clears collection form all builders.
        /// </summary>
        void Clear();
        
        /// <summary>
        /// Gets builder by the specified identifier.
        /// </summary>
        /// <param name="identifier">The identifier of the builder.</param>
        T Get<T>(TIdentifier identifier) where T : IBuilder;
        
        /// <summary>
        /// Tries to get builder by the specified identifier, if presents.
        /// <para>
        /// Returns true if builder was found, otherwise false.
        /// </para>
        /// </summary>
        /// <param name="identifier">The identifier of the builder to find.</param>
        /// <param name="builder">The found builder.</param>
        bool TryGet<T>(TIdentifier identifier, out T builder) where T : IBuilder;
        
        /// <summary>
        /// Tries to get builder by the specified identifier, if presents.
        /// <para>
        /// Returns true if builder was found, otherwise false.
        /// </para>
        /// </summary>
        /// <param name="identifier">The identifier of the builder to find.</param>
        /// <param name="builder">The found builder.</param>
        bool TryGet(TIdentifier identifier, out IBuilder builder);
    }
}