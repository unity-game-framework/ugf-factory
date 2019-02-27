using System;
using JetBrains.Annotations;
using UGF.Assemblies.Runtime;
using UGF.Builder.Runtime;

namespace UGF.Factory.Runtime
{
    [BaseTypeRequired(typeof(IBuilder))]
    public class FactoryBuilderAttribute : AssemblyBrowsableTypeAttribute
    {
        public object FactoryId { get; }
        public object BuilderId { get; }

        public FactoryBuilderAttribute(object factoryId, object builderId)
        {
            FactoryId = factoryId;
            BuilderId = builderId;
        }
    }
}