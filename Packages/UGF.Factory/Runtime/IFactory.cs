using System;
using System.Collections;

namespace UGF.Factory.Runtime
{
    public interface IFactory : IDictionary
    {
        Type IdentifierType { get; }
    }
}