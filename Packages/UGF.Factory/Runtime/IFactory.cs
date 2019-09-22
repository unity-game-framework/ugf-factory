using System;
using System.Collections;

namespace UGF.Factory.Runtime
{
    /// <summary>
    /// Represents collection of the factory builders stored by identifier.
    /// </summary>
    public interface IFactory : IEnumerable
    {
        /// <summary>
        /// Gets the type of the identifier.
        /// </summary>
        Type IdentifierType { get; }
    }
}
