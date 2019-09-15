using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace UGF.Factory.Runtime
{
    /// <summary>
    /// Represents generic collection of the factories stored by identifier.
    /// </summary>
    public class FactoryCollection<TIdentifier> : IFactoryCollection<TIdentifier>
    {
        public IReadOnlyDictionary<TIdentifier, IFactory> Factories { get; }
        public Type IdentifierType { get; } = typeof(TIdentifier);

        private readonly Dictionary<TIdentifier, IFactory> m_factories;

        /// <summary>
        /// Creates factory collection with the specified capacity and identifier comparer, if presents.
        /// </summary>
        /// <param name="capacity">The initial capacity of the factory collection.</param>
        /// <param name="comparer">The comparer of the identifiers.</param>
        public FactoryCollection(int capacity = 0, IEqualityComparer<TIdentifier> comparer = null)
        {
            m_factories = new Dictionary<TIdentifier, IFactory>(capacity, comparer);

            Factories = new ReadOnlyDictionary<TIdentifier, IFactory>(m_factories);
        }

        public void Add(TIdentifier identifier, IFactory factory)
        {
            m_factories.Add(identifier, factory);
        }

        public bool Remove(TIdentifier identifier)
        {
            return m_factories.Remove(identifier);
        }

        public void Clear()
        {
            m_factories.Clear();
        }

        public T Get<T>(TIdentifier identifier) where T : IFactory
        {
            return (T)m_factories[identifier];
        }

        public bool TryGet<T>(TIdentifier identifier, out T factory) where T : IFactory
        {
            if (m_factories.TryGetValue(identifier, out IFactory value) && value is T result)
            {
                factory = result;
                return true;
            }

            factory = default;
            return false;
        }

        public bool TryGet(TIdentifier identifier, out IFactory factory)
        {
            return m_factories.TryGetValue(identifier, out factory);
        }

        public Dictionary<TIdentifier, IFactory>.Enumerator GetEnumerator()
        {
            return m_factories.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)m_factories).GetEnumerator();
        }
    }
}
