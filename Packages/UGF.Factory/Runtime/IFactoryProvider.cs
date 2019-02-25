using System;
using System.Collections;

namespace UGF.Factory.Runtime
{
    public interface IFactoryProvider : IEnumerable
    {
        int Count { get; }

        Type GetIdentifierType();
    }
}