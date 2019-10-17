using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UGF.Builder.Runtime;

namespace UGF.Factory.Runtime
{
    /// <summary>
    /// Represents the generic collection of the factory builders stored by identifier.
    /// </summary>
    public class Factory<TIdentifier> : IFactory<TIdentifier>
    {
        public IReadOnlyDictionary<TIdentifier, IBuilder> Builders { get; }
        public Type IdentifierType { get; } = typeof(TIdentifier);

        private readonly Dictionary<TIdentifier, IBuilder> m_builders;

        /// <summary>
        /// Creates factory with the specified capacity and identifier comparer, if presents.
        /// </summary>
        /// <param name="capacity">The initial capacity of the builder collection.</param>
        /// <param name="comparer">The comparer of the identifiers.</param>
        public Factory(int capacity = 0, IEqualityComparer<TIdentifier> comparer = null)
        {
            m_builders = new Dictionary<TIdentifier, IBuilder>(capacity, comparer);

            Builders = new ReadOnlyDictionary<TIdentifier, IBuilder>(m_builders);
        }

        public void Add(TIdentifier identifier, IBuilder builder)
        {
            if (builder == null) throw new ArgumentNullException(nameof(builder));

            m_builders.Add(identifier, builder);
        }

        public bool Remove(TIdentifier identifier)
        {
            return m_builders.Remove(identifier);
        }

        public void Clear()
        {
            m_builders.Clear();
        }

        public T Get<T>(TIdentifier identifier) where T : IBuilder
        {
            if (!m_builders.TryGetValue(identifier, out IBuilder value))
            {
                throw new ArgumentException($"The builder not found by the specified identifier: '{identifier}'.");
            }

            return (T)value;
        }

        public bool TryGet<T>(TIdentifier identifier, out T builder) where T : IBuilder
        {
            if (m_builders.TryGetValue(identifier, out IBuilder value) && value is T result)
            {
                builder = result;
                return true;
            }

            builder = default;
            return false;
        }

        public bool TryGet(TIdentifier identifier, out IBuilder builder)
        {
            return m_builders.TryGetValue(identifier, out builder);
        }

        public Dictionary<TIdentifier, IBuilder>.Enumerator GetEnumerator()
        {
            return m_builders.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)m_builders).GetEnumerator();
        }
    }
}
