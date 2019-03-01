using System;
using System.Collections;

namespace UGF.Factory.Runtime
{
    public interface IFactory : ICollection
    {
        Type IdentifierType { get; }
    }
}