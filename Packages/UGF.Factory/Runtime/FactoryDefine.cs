using System;

namespace UGF.Factory.Runtime
{
    /// <summary>
    /// Represents the define of the factory.
    /// </summary>
    public abstract class FactoryDefine<TFactory, TBuilderId> : FactoryDefineBase<Type, TBuilderId>
    {
        public override Type GetFactoryId(IFactoryProvider provider, IFactoryCollection<Type> collection)
        {
            return typeof(TFactory);
        }
    }
}