using System;
using System.Collections;

namespace UGF.Factory.Runtime
{
    public interface IFactoryCollection : IDictionary
    {
        Type IdentifierType { get; }
    }
}