using System;
using System.Collections;

namespace UGF.Factory.Runtime
{
    /// <summary>
    /// Represents collection of the factories stored by identifier.
    /// </summary>
    public interface IFactoryCollection : ICollection
    {
        /// <summary>
        /// Gets the type of the identifier.
        /// </summary>
        Type IdentifierType { get; }
    }
}