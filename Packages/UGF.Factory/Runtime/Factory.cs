using System;
using System.Collections;
using System.Collections.Generic;
using UGF.Builder.Runtime;

namespace UGF.Factory.Runtime
{
    public class Factory<TIdentifier> : IFactory<TIdentifier>
    {
        public int Count { get { return m_builders.Count; } }
        public IBuilder this[TIdentifier identifier] { get { return m_builders[identifier]; } set { m_builders[identifier] = value; } }

        private readonly Dictionary<TIdentifier, IBuilder> m_builders;

        public Factory(int capacity = 0, IEqualityComparer<TIdentifier> comparer = null)
        {
            m_builders = new Dictionary<TIdentifier, IBuilder>(capacity, comparer);
        }

        public Factory(IDictionary<TIdentifier, IBuilder> dictionary, IEqualityComparer<TIdentifier> comparer = null)
        {
            m_builders = new Dictionary<TIdentifier, IBuilder>(dictionary, comparer);
        }

        public bool Contains(TIdentifier identifier)
        {
            return m_builders.ContainsKey(identifier);
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
            if (m_builders.TryGetValue(identifier, out var value) && value is T match)
            {
                builder = match;
                return true;
            }

            builder = default(T);
            return false;
        }

        public bool TryGet(TIdentifier identifier, out IBuilder builder)
        {
            return m_builders.TryGetValue(identifier, out builder);
        }

        public Type GetIdentifierType()
        {
            return typeof(TIdentifier);
        }

        public Dictionary<TIdentifier, IBuilder>.Enumerator GetEnumerator()
        {
            return m_builders.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)m_builders).GetEnumerator();
        }

        IEnumerator<KeyValuePair<TIdentifier, IBuilder>> IEnumerable<KeyValuePair<TIdentifier, IBuilder>>.GetEnumerator()
        {
            return ((IEnumerable<KeyValuePair<TIdentifier, IBuilder>>)m_builders).GetEnumerator();
        }
    }
}