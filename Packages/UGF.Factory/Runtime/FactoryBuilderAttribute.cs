using System;
using JetBrains.Annotations;
using UGF.Assemblies.Runtime;
using UGF.Builder.Runtime;

namespace UGF.Factory.Runtime
{
    [BaseTypeRequired(typeof(IBuilder))]
    public class FactoryBuilderAttribute : AssemblyBrowsableTypeAttribute
    {
        public Type FactoryType { get; }
        public Guid Guid { get; }

        public FactoryBuilderAttribute(Type factoryType, string guid)
        {
            FactoryType = factoryType;
            Guid = Guid.Parse(guid);
        }
    }
}