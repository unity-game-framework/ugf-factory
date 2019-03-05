using System;
using System.Collections;
using System.Collections.Generic;
using UGF.Builder.Runtime;

namespace UGF.Factory.Runtime
{
    /// <summary>
    /// Represents the generic collection of the factory builders stored by identifier.
    /// </summary>
    public class Factory<TIdentifier> : IFactory<TIdentifier>
    {
        public int Count { get { return m_builders.Count; } }
        public IBuilder this[TIdentifier identifier] { get { return m_builders[identifier]; } set { m_builders[identifier] = value; } }
        public Type IdentifierType { get; } = typeof(TIdentifier);

        bool ICollection.IsSynchronized { get { return ((ICollection)m_builders).IsSynchronized; } }
        object ICollection.SyncRoot { get { return ((ICollection)m_builders).SyncRoot; } }

        private readonly Dictionary<TIdentifier, IBuilder> m_builders;

        public Factory(int capacity = 0, IEqualityComparer<TIdentifier> comparer = null)
        {
            m_builders = new Dictionary<TIdentifier, IBuilder>(capacity, comparer);
        }

        public Factory(IDictionary<TIdentifier, IBuilder> dictionary, IEqualityComparer<TIdentifier> comparer = null)
        {
            if (dictionary == null) throw new ArgumentNullException(nameof(dictionary));
            
            m_builders = new Dictionary<TIdentifier, IBuilder>(dictionary, comparer);
        }

        public bool Contains(TIdentifier identifier)
        {
            return m_builders.ContainsKey(identifier);
        }

        public bool Contains(IBuilder builder)
        {
            return m_builders.ContainsValue(builder);
        }

        public void Add(TIdentifier identifier, IBuilder builder)
        {
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
            return (T)m_builders[identifier];
        }

        public bool TryGet<T>(TIdentifier identifier, out T builder) where T : IBuilder
        {
            if (m_builders.TryGetValue(identifier, out IBuilder value) && value is T result)
            {
                builder = result;
                return true;
            }

            builder = default(T);
            return false;
        }

        public bool TryGet(TIdentifier identifier, out IBuilder builder)
        {
            return m_builders.TryGetValue(identifier, out builder);
        }

        public void CopyTo(Array array, int index)
        {
            ((ICollection)m_builders).CopyTo(array, index);
        }

        public Dictionary<TIdentifier, IBuilder>.Enumerator GetEnumerator()
        {
            return m_builders.GetEnumerator();
        }

        IEnumerator<KeyValuePair<TIdentifier, IBuilder>> IEnumerable<KeyValuePair<TIdentifier, IBuilder>>.GetEnumerator()
        {
            return ((IEnumerable<KeyValuePair<TIdentifier, IBuilder>>)m_builders).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)m_builders).GetEnumerator();
        }
    }
}