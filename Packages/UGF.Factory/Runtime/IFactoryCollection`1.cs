using System.Collections.Generic;

namespace UGF.Factory.Runtime
{
    public interface IFactoryCollection<TIdentifier> : IFactoryCollection, IEnumerable<KeyValuePair<TIdentifier, IFactory>>
    {
        IFactory this[TIdentifier identifier] { get; set; }

        bool Contains(TIdentifier identifier);
        bool Contains(IFactory factory);
        void Add(TIdentifier identifier, IFactory factory);
        bool Remove(TIdentifier identifier);
        void Clear();
        T Get<T>(TIdentifier identifier) where T : IFactory;
        bool TryGet<T>(TIdentifier identifier, out T factory) where T : IFactory;
        bool TryGet(TIdentifier identifier, out IFactory factory);
    }
}