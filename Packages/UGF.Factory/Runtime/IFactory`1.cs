using System.Collections.Generic;
using UGF.Builder.Runtime;

namespace UGF.Factory.Runtime
{
    public interface IFactory<TIdentifier> : IFactory, IEnumerable<KeyValuePair<TIdentifier, IBuilder>>
    {
        IBuilder this[TIdentifier identifier] { get; set; }
        
        bool Contains(TIdentifier identifier);
        bool Contains(IBuilder builder);
        void Add(TIdentifier identifier, IBuilder builder);
        bool Remove(TIdentifier identifier);
        void Clear();
        T Get<T>(TIdentifier identifier) where T : IBuilder;
        bool TryGet<T>(TIdentifier identifier, out T builder) where T : IBuilder;
        bool TryGet(TIdentifier identifier, out IBuilder builder);
    }
}