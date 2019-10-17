using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace UGF.Factory.Runtime
{
    /// <summary>
    /// Represents collection of the factory collections stored by the type of the collection identifier.
    /// </summary>
    public class FactoryProvider : IFactoryProvider
    {
        public IReadOnlyDictionary<Type, IFactoryCollection> Collections { get; }

        private readonly Dictionary<Type, IFactoryCollection> m_collections;

        /// <summary>
        /// Creates provider with the specified capacity and identifier comparer, if presents.
        /// </summary>
        /// <param name="capacity">The initial capacity of the collection.</param>
        /// <param name="comparer">The comparer of the identifiers.</param>
        public FactoryProvider(int capacity = 0, IEqualityComparer<Type> comparer = null)
        {
            m_collections = new Dictionary<Type, IFactoryCollection>(capacity, comparer);

            Collections = new ReadOnlyDictionary<Type, IFactoryCollection>(m_collections);
        }

        public void Add(IFactoryCollection collection)
        {
            if (collection == null) throw new ArgumentNullException(nameof(collection));

            m_collections.Add(collection.IdentifierType, collection);
        }

        public bool Remove(IFactoryCollection collection)
        {
            if (collection == null) throw new ArgumentNullException(nameof(collection));

            return m_collections.Remove(collection.IdentifierType);
        }

        public void Clear()
        {
            m_collections.Clear();
        }

        public IFactoryCollection<T> Get<T>()
        {
            if (!m_collections.TryGetValue(typeof(T), out IFactoryCollection collection))
            {
                throw new ArgumentException($"The factory collection not found by the specified type: '{typeof(T)}'.");
            }

            return (IFactoryCollection<T>)collection;
        }

        public bool TryGet<T>(out IFactoryCollection<T> collection)
        {
            if (m_collections.TryGetValue(typeof(T), out IFactoryCollection value) && value is IFactoryCollection<T> result)
            {
                collection = result;
                return true;
            }

            collection = null;
            return false;
        }

        public bool TryGet(Type type, out IFactoryCollection collection)
        {
            return m_collections.TryGetValue(type, out collection);
        }

        public Dictionary<Type, IFactoryCollection>.Enumerator GetEnumerator()
        {
            return m_collections.GetEnumerator();
        }
    }
}
