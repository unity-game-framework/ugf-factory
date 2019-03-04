using System;
using JetBrains.Annotations;
using UGF.Assemblies.Runtime;

namespace UGF.Factory.Runtime
{
    /// <summary>
    /// Represents attribute to mark browsable factory defines.
    /// </summary>
    [BaseTypeRequired(typeof(IFactoryDefine))]
    [AttributeUsage(AttributeTargets.Class)]
    public class FactoryDefineAttribute : AssemblyBrowsableTypeAttribute
    {
    }
}