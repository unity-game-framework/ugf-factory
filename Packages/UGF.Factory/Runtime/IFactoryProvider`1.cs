using System.Collections.Generic;

namespace UGF.Factory.Runtime
{
    public interface IFactoryProvider<TIdentifier> : IFactoryProvider, IEnumerable<KeyValuePair<TIdentifier, IFactory>>
    {
        IFactory this[TIdentifier identifier] { get; set; }

        bool Contains(TIdentifier identifier);
        void Add(TIdentifier identifier, IFactory factory);
        bool Remove(TIdentifier identifier);
        void Clear();
        T Get<T>(TIdentifier identifier) where T : IFactory;
        bool TryGet<T>(TIdentifier identifier, out T factory) where T : IFactory;
        bool TryGet(TIdentifier identifier, out IFactory factory);
    }
}