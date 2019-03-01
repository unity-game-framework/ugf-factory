using System;
using System.Collections;
using System.Collections.Generic;

namespace UGF.Factory.Runtime
{
    public interface IFactoryProvider : ICollection, IEnumerable<KeyValuePair<Type, IFactoryCollection>>
    {
        IFactoryCollection this[Type type] { get; set; }

        bool Contains(Type type);
        bool Contains(IFactoryCollection collection);
        void Add(Type type, IFactoryCollection collection);
        bool Remove(Type type);
        void Clear();
        IFactoryCollection<T> Get<T>();
        bool TryGet<T>(out IFactoryCollection<T> collection);
        bool TryGet(Type type, out IFactoryCollection collection);
    }
}