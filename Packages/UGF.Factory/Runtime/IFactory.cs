using System;
using System.Collections;

namespace UGF.Factory.Runtime
{
    public interface IFactory : IEnumerable
    {
        int Count { get; }

        Type GetIdentifierType();
    }
}