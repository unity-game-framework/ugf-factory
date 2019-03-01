using System;
using System.Collections;

namespace UGF.Factory.Runtime
{
    public interface IFactoryCollection : ICollection
    {
        Type IdentifierType { get; }
    }
}