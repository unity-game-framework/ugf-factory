using System;
using System.Collections.Generic;

namespace UGF.Factory.Runtime
{
    public class FactoryCollection<T> : Dictionary<T, IFactory>, IFactoryCollection
    {
        public Type IdentifierType { get; } = typeof(T);
    }
}