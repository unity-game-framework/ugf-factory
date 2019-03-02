using System;
using JetBrains.Annotations;
using UGF.Assemblies.Runtime;

namespace UGF.Factory.Runtime
{
    [BaseTypeRequired(typeof(IFactoryDefine))]
    [AttributeUsage(AttributeTargets.Class)]
    public class FactoryDefineAttribute : AssemblyBrowsableTypeAttribute
    {
    }
}