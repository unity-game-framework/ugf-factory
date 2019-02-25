using System;
using System.Collections;
using System.Collections.Generic;

namespace UGF.Factory.Runtime
{
    public class FactoryProvider<TIdentifier> : IFactoryProvider<TIdentifier>
    {
        public int Count { get { return m_factories.Count; } }
        public IFactory this[TIdentifier identifier] { get { return m_factories[identifier]; } set { m_factories[identifier] = value; } }

        private readonly Dictionary<TIdentifier, IFactory> m_factories;

        public FactoryProvider(int capacity = 0, IEqualityComparer<TIdentifier> comparer = null)
        {
            m_factories = new Dictionary<TIdentifier, IFactory>(capacity, comparer);
        }

        public FactoryProvider(IDictionary<TIdentifier, IFactory> dictionary, IEqualityComparer<TIdentifier> comparer = null)
        {
            m_factories = new Dictionary<TIdentifier, IFactory>(dictionary, comparer);
        }

        public bool Contains(TIdentifier identifier)
        {
            return m_factories.ContainsKey(identifier);
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
            if (m_factories.TryGetValue(identifier, out var value) && value is T match)
            {
                factory = match;
                return true;
            }

            factory = default(T);
            return false;
        }

        public bool TryGet(TIdentifier identifier, out IFactory factory)
        {
            return m_factories.TryGetValue(identifier, out factory);
        }

        public Type GetIdentifierType()
        {
            return typeof(TIdentifier);
        }

        public Dictionary<TIdentifier, IFactory>.Enumerator GetEnumerator()
        {
            return m_factories.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)m_factories).GetEnumerator();
        }

        IEnumerator<KeyValuePair<TIdentifier, IFactory>> IEnumerable<KeyValuePair<TIdentifier, IFactory>>.GetEnumerator()
        {
            return ((IEnumerable<KeyValuePair<TIdentifier, IFactory>>)m_factories).GetEnumerator();
        }
    }
}