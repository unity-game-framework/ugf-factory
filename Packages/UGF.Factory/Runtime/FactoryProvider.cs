using System;
using System.Collections;
using System.Collections.Generic;

namespace UGF.Factory.Runtime
{
    /// <summary>
    /// Represents collection of the factory collections stored by the type of the collection identifier.
    /// </summary>
    public class FactoryProvider : IFactoryProvider
    {
        public int Count { get { return m_collections.Count; } }
        public IFactoryCollection this[Type type] { get { return m_collections[type]; } }

        bool ICollection.IsSynchronized { get { return ((ICollection)m_collections).IsSynchronized; } }
        object ICollection.SyncRoot { get { return ((ICollection)m_collections).SyncRoot; } }

        private readonly Dictionary<Type, IFactoryCollection> m_collections;

        /// <summary>
        /// Creates provider with the specified capacity and identifier comparer, if presents.
        /// </summary>
        /// <param name="capacity">The initial capacity of the collection.</param>
        /// <param name="comparer">The comparer of the identifiers.</param>
        public FactoryProvider(int capacity = 0, IEqualityComparer<Type> comparer = null)
        {
            m_collections = new Dictionary<Type, IFactoryCollection>(capacity, comparer);
        }

        /// <summary>
        /// Creates provider from the specified collection of the collections and identifier comparer, if presents.
        /// </summary>
        /// <param name="dictionary">The collection of the factory collections.</param>
        /// <param name="comparer">The comparer of the identifiers.</param>
        public FactoryProvider(IDictionary<Type, IFactoryCollection> dictionary, IEqualityComparer<Type> comparer = null)
        {
            if (dictionary == null) throw new ArgumentNullException(nameof(dictionary));
            
            m_collections = new Dictionary<Type, IFactoryCollection>(dictionary, comparer);
        }

        public bool Contains(Type type)
        {
            return m_collections.ContainsKey(type);
        }

        public bool Contains(IFactoryCollection collection)
        {
            return m_collections.ContainsValue(collection);
        }

        public void Add(IFactoryCollection collection)
        {
            m_collections.Add(collection.IdentifierType, collection);
        }

        public bool Remove(IFactoryCollection collection)
        {
            return m_collections.Remove(collection.IdentifierType);
        }

        public void Clear()
        {
            m_collections.Clear();
        }

        public IFactoryCollection<T> Get<T>()
        {
            return (IFactoryCollection<T>)m_collections[typeof(T)];
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

        public void CopyTo(Array array, int index)
        {
            ((ICollection)m_collections).CopyTo(array, index);
        }

        public Dictionary<Type, IFactoryCollection>.Enumerator GetEnumerator()
        {
            return m_collections.GetEnumerator();
        }

        IEnumerator<KeyValuePair<Type, IFactoryCollection>> IEnumerable<KeyValuePair<Type, IFactoryCollection>>.GetEnumerator()
        {
            return ((IEnumerable<KeyValuePair<Type, IFactoryCollection>>)m_collections).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)m_collections).GetEnumerator();
        }
    }
}