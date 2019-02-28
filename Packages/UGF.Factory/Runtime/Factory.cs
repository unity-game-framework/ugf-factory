using System;
using System.Collections.Generic;
using UGF.Builder.Runtime;

namespace UGF.Factory.Runtime
{
    public class Factory<T> : Dictionary<T, IBuilder>, IFactory
    {
        public Type IdentifierType { get; } = typeof(T);
    }
}